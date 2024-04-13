using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.Enum.OOT;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Core;
using MajoraAutoItemTracker.Core.Utils;

namespace MajoraAutoItemTracker.UI.MainUI
{
    public partial class MainUIForm : Form
    {
        private const int CST_RECT_WIDTH_HEIGHT = 40;

        public bool restartToConfig = false;

        private readonly CheckSaveFormatHeader? checkSave;
        private readonly AbstractMemoryListener memoryListener;

        private readonly MainUIController mainUIController = new MainUIController();
        private readonly MajoraMaskController majoraMaskController = new MajoraMaskController();
        private readonly OcarinaOfTimeController ocarinaOfTimeController = new OcarinaOfTimeController();

        public MainUIForm(
            AbstractMemoryListener memoryListener,
            CheckSaveFormatHeader? checkSave)
        {
            this.memoryListener = memoryListener;
            this.checkSave = checkSave;

            InitializeComponent();
        }

        private void OnMainUiFormLoad(object sender, EventArgs e)
        {
            FormUtils.RestoreFormState(this);

            // Init PictureBox
            mainUIController.InitPictureBox(imageBoxMapOOT, imageBoxMapMM);
            mainUIController.imageBoxMapOOT!.OnGraphicPathClick += (it) => ocarinaOfTimeController.RefreshCheckListForCategory(gbCheckListOOT, lbCheckListOOT, it);
            mainUIController.imageBoxMapMM!.OnGraphicPathClick += (it) => majoraMaskController.RefreshCheckListForCategory(gbCheckListMM, lbCheckListMM, it);

            // Init game controller
            ocarinaOfTimeController.Init(
                Log,
                mainUIController.imageBoxMapOOT,
                pictureBoxOOTItemList,
                lbCheckListOOT,
                cmsCheckList);
            ocarinaOfTimeController.DrawSquareCategory(CST_RECT_WIDTH_HEIGHT);
            majoraMaskController.Init(
                Log,
                mainUIController.imageBoxMapMM,
                pictureBoxMMItemList,
                lbCheckListMM,
                cmsCheckList);
            majoraMaskController.DrawSquareCategory(CST_RECT_WIDTH_HEIGHT);

            if (checkSave != null)
            {
                ocarinaOfTimeController.LoadFromSave(checkSave.OOTCheckList);
                majoraMaskController.LoadFromSave(checkSave.MMCheckList);
            }

            memoryListener.callBackEventOot.Subscribe(OnOOTItemLogicChange);
            memoryListener.callBackEventMm.Subscribe(OnMMItemLogicChange);
            memoryListener.StartThread();
        }

        private void OnOOTItemLogicChange(List<Tuple<OcarinaOfTimeItemLogicPopertyName, object>> itemLogicProperty)
        {
            this.Invoke((MethodInvoker)delegate
            {
                UpdateTabIfOOTxMM(tabOcarinaOfTime);
                Log($"OOT: updated {itemLogicProperty.Count} value");
                ocarinaOfTimeController.OnItemLogicChange(itemLogicProperty);
            });
        }

        private void OnMMItemLogicChange(List<Tuple<MajoraMaskItemLogicPopertyName, object>> itemLogicProperty)
        {
            this.Invoke((MethodInvoker)delegate
            {
                UpdateTabIfOOTxMM(tabMajoraMask);
                Log($"MM: updated {itemLogicProperty.Count} value");
                majoraMaskController.OnItemLogicChange(itemLogicProperty);
            });
        }

        private void UpdateTabIfOOTxMM(TabPage newTabToDisplay)
        {
            if (tabGameMenu.SelectedTab == newTabToDisplay)
                return;
            tabGameMenu.SelectedTab = newTabToDisplay;
        }

        private void Log(String message)
        {
            tboxDebug.AppendText(message + "\r\n");
            Debug.WriteLine(message);
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            memoryListener.StopThread();
            var checkSave = CreatecheckSaveFormatHeader(RomType.RANDOMIZE_OOT_X_MM);
            CheckItemUtils.SaveCheckSaveToMemory(checkSave);
            if (AskToSaveFromFile())
                CheckItemUtils.SaveToFile(checkSave);
            FormUtils.SaveFormState(this);
        }

        private bool AskToSaveFromFile()
        {
            return MessageBox.Show(
                "Save to file ?",
                "Save to file ?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private CheckSaveFormatHeader CreatecheckSaveFormatHeader(RomType romType)
        {
            return new CheckSaveFormatHeader()
            {
                SaveRomType = romType,
                OOTCheckList = ocarinaOfTimeController.SaveListCheck(),
                MMCheckList = majoraMaskController.SaveListCheck()
            };
        }

        private void OnResetCheckClaimClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Clear check ?",
                "Clear check ?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ocarinaOfTimeController.ResetCheckClaim();
                majoraMaskController.ResetCheckClaim();
            }
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkSave = CreatecheckSaveFormatHeader(RomType.RANDOMIZE_OOT_X_MM);
            CheckItemUtils.SaveToFile(checkSave);
        }

        private void goToConfigScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartToConfig = true;
            Close();
        }
    }
}
