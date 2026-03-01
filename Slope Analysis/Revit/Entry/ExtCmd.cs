using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Slope_Analysis.Revit.ExtEventHandlers;
using Slope_Analysis.Revit.Utils;
using Slope_Analysis.UI.Forms;
using Slope_Analysis.UI.ViewModels;






namespace Slope_Analysis.Revit.Entry
{
    [Transaction(TransactionMode.Manual)]
    public class ExtCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                
                UIApplication uiApp = commandData.Application;
                UIDocument uiDoc = uiApp.ActiveUIDocument;
                Document doc = uiDoc.Document;

                //create handlers first 
                var generationHandler = new GenerationExtEventHandler();
                var resetHandler = new ResetColorsExtEventHandler();

                //wrap handlers in external events
                var generationEvent = ExternalEvent.Create(generationHandler);
                var resetEvent = ExternalEvent.Create(resetHandler);

                // create the viewmodel and give it the events so it can raise them when the user clicks the buttons
                MainViewModel viewModel = new MainViewModel(uiDoc, doc, generationEvent, resetEvent);

                //give the handlers the viewmodel so they can read the data when revit calls execute
                generationHandler.MainViewModel = viewModel;
                resetHandler.MainViewModel = viewModel;
                //create and configure the form
                MainForm mainForm = new MainForm();
                mainForm.SetViewModel(viewModel);
                //auto reset when user closes the form
                mainForm.FormClosed += (s,e) => { resetEvent.Raise(); };

                //show the form
                mainForm.Show(new WindowHandle(uiApp.MainWindowHandle));

                return Result.Succeeded;
            } 
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}

