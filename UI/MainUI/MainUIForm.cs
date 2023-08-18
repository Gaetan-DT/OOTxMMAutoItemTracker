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

        private readonly MainUIController mainUIController = new MainUIController();
        private readonly EmulatorController emulatorController = new EmulatorController();
        private readonly MajoraMaskController majoraMaskController = new MajoraMaskController();
        private readonly OcarinaOfTimeController ocarinaOfTimeController = new OcarinaOfTimeController();

        private const int CST_RECT_WIDTH_HEIGHT = 40;
        MemoryListener mMemoryListener = null;
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
            ModLoader64Wrapper modLoader64Wrapper = new ModLoader64Wrapper();
            MajoraMemoryDataObserver majoraMemoryDataObserver = new MajoraMemoryDataObserver();
            Log("Initializing thread");
            mMemoryListener = new MemoryListener(modLoader64Wrapper, majoraMemoryDataObserver, null);
            mMemoryListener.Start();
            Log("Thread started");
            mMemoryListener.OnAnyItemLogicChange.Subscribe(OnItemLogicChange);
        }

        private void OnItemLogicChange(Tuple <ItemLogicPopertyName, object> itemLogicProperty)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Log($"update for:{itemLogicProperty.Item1} with value: {itemLogicProperty.Item2}");
                var strItemLogicPropertyName = ItemLogicPopertyNameMethod.ToString(itemLogicProperty.Item1);
                foreach (var itemLogic in majoraMaskController.itemLogics)
                {
                    if (strItemLogicPropertyName == itemLogic.propertyName)
                    {
                        if (itemLogicProperty.Item2 is bool)
                        {
                            itemLogic.hasItem = (bool) itemLogicProperty.Item2;
                            itemLogic.CurrentVariant = 0;
                        }
                        // TODO: gerer les différent cas pour les enum
                        majoraMaskController.DrawItem(GetPictureBoxFromItemLogic, itemLogic);
                        // TODO: appeler la logicresolver pour mettre à jour les check avec le nouveau set d'items
                        break;
                    }
                }
                /* recuperer l'item logic grace au param itemlogicproperty.item1 de l'event
                 * avec l'item logic maj itemlogic "hasItem" grace au param foo de l'event 
                 * si le foo.Item2 est autre qu'un bool on va maj l'itemlogic.currentvariant
                 rappeler drawitem
                 * appeler la logicresolver pour mettre à jour les check avec le nouveau set d'items
                 */
            });
        }

        private void BtnStopListener_Click(object sender, EventArgs e)
        {
            mMemoryListener.Stop();
            mMemoryListener = null;
            Log("Thread Stoped");
        }

        private PictureBox GetPictureBoxFromItemLogic(ItemLogic itemLogic)
        {
            return ((System.Reflection.TypeInfo)GetType()).GetDeclaredField(itemLogic.propertyName).GetValue(this) as PictureBox;
        }


        private void Log(String message)
        {            
            tboxDebug.AppendText(message + "\r\n");
            Debug.WriteLine(message);
        }


        /*private void pictureBox2_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            // Debug.WriteLine(coordinates.X + " " + coordinates.Y);

            foreach(var checkLogicCategory in _checkLogicCategories)
            {
                var scaleX = checkLogicCategory.SquarePositionX * Map.Size.Width / 6000;
                var scaleY = checkLogicCategory.SquarePositionY * Map.Size.Height / 5555;
                if (coordinates.X >= scaleX -10 && coordinates.X <= scaleX +10 && 
                    coordinates.Y >= scaleY -10 && coordinates.Y <= scaleY +10)
                {
                    RefreshCheckListForCategory(checkLogicCategory);
                    CheckList.DisplayMember = "Id";
                    //Debug.WriteLine("On a cliqué sur la catégorie " + checkLogicCategory.Name);
                }
            }
        }*/

        private void ImgBeans_Click(object sender, EventArgs e)
        {

        }

       /* private void Map_Paint(object sender, PaintEventArgs e)
        {
            DrawSquareCategory(e);
        } */

        private void UpdateCbEmulatorList(List<AbstractEmulatorWrapper> emulatorList)
        {
            cbEmulatorList.SelectedIndex = -1;
            cbEmulatorList.Items.Clear();
            cbEmulatorList.Items.AddRange(emulatorList.Select(it => it.GetDisplayName()).ToArray());
            cbEmulatorList.SelectedIndex = cbEmulatorList.Items.Count > 0 ? 0 : -1;
        }

        private void CheckList_DrawItem(object sender, DrawItemEventArgs e)
        {
            var checkLogic = (CheckLogic)lbCheckListMM.Items[e.Index];

            Brush brush = Brushes.Red;

            if (checkLogic.IsClaim)
            {
                brush = Brushes.Gray;
                
            }
            else if (checkLogic.IsAvailable)
            {
                brush = Brushes.Green;
            }

            e.Graphics.DrawString(checkLogic.Id, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }

        private void CheckList_MouseClick(object sender, MouseEventArgs e)
        {
            var checkList = (CheckLogic)lbCheckListMM.SelectedItem;
            checkList.IsClaim = !checkList.IsClaim;
            lbCheckListMM.Invalidate();
        }
    }
}
