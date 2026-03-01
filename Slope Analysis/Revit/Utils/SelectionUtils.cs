using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Slope_Analysis.Revit.SelectionFilters;
using System.Collections.Generic;


namespace Slope_Analysis.Revit.Utils
{
    public class SelectionUtils
    {
        /// <summary>
        /// Selects floor elements in the Revit document.
        /// </summary>
        public static List<Element> SelectFloors(UIDocument uidoc,Document doc)
        {
            //pickobjects pauses revit and lets the user click elements
            // the filter restrict what can click to floor only

            IList<Reference> references = uidoc.Selection.PickObjects(
                ObjectType.Element,
                new FloorSelectionFilter(),
                "Select Floor");

            List<Element> floors = new List<Element>();
            foreach (var reference in references)
            {
                var floor = doc.GetElement(reference);
                if (floor != null)
                {
                    floors.Add(floor);
                }
            }
            return floors;
        }
    }
}
