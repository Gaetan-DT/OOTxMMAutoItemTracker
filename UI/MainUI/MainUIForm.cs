using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.Enum.OOT;

namespace MajoraAutoItemTracker.UI.MainUI
{
    public partial class MainUIForm : Form
    {
        private const int CST_RECT_WIDTH_HEIGHT = 40;

        private readonly MainUIController mainUIController = new MainUIController();
        private readonly EmulatorController emulatorController = new EmulatorController();
        private readonly MajoraMaskController majoraMaskController = new MajoraMaskController();
        private readonly OcarinaOfTimeController ocarinaOfTimeController = new OcarinaOfTimeController();

        public MainUIForm()
        {
            InitializeComponent();
        }

        private void OnMainUiFormLoad(object sender, EventArgs e)
        {
            emulatorController.RefreshEmulatorAndGameList();
            emulatorController.subEmulatorList.Subscribe(UpdateCbEmulatorList);
            emulatorController.subRomList.Subscribe(UpdateRomList);
            mainUIController.isMemoryListenerStartedSubject.Subscribe(OnEmulatorStartStop);

            // Init PictureBox
            mainUIController.InitPictureBox(panelMapOOT, panelMapMM);
            mainUIController.pictureBoxMapOOT.OnGraphicPathClick += (it) => ocarinaOfTimeController.RefreshCheckListForCategory(lbCheckListOOT, it);
            mainUIController.pictureBoxMapMM.OnGraphicPathClick += (it) => majoraMaskController.RefreshCheckListForCategory(lbCheckListMM, it);

            // Init game controller
            if (ocarinaOfTimeController.Init(Log, mainUIController.pictureBoxMapOOT, pictureBoxOOTItemList, lbCheckListOOT))
                ocarinaOfTimeController.DrawSquareCategory(CST_RECT_WIDTH_HEIGHT);
            if (majoraMaskController.Init(Log, mainUIController.pictureBoxMapMM, pictureBoxMMItemList, lbCheckListMM))
                majoraMaskController.DrawSquareCategory(CST_RECT_WIDTH_HEIGHT);
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

        private void UpdateCbEmulatorList(List<AbstractRomController> emulatorList)
        {
            toolStripComboBoxEmulatorList.SelectedIndex = -1;
            toolStripComboBoxEmulatorList.Items.Clear();
            toolStripComboBoxEmulatorList.Items.AddRange(emulatorList.Select(it => it.GetDisplayName()).ToArray());
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
    }
}
