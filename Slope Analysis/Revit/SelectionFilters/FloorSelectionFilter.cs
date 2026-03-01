using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace Slope_Analysis.Revit.SelectionFilters
{
    internal class FloorSelectionFilter: ISelectionFilter
    {
        public bool AllowElement(Element elem)
        //only return true for floor elements
        {
            return elem.Category != null && elem.Category.Id.Value == (int)BuiltInCategory.OST_Floors;
        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            return false; // because we are only interested in element selection, not reference selection
        }
    }
}
