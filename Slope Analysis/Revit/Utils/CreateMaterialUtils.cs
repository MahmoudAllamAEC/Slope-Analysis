using System.Linq;
using Autodesk.Revit.DB;

namespace Slope_Analysis.Revit.Utils
{
    public static class CreateMaterialUtils
    {
        public static Material CreateOrGetMaterial(Document doc, string name, Color color)
        {
            // search  all materials  in the documnet for one with this name 

            Material existingMat = new FilteredElementCollector(doc)
                .OfClass(typeof(Material))
                .Cast<Material>()
                .FirstOrDefault(m => m.Name == name);

            if (existingMat != null)
            {
                existingMat.Color = color; // update if it already exists
                return existingMat;

            }

            // create a brand new material
            ElementId matId = Material.Create(doc, name);
            Material newMat = doc.GetElement(matId) as Material;

            if (newMat != null)
            {
                newMat.Color = color;
                newMat.UseRenderAppearanceForShading = true; //Makes color visble in 3d views

            }
            return newMat;
        }
    }
}
