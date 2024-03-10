using MajoraAutoItemTracker.UI.MainUI;
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

            //MajoraAutoItemTracker.MemoryReader.Projetc64EM.Project64EMWrapper.Test();
            //throw new Exception();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainUIForm());
        }
    }
}
