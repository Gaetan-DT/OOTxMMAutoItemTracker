using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.UI.InitConfig;
using MajoraAutoItemTracker.UI.MainUI;
using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace MajoraAutoItemTracker
{
    [SupportedOSPlatform("windows7.0")]
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Environment.Is64BitProcess)
                throw new Exception("64bit process, need to be build in x86");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var initConfigForm = new InitConfigForm();

            if (initConfigForm.ShowDialog() == DialogResult.OK)
            {
                AbstractMemoryListener? memoryListener = initConfigForm.memoryListener;
                CheckSaveFormatHeader? checkSave = initConfigForm.GetLastSubbjectCheckSave();
                if (memoryListener == null)
                {
                    throw new Exception("Unable to start");
                }
                var mainForm = new MainUIForm(memoryListener, checkSave);
                Application.Run(mainForm);
            }
        }
    }
}
