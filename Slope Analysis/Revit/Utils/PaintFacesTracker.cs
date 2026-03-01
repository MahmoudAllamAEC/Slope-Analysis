using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace Slope_Analysis.Revit.Utils
{
    public static class PaintFacesTracker
    {
        //a list of tuples  each tuple holds which element and which face was painted

        
        public static List <(ElementId elementId , Face face)> Paintedfaces = new List<(ElementId, Face)>();

        public static void Add(ElementId elemtId , Face face)
        {
            Paintedfaces.Add((elemtId, face));
        }

        public static void ClearPaint(Document doc )
        {
            foreach (var item in Paintedfaces)
            {
                doc.RemovePaint(item.elementId, item.face);

            }
                Paintedfaces.Clear(); // clear the list after removing the paint
        }
    }
}
