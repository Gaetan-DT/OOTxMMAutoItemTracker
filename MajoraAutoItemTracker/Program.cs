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

            var restart = false;
            do
            {
                if (StartConfigScreen(out var memoryListener, out var checkSave))
                {
                    restart = StartEmulatorScreen(memoryListener!, checkSave!);
                }
            } while (restart);
        }

        private static bool StartConfigScreen(
            out AbstractMemoryListener? memoryListener,
            out CheckSaveFormatHeader? checkSave)
        {
            var initConfigForm = new InitConfigForm();
            var dialogResult = initConfigForm.ShowDialog();
            memoryListener = initConfigForm.memoryListener;
            checkSave = initConfigForm.GetLastSubbjectCheckSave();
            return dialogResult == DialogResult.OK;
        }

        private static bool StartEmulatorScreen(
            AbstractMemoryListener memoryListener,
            CheckSaveFormatHeader checkSave)
        {
            var mainForm = new MainUIForm(memoryListener, checkSave);
            Application.Run(mainForm);
            return mainForm.restartToConfig;
        }
    }
}
