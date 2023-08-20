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
            string errorMessage;
            if (ocarinaOfTimeController.Init(pictureBoxOOTItemList, lbCheckListOOT, out errorMessage))
                ocarinaOfTimeController.DrawSquareCategory(mainUIController.pictureBoxMapOOT, CST_RECT_WIDTH_HEIGHT);
            else
                Log(errorMessage);

            if (majoraMaskController.Init(pictureBoxMMItemList, lbCheckListMM, out errorMessage))
                majoraMaskController.DrawSquareCategory(mainUIController.pictureBoxMapMM, CST_RECT_WIDTH_HEIGHT);
            else
                Log(errorMessage);
        }

        private void BtnStartListenerClick(object sender, EventArgs e)
        {
            Log("Attaching to modloader");
            var emulatorWrapper = emulatorController.GetSelectedEmulator(cbEmulatorList.SelectedIndex);
            var romeType = emulatorController.GetSelectedRomType(cbRomTypeList.SelectedIndex);
            if (!mainUIController.StartMemoryListener(emulatorWrapper, romeType, OnOOTItemLogicChange, OnMMItemLogicChange, out string error))
                Log(error);
            Log("Thread started");
        }

        private void BtnStopListener_Click(object sender, EventArgs e)
        {
            mainUIController.StopMemoryListener();
            Log("Thread Stoped");
        }

        private void OnOOTItemLogicChange(Tuple<OcarinaOfTimeItemLogicPopertyName, object> itemLogicProperty)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Log($"update for:{itemLogicProperty.Item1} with value: {itemLogicProperty.Item2}");
                ocarinaOfTimeController.OnItemLogicChange(itemLogicProperty);
            });
        }

        private void OnMMItemLogicChange(Tuple <MajoraMaskItemLogicPopertyName, object> itemLogicProperty)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Log($"update for:{itemLogicProperty.Item1} with value: {itemLogicProperty.Item2}");
                majoraMaskController.OnItemLogicChange(itemLogicProperty);
            });
        }

        private void UpdateRomList(List<RomType> romTypes)
        {
            cbRomTypeList.SelectedIndex = -1;
            cbRomTypeList.Items.Clear();
            cbRomTypeList.Items.AddRange(romTypes.Select((it) => it.ToString()).ToArray());
            cbRomTypeList.SelectedIndex = cbRomTypeList.Items.Count > 0 ? 0 : -1;
        }

        private void UpdateCbEmulatorList(List<AbstractRomController> emulatorList)
        {
            cbEmulatorList.SelectedIndex = -1;
            cbEmulatorList.Items.Clear();
            cbEmulatorList.Items.AddRange(emulatorList.Select(it => it.GetDisplayName()).ToArray());
            cbEmulatorList.SelectedIndex = cbEmulatorList.Items.Count > 0 ? 0 : -1;
        }

        private void OnEmulatorStartStop(bool started)
        {
            btnStartListener.Enabled = !started;
            btnStopListener.Enabled = started;
            btnRefreshGameAndRom.Enabled = !started;
            cbEmulatorList.Enabled = !started;
            cbRomTypeList.Enabled = !started;
            if (started)
            {
                var romType = emulatorController.GetSelectedRomType(cbRomTypeList.SelectedIndex);
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
        }

        private void Log(String message)
        {
            tboxDebug.AppendText(message + "\r\n");
            Debug.WriteLine(message);
        }

        private void btnRefreshGameAndRom_Click(object sender, EventArgs e)
        {
            emulatorController.RefreshEmulatorAndGameList();
        }
    }
}
