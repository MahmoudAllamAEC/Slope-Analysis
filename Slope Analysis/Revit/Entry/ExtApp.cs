using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;  // Reference WindowsBase.dll
using System.Windows.Media.Imaging;  // Reference PresentationCore.dll

using Autodesk.Revit.UI;
using Slope_Analysis.Properties;


namespace Slope_Analysis.Revit.Entry
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalApplication
    /// </summary>
    class ExtApp : IExternalApplication
    {
        /// <summary>
        /// The Add-in name to be shown on the form caption and on the push button.
        /// </summary>
        public static Assembly ThisAssembly { get; } = Assembly.GetExecutingAssembly();
        


        /// <summary>
        /// Implements the OnStartup event.
        /// </summary>
        /// <param name="uicApp"></param>
        /// <returns></returns>
        public Result OnStartup(UIControlledApplication uicApp)
        {
            string tabName = "KAITECH-BD-R09";
            string panelName = "General";
            string addinName = "Slope Analysis";
            //tool tip
            string toolTip = "Analyze slope of selected floor elements";

            // In case of creating a tab with the name of an existing one, an Exception will be raised.
            try
            {
                uicApp.CreateRibbonTab(tabName);
            }
            catch { }

            // Create or get panel
            RibbonPanel panel = uicApp.GetRibbonPanels(tabName)
                                      .FirstOrDefault(p => p.Name == panelName)
                                    ?? uicApp.CreateRibbonPanel(tabName, panelName);

            string assemblyName = ThisAssembly.GetName().Name;
            string classPath = "Slope_Analysis.Revit.Entry.ExtCmd";

            //Add-in Button:
            PushButtonData pbData_ExtCmd = new PushButtonData(
                $"{assemblyName}_btn",
                addinName,
                ThisAssembly.Location,
                classPath
                );

            PushButton pb_ExtCmd = panel.AddItem(pbData_ExtCmd) as PushButton;
            pb_ExtCmd.ToolTip = toolTip;

            // Button Image:
            // Try different resource path variations until one works
            string largeImagePath = "Slope_Analysis.Resources.icons8-slope-25.png";
            string smallImagePath = "Slope_Analysis.Resources.icons8-slope-16.png";
            
            ImageSource largeImage = getImageSource(largeImagePath);
            ImageSource smallImage = getImageSource(smallImagePath);
            
            if (largeImage != null) pb_ExtCmd.LargeImage = largeImage;
            if (smallImage != null) pb_ExtCmd.Image = smallImage;

            return Result.Succeeded;
        }

        /// <summary>
        /// Implements the OnShutdown event.
        /// </summary>
        /// <param name="uicApp"></param>
        /// <returns></returns>
        public Result OnShutdown(UIControlledApplication uicApp)
        {
            return Result.Succeeded;
        }



        /// <summary>
        /// Returns ImageSource of the passed png Image Embedded Path.
        /// </summary>
        /// <param name="image_EmbeddedPath">The embedded path of the image, e.g., namespace_Name.Resources.Image_Name</param>
        /// <returns></returns>
        private ImageSource getImageSource(string image_EmbeddedPath)
        {
            try
            {
                Stream stream = ThisAssembly.GetManifestResourceStream(image_EmbeddedPath);
                if (stream == null)
                {
                    // Log available resources for debugging
                    var availableResources = ThisAssembly.GetManifestResourceNames();
                    System.Diagnostics.Debug.WriteLine($"Resource '{image_EmbeddedPath}' not found.");
                    System.Diagnostics.Debug.WriteLine("Available resources:");
                    foreach (var resource in availableResources)
                    {
                        System.Diagnostics.Debug.WriteLine($"  - {resource}");
                    }
                    return null;
                }

                BitmapDecoder decoder = new PngBitmapDecoder(
                        stream,
                        BitmapCreateOptions.PreservePixelFormat,
                        BitmapCacheOption.OnLoad
                    );

                return decoder?.Frames[0];
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading image: {ex.Message}");
                return null;
            }
        }


        

    }
}
