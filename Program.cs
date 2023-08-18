using MajoraAutoItemTracker.MemoryReader.Project64;
using MajoraAutoItemTracker.MemoryReader.Projetc64EM;
using MajoraAutoItemTracker.UI.CheckLogicEditor;
using MajoraAutoItemTracker.UI.LogicTester;
using System;
using System.Windows.Forms;

namespace MajoraAutoItemTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.Is64BitProcess)
                throw new Exception("64bit process, need to be build in x86");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           // Application.Run(new CheckLogicEditor());
           // Application.Run(new LogicTester());
        }
    }
}
