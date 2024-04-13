using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
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
                EmulatorName? emulatorName = initConfigForm.emulatorName;
                RomType? romType = initConfigForm.romType;
                CurrentRom? currentRom = initConfigForm.currentRom;
                CheckSaveFormatHeader? checkSave = initConfigForm.checkSave;
                if (emulatorName == null || romType == null || currentRom == null)
                {
                    throw new Exception("Unable to start");
                }
                var mainForm = new MainUIForm(
                    emulatorName.Value,
                    romType.Value,
                    currentRom.Value,
                    checkSave);
                Application.Run(mainForm);
            }
        }
    }
}
