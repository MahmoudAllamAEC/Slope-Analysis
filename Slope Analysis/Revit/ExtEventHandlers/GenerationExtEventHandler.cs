using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Slope_Analysis.Revit.Utils;
using Slope_Analysis.UI.ViewModels;
using System.Linq;

namespace Slope_Analysis.Revit.ExtEventHandlers
{
    public class GenerationExtEventHandler : IExternalEventHandler
    {
        //the handler needs to read data from the viewmodel when revit calls execute

        public MainViewModel MainViewModel { get; set; }
        public void Execute(UIApplication app)
        {
            if (MainViewModel == null || MainViewModel.SelectedFloors.Count == 0)
            {
                TaskDialog.Show("Error", "No floors selected.");
                return;
            }
            Document doc = app.ActiveUIDocument.Document;

            using (Transaction trans = new Transaction(doc, "slope analysis paint"))
            {
                trans.Start();

                Material matGreen = CreateMaterialUtils.CreateOrGetMaterial(doc, "Green Paint", new Color(0, 200, 0));

                Material matRed = CreateMaterialUtils.CreateOrGetMaterial(doc, "Red Paint", new Color(200, 0, 0));

                if (matGreen == null || matRed == null) { trans.RollBack(); return; }


                CalculationUtils.CalculateSlope(
                    doc,
                    MainViewModel.SelectedFloors,
                    MainViewModel.StartRange,
                    MainViewModel.EndRange,
                    matGreen.Id,
                    matRed.Id
                    );

                trans.Commit();

            }
            TaskDialog.Show("Done", $"Analysis complete for {MainViewModel.SelectedFloors.Count} floors.");

        }
        public string GetName() => "Gentation";
      
        
    }
}
