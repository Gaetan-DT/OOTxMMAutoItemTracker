using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.Enum.OOT;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Core;

#nullable enable

namespace MajoraAutoItemTracker.UI.MainUI
{
    public partial class MainUIForm : Form
    {
        private const int CST_RECT_WIDTH_HEIGHT = 40;

        private readonly MainUIController mainUIController = new MainUIController();
        private readonly EmulatorController emulatorController = new EmulatorController();
        private readonly MajoraMaskController majoraMaskController = new MajoraMaskController();
        private readonly OcarinaOfTimeController ocarinaOfTimeController = new OcarinaOfTimeController();
        private readonly SaveCheckController saveCheckController = new SaveCheckController();

        public MainUIForm()
        {
            InitializeComponent();
        }

        private void OnMainUiFormLoad(object sender, EventArgs e)
        {
            FormUtils.RestoreFormState(this);
            emulatorController.RefreshEmulatorAndGameList();
            emulatorController.subEmulatorList.Subscribe(UpdateCbEmulatorList);
            emulatorController.subRomList.Subscribe(UpdateRomList);
            mainUIController.isMemoryListenerStartedSubject.Subscribe(OnEmulatorStartStop);

            // Load save
            var checkSaveList = saveCheckController.LoadFromAutoSave(RomType.RANDOMIZE_OOT_X_MM); //TODO: Remove romtype for autosave ?

            // Init PictureBox
            mainUIController.InitPictureBox(imageBoxMapOOT, imageBoxMapMM);
            mainUIController.imageBoxMapOOT!.OnGraphicPathClick += (it) => ocarinaOfTimeController.RefreshCheckListForCategory(gbCheckListOOT, lbCheckListOOT, it);
            mainUIController.imageBoxMapMM!.OnGraphicPathClick += (it) => majoraMaskController.RefreshCheckListForCategory(gbCheckListMM, lbCheckListMM, it);

            // Init game controller
            ocarinaOfTimeController.Init(Log, mainUIController.imageBoxMapOOT, pictureBoxOOTItemList, lbCheckListOOT);
            ocarinaOfTimeController.DrawSquareCategory(CST_RECT_WIDTH_HEIGHT);
            majoraMaskController.Init(Log, mainUIController.imageBoxMapMM, pictureBoxMMItemList, lbCheckListMM);
            majoraMaskController.DrawSquareCategory(CST_RECT_WIDTH_HEIGHT);

            if (checkSaveList != null)
            {
                ocarinaOfTimeController.LoadFromSave(checkSaveList.OOTCheckList);
                majoraMaskController.LoadFromSave(checkSaveList.MMCheckList);
            }
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

        private void OnMMItemLogicChange(List<Tuple <MajoraMaskItemLogicPopertyName, object>> itemLogicProperty)
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
            if (emulatorController.GetSelectedRomType(toolStripComboBoxRomTypeList.SelectedIndex) != RomType.RANDOMIZE_OOT_X_MM)
                return;
            if (tabGameMenu.SelectedTab == newTabToDisplay)
                return;
            tabGameMenu.SelectedTab = newTabToDisplay;
        }

        private void UpdateRomList(List<RomType> romTypes)
        {
            toolStripComboBoxRomTypeList.SelectedIndex = -1;
            toolStripComboBoxRomTypeList.Items.Clear();
            toolStripComboBoxRomTypeList.Items.AddRange(romTypes.Select((it) => it.ToString()).ToArray());
            toolStripComboBoxRomTypeList.SelectedIndex = toolStripComboBoxRomTypeList.Items.Count >= 0 ? 0 : -1;
        }

        private void UpdateCbEmulatorList(List<EmulatorName> emulatorList)
        {
            toolStripComboBoxEmulatorList.SelectedIndex = -1;
            toolStripComboBoxEmulatorList.Items.Clear();
            toolStripComboBoxEmulatorList.Items.AddRange(emulatorList.Select(it => it.ToString()).ToArray());
            toolStripComboBoxEmulatorList.SelectedIndex = toolStripComboBoxEmulatorList.Items.Count > 0 ? 0 : -1;
        }

        private void OnEmulatorStartStop(bool started)
        {
            stratStopToolStripMenuItemStartStopEmulator.Text = started ? "Stop" : "Start";
            refreshListToolStripMenuItem.Enabled = !started;
            toolStripComboBoxEmulatorList.Enabled = !started;
            toolStripComboBoxRomTypeList.Enabled = !started;
            if (started)
            {
                var romType = emulatorController.GetSelectedRomType(toolStripComboBoxRomTypeList.SelectedIndex);
                tabGameMenu.TabPages.Clear();
                switch (romType)
                {
                    case RomType.MAJORA_MASK_USA_V0:
                        tabGameMenu.TabPages.Add(tabMajoraMask);
                        break;
                    case RomType.OCARINA_OF_TIME_USA_V0:
                        tabGameMenu.TabPages.Add(tabOcarinaOfTime);
                        break;
                    case RomType.RANDOMIZE_OOT_X_MM:
                        tabGameMenu.TabPages.Add(tabOcarinaOfTime);
                        tabGameMenu.TabPages.Add(tabMajoraMask);
                        break;
                }
            }
            else
            {
                tabGameMenu.TabPages.Clear();
                tabGameMenu.TabPages.Add(tabOcarinaOfTime);
                tabGameMenu.TabPages.Add(tabMajoraMask);
            }
            tabGameMenu.TabPages.Add(tabPageLog);
        }

        private void Log(String message)
        {
            tboxDebug.AppendText(message + "\r\n");
            Debug.WriteLine(message);
        }

        private void OnCheckLogicEditorClick(object sender, EventArgs e)
        {
            new CheckLogicEditor.CheckLogicEditor().Show(this);
        }

        private void OnLogicTesterClick(object sender, EventArgs e)
        {
            new LogicTester.LogicTester().Show(this);
        }

        private void OnOotLogicCreatorClick(object sender, EventArgs e)
        {
            new OcarinaOfTimeLogicCreator.OcarinaOfTimeLogicCreator().Show(this);
        }

        private void OnMmLogicCreatorClick(object sender, EventArgs e)
        {
            new MajoraMaskLogicCreator.MajoraMaskLogicCreator().Show(this);
        }

        private void OnStartStopEmulatorClick(object sender, EventArgs e)
        {
            if (mainUIController.isMemoryListenerStartedSubject.Value)
            {
                // Stop memory listener
                mainUIController.StopMemoryListener();
                Log("Thread Stoped");
            }
            else
            {
                // Start memory listener
                var emulatorWrapper = emulatorController.GetSelectedEmulator(toolStripComboBoxEmulatorList.SelectedIndex);
                var romeType = emulatorController.GetSelectedRomType(toolStripComboBoxRomTypeList.SelectedIndex);
                if (!mainUIController.StartMemoryListener(emulatorWrapper, romeType, OnOOTItemLogicChange, OnMMItemLogicChange, out string error))
                    Log(error);
                else
                    Log("Thread started");
            }
        }

        private void OnRefreshEmulatorListClick(object sender, EventArgs e)
        {
            emulatorController.RefreshEmulatorAndGameList();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            saveCheckController.SaveToAutoSave(CreatecheckSaveFormatHeader(RomType.RANDOMIZE_OOT_X_MM));
            FormUtils.SaveFormState(this);
        }

        private void DoAutoSave() {
            saveCheckController.SaveToAutoSave(CreatecheckSaveFormatHeader(RomType.RANDOMIZE_OOT_X_MM));
        }

        private void OnManualLoadCheckClaim(object sender, EventArgs e)
        {
            var checkSaveList = saveCheckController.LoadFromFile();
            if (checkSaveList != null)
            {
                ocarinaOfTimeController.LoadFromSave(checkSaveList.OOTCheckList);
                majoraMaskController.LoadFromSave(checkSaveList.MMCheckList);

            }
            Log(checkSaveList != null ? "Check loaded!" : "Unable to load check!");
        }

        private void OnManualSaveCheckClaim(object sender, EventArgs e)
        {
            saveCheckController.SaveToFile(CreatecheckSaveFormatHeader(RomType.RANDOMIZE_OOT_X_MM));
            Log("Save done");
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
            ocarinaOfTimeController.ResetCheckClaim();
            majoraMaskController.ResetCheckClaim();
        }
    }
}
