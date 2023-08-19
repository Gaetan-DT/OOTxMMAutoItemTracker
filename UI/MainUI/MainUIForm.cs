using MajoraAutoItemTracker.MemoryReader.ModLoader64;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Item;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using MajoraAutoItemTracker.MemoryReader;

namespace MajoraAutoItemTracker.UI.MainUI
{
    public partial class MainUIForm : Form
    {
        private const int CST_RECT_WIDTH_HEIGHT = 40;

        private readonly MainUIController mainUIController = new MainUIController();
        private readonly EmulatorController emulatorController = new EmulatorController();
        private readonly MajoraMaskController majoraMaskController = new MajoraMaskController();
        private readonly OcarinaOfTimeController ocarinaOfTimeController = new OcarinaOfTimeController();

        private PictureBoxZoomMoveController<CheckLogicZone> _pictureBoxZoomMoveController;

        public MainUIForm()
        {
            InitializeComponent();
        }

        private void OnMainUiFormLoad(object sender, EventArgs e)
        {
            emulatorController.RefreshEmulatorAndGameList();
            emulatorController.subEmulatorList.Subscribe(UpdateCbEmulatorList);

            // Init PictureBox
            _pictureBoxZoomMoveController = new PictureBoxZoomMoveController<CheckLogicZone>(mapMm);
            _pictureBoxZoomMoveController.SetSrcImage(Image.FromFile(Application.StartupPath + @"\Resource\Map\82k78q66tcha1.png"));
            _pictureBoxZoomMoveController.OnGraphicPathClick += (it) => majoraMaskController.RefreshCheckListForCategory(lbCheckListMM, it);

            // Init game controller
            if (majoraMaskController.Init(GetPictureBoxFromItemLogic, out string errorMessage))
                majoraMaskController.DrawSquareCategory(_pictureBoxZoomMoveController, CST_RECT_WIDTH_HEIGHT);
            else
                Log(errorMessage);
        }

        private void BtnStartListenerClick(object sender, EventArgs e)
        {
            Log("Attaching to modloader");
            if (!mainUIController.StartMemoryListener(emulatorController.GetSelectedEmulator(lbCheckListMM.SelectedIndex), OnItemLogicChange, out string error))
                Log(error);
            Log("Thread started");
        }

        private void BtnStopListener_Click(object sender, EventArgs e)
        {
            mainUIController.StopMemoryListener();
            Log("Thread Stoped");
        }

        private void OnItemLogicChange(Tuple <ItemLogicPopertyName, object> itemLogicProperty)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Log($"update for:{itemLogicProperty.Item1} with value: {itemLogicProperty.Item2}");
                majoraMaskController.OnItemLogicChange(itemLogicProperty, GetPictureBoxFromItemLogic);
            });
        }

        private PictureBox GetPictureBoxFromItemLogic(ItemLogic itemLogic)
        {
            return ((System.Reflection.TypeInfo)GetType()).GetDeclaredField(itemLogic.propertyName).GetValue(this) as PictureBox;
        }

        private void UpdateCbEmulatorList(List<AbstractEmulatorWrapper> emulatorList)
        {
            cbEmulatorList.SelectedIndex = -1;
            cbEmulatorList.Items.Clear();
            cbEmulatorList.Items.AddRange(emulatorList.Select(it => it.GetDisplayName()).ToArray());
            cbEmulatorList.SelectedIndex = cbEmulatorList.Items.Count > 0 ? 0 : -1;
        }

        private void OnCheckListMMDrawItem(object sender, DrawItemEventArgs e)
        {
            var checkLogic = (CheckLogic)lbCheckListMM.Items[e.Index];
            Brush brush;
            if (checkLogic.IsClaim)
                brush = Brushes.Gray;
            else if (checkLogic.IsAvailable)
                brush = Brushes.Green;
            else
                brush = Brushes.Red;
            e.Graphics.DrawString(checkLogic.Id, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }

        private void OnCheckListMMClick(object sender, MouseEventArgs e)
        {
            var checkList = (CheckLogic)lbCheckListMM.SelectedItem;
            checkList.IsClaim = !checkList.IsClaim;
            lbCheckListMM.Invalidate();
        }

        private void Log(String message)
        {
            tboxDebug.AppendText(message + "\r\n");
            Debug.WriteLine(message);
        }
    }
}
