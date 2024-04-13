using MajoraAutoItemTracker.Core.Utils;
using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.UI.MainUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.InitConfig
{
    public partial class InitConfigForm : Form
    {
        private readonly EmulatorController emulatorController = new EmulatorController();

        public EmulatorName? emulatorName = null;
        public RomType? romType = null;
        public CurrentRom? currentRom = null;
        public CheckSaveFormatHeader? checkSave = null;

        public InitConfigForm()
        {
            InitializeComponent();
        }

        private void InitConfigForm_Load(object sender, EventArgs e)
        {
            emulatorController.RefreshEmulatorAndGameList();
            emulatorController.subEmulatorList.Subscribe(UpdateCbEmulatorList);
            emulatorController.subRomList.Subscribe(UpdateRomList);
            tbOotStartAddress.Text = RomUtils.GetStoredMemoryAddress(CurrentRom.OcarinaOfTIme).ToString("X");
            tbMmStartAddress.Text = RomUtils.GetStoredMemoryAddress(CurrentRom.MajoraMask).ToString("X");
            checkSave = CheckItemUtils.GetCheckSaveFromMemoryOrNull();
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
            romType = emulatorController.GetSelectedRomType(cbRomTypeList.SelectedIndex);
            emulatorName = emulatorController.GetSelectedEmulator(cbEmulatorList.SelectedIndex);
            this.currentRom = currentRom;
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
            checkSave = CheckItemUtils.LoadFromFile();
        }

        private void btnResetCheckSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Clear check ?",
                "Clear check ?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                checkSave = null;
            }
        }

        private void btnClearOOTStartAddrs_Click(object sender, EventArgs e)
        {
            RomUtils.UpdateStoredMemoryAddress(CurrentRom.OcarinaOfTIme, 0);
        }

        private void btnStartFromOOT_Click(object sender, EventArgs e)
        {
            CloseOrErrorWithParam(CurrentRom.OcarinaOfTIme);
        }

        private void btnClearMmAddress_Click(object sender, EventArgs e)
        {
            RomUtils.UpdateStoredMemoryAddress(CurrentRom.MajoraMask, 0);
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
