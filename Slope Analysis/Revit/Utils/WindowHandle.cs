using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Slope_Analysis.Revit.Utils
{
    public class WindowHandle : IWin32Window
    {
        private readonly IntPtr _handle;
        public WindowHandle(IntPtr handle) { _handle = handle; }
        public IntPtr Handle => _handle;
    }
}
