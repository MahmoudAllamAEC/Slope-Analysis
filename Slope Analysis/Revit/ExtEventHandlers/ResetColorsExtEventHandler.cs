using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Slope_Analysis.Revit.Utils;
using Slope_Analysis.UI.ViewModels;

namespace Slope_Analysis.Revit.ExtEventHandlers
{
    public class ResetColorsExtEventHandler : IExternalEventHandler
    {
        public MainViewModel MainViewModel { get; set; }

        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;

            using (Transaction t = new Transaction(doc, "reset Painted Faces"))
            {
                t.Start();
                PaintFacesTracker.ClearPaint(doc);//remove the paint from all the faces we painted on
                t.Commit();

            }
            TaskDialog.Show("reset","All painted faces have been cleared");

        }

        public string GetName() => "Reset Colors";



    }
}
