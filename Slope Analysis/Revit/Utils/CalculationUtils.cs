using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Slope_Analysis.Revit.SelectionFilters;

namespace Slope_Analysis.Revit.Utils
{
    public static class CalculationUtils
    {
        public static void CalculateSlope (Document doc ,IReadOnlyList<Element> Floors , double startRange , double endRange, ElementId matInRange ,ElementId matOutRange)
        {
            foreach (var floor in Floors)
            {
                // Get floor geometry with fine detail
                Options opt = new Options { DetailLevel = ViewDetailLevel.Fine };
                GeometryElement geoElem = floor.get_Geometry(opt);

                // if geometry element is null, skip to next floor
                if (geoElem == null) continue;

                foreach(GeometryObject geoObj in geoElem)
                {
                    //cast geometry object to solid, if it is not a solid
                    //, skip to next geometry object
                    Solid solid = geoObj as Solid;
                    if (solid == null || solid.Faces.Size == 0) continue;

                    foreach (Face face in solid.Faces)
                    {
                        //Compute the normal vector at face midpoint
                        // The UV parameter (0.5, 0.5) corresponds to the midpoint of the face
                        XYZ normal = face.ComputeNormal(new UV(0.5, 0.5));
                        if (normal == null ) continue;

                        //calculate slope in degrees relative to horizontal
                        double angleRad = normal.AngleTo(XYZ.BasisZ);

                        double slopePercent = Math.Tan(angleRad) *100;

                        bool inRange = slopePercent >= startRange && slopePercent <= endRange;
                        
                        // choose material based on slope range 
                        ElementId materialId = inRange ? matInRange : matOutRange;

                        //Paint the face in the document
                        doc.Paint(floor.Id, face, materialId);

                        //keep track of the painted faces to allow reset later

                        PaintFacesTracker.Add(floor.Id, face);

                    }



                }




            }

        }
    }
}
