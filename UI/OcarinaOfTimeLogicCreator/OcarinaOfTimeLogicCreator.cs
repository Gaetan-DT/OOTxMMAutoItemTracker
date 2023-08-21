using MajoraAutoItemTracker.Model.Logic.OOT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.OcarinaOfTimeLogicCreator
{
    public partial class OcarinaOfTimeLogicCreator : Form
    {

        OcarinaOfTimeLogicCreatorController controller = new OcarinaOfTimeLogicCreatorController();
        LogicFileController logicFileController = new LogicFileController();

        public OcarinaOfTimeLogicCreator()
        {
            InitializeComponent();
        }

        private void OcarinaOfTimeLogicCreator_Load(object sender, EventArgs e)
        {
            controller.LoadLogic();
            labelLogicItemList.Text = $"Logic Item List (version {controller.logicFile.Version}):";
            logicFileController.InitWith(controller.logicFile);
            logicFileController.selectedLogicIdSubject.Subscribe(DisplayLogicIdList);
            logicFileController.logicItemListSubject.Subscribe(DisplayLogicItemList);
            logicFileController.selectedLogicItemSubject.Subscribe(DisplayLogicItem);
            logicFileController.selectedLogicItemListRequireItemListSubject.Subscribe(DisplayLogicItemRequireItemList);
            logicFileController.selectedLogicItemListListConditionalItemListSubject.Subscribe(DisplayLogicItemConditionalItemList);
            logicFileController.selectedLogicItemConditionalItemContentSubject.Subscribe(DisplayLogicItemConditionalItemContentList);
            logicFileController.RefreshListItemId();
            logicFileController.RefreshAll();

            buttonAddNewLogicItem.Click += (a, b) => logicFileController.CreateAndInsertNewItemLogic();
        }

        private void DisplayLogicIdList(List<string> listId)
        {
            ClearAndAddList(listBoxAvailableItemId, listId);
        }

        private void DisplayLogicItemList(List<OcarinaOfTimeJsonFormatLogicItem> logicItemList)
        {
            if (logicItemList == null)
                logicItemList = new List<OcarinaOfTimeJsonFormatLogicItem>();
            ClearAndAddList(listBoxLogicItemList, logicItemList.Select((it) => it.Id).ToList());
        }

        private void DisplayLogicItem(OcarinaOfTimeJsonFormatLogicItem logicItem)
        {
            
        }

        private void DisplayLogicItemRequireItemList(List<string> listRequireItem)
        {
            if (listRequireItem == null)
                listRequireItem = new List<string>();
            ClearAndAddList(listBoxLogicItemRequireItemList, listRequireItem);
        }

        private void DisplayLogicItemConditionalItemList(List<List<string>> listConditionalItem)
        {
            if (listConditionalItem == null)
                listConditionalItem = new List<List<string>>();
            var result = listConditionalItem.Select((it) => string.Join(", ", it.ToArray())).ToList();
            ClearAndAddList(listBoxLogicItemConditionalItemList, result);
        }

        private void DisplayLogicItemConditionalItemContentList(List<string> listConditionalItemContentList)
        {
            if (listConditionalItemContentList == null)
                listConditionalItemContentList = new List<string>();
            ClearAndAddList(listBoxConditionalItemContentList, listConditionalItemContentList);
        }

        private static void ClearAndAddList(ListBox listBox, List<string> content)
        {
            listBox.Items.Clear();
            if (content != null)
                listBox.Items.AddRange(content.ToArray());
            listBox.SelectedIndex = -1;
        }
    }
}
