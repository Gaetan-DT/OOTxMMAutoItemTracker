using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.UI.MainUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.InitConfig
{
    public partial class InitConfigForm : Form
    {
        private readonly InitConfigController initConfigController = new InitConfigController();
        private readonly EmulatorController emulatorController = new EmulatorController();

        public AbstractMemoryListener? memoryListener = null;

        public InitConfigForm()
        {
            InitializeComponent();
        }

        private void InitConfigForm_Load(object sender, EventArgs e)
        {
            emulatorController.RefreshEmulatorAndGameList();
            emulatorController.subEmulatorList.Subscribe(UpdateCbEmulatorList);
            emulatorController.subRomList.Subscribe(UpdateRomList);
            initConfigController.rsOotStartAddress.Subscribe((data) => tbOotStartAddress.Text = data);
            initConfigController.rsMmStartAddress.Subscribe((data) => tbMmStartAddress.Text = data);
        }

        public CheckSaveFormatHeader? GetLastSubbjectCheckSave()
        {
            initConfigController.rsCheckSave.TryGetValue(out CheckSaveFormatHeader? result);
            return result;
        }

        private void UpdateCbEmulatorList(List<EmulatorName> emulatorList)
        {
            cbEmulatorList.BeginUpdate();
            cbEmulatorList.SelectedIndex = -1;
            cbEmulatorList.Items.Clear();
            cbEmulatorList.Items.AddRange(emulatorList.Select(it => it.ToString()).ToArray());
            cbEmulatorList.SelectedIndex = cbEmulatorList.Items.Count > 0 ? 0 : -1;
            cbEmulatorList.EndUpdate();
        }

        private void UpdateRomList(List<RomType> romTypes)
        {
            cbRomTypeList.BeginUpdate();
            cbRomTypeList.SelectedIndex = -1;
            cbRomTypeList.Items.Clear();
            cbRomTypeList.Items.AddRange(romTypes.Select((it) => it.ToString()).ToArray());
            cbRomTypeList.SelectedIndex = cbEmulatorList.Items.Count >= 0 ? 0 : -1;
            cbRomTypeList.EndUpdate();
        }

        private void CloseOrErrorWithParam(CurrentRom currentRom)
        {
            if (cbRomTypeList.SelectedIndex == -1)
                return;
            if (cbEmulatorList.SelectedIndex == -1)
                return;
            var romType = emulatorController.GetSelectedRomType(cbRomTypeList.SelectedIndex);
            var emulatorName = emulatorController.GetSelectedEmulator(cbEmulatorList.SelectedIndex);

            memoryListener = initConfigController.GetMemoryListenerOrNull(
                emulatorName, 
                romType,
                currentRom,
                out string lastError);
            if (memoryListener == null)
            {
                lbLastErrorText.Text = lastError;
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRefreshEmulatorList_Click(object sender, EventArgs e)
        {
            emulatorController.RefreshEmulatorAndGameList();
        }

        private void btnRefreshRomType_Click(object sender, EventArgs e)
        {
            emulatorController.RefreshEmulatorAndGameList();
        }

        private void btnLoadCheckSave_Click(object sender, EventArgs e)
        {
            initConfigController.LoadCheckFromFile();
        }

        private void btnResetCheckSave_Click(object sender, EventArgs e)
        {
            initConfigController.ResetCheckSave();
        }

        private void btnClearOOTStartAddrs_Click(object sender, EventArgs e)
        {
            initConfigController.ResetMemoryAddress(CurrentRom.OcarinaOfTIme);
        }

        private void btnStartFromOOT_Click(object sender, EventArgs e)
        {
            CloseOrErrorWithParam(CurrentRom.OcarinaOfTIme);
        }

        private void btnClearMmAddress_Click(object sender, EventArgs e)
        {
            initConfigController.ResetMemoryAddress(CurrentRom.MajoraMask);
        }

        private void btnStartFromMM_Click(object sender, EventArgs e)
        {
            CloseOrErrorWithParam(CurrentRom.MajoraMask);
        }

        private void btnStartCheckLogicEditor_Click(object sender, EventArgs e)
        {
            new CheckLogicEditor.CheckLogicEditor().Show(this);
        }

        private void btnStartLogicTester_Click(object sender, EventArgs e)
        {
            new LogicTester.LogicTester().Show(this);
        }

        private void btnStartOotLogicCreator_Click(object sender, EventArgs e)
        {
            new OcarinaOfTimeLogicCreator.OcarinaOfTimeLogicCreator().Show(this);
        }

        private void btnStartMmLogicCreator_Click(object sender, EventArgs e)
        {
            new MajoraMaskLogicCreator.MajoraMaskLogicCreator().Show(this);
        }
    }
}
