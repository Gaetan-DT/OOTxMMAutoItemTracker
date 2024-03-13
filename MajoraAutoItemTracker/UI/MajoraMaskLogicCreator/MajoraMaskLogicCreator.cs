using MajoraAutoItemTracker.Model.Logic.MM;
using MajoraAutoItemTracker.Model.Logic.OOT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;

#nullable enable

namespace MajoraAutoItemTracker.UI.MajoraMaskLogicCreator
{
    public partial class MajoraMaskLogicCreator : Form
    {

        const int CURRENT_VERSION = 1;

        MajoraMaskLogicCreatorController controller = new MajoraMaskLogicCreatorController();
        MajoraMaskLogicFileController logicFileController = new MajoraMaskLogicFileController();

        private bool isRefreshing = false;

        public MajoraMaskLogicCreator()
        {
            InitializeComponent();
        }

        private void MajoraMaskLogicCreator_Load(object sender, EventArgs e)
        {
            InitLogicItemListEvent();
            InitLogicItemEvent();
            InitLogicItemListRequireItem();
            InitLogicItemListConditionalItem();
            InitLogicItemListContionalItemContent();
            controller.LoadLogic();
            labelLogicItemList.Text = $"Logic Item List (version {controller?.logicFile?.Version}):";
            logicFileController.InitWith(controller!.logicFile!);
            logicFileController.selectedLogicIdSubject.Subscribe((it) => {
                // Filter list
                var filteredList = it.Where((idSubject) => idSubject.ToLower().Contains(textBoxSearchAvailableId.Text.ToLower()));
                ClearAndAddList(listBoxAvailableItemId, filteredList.ToList());
            });
            logicFileController.logicItemListSubject.Subscribe((it) => {
                var filteredList = it.Where((listLogicItem) => listLogicItem!.Id!.ToLower().Contains(textBoxSearchLogicItemList.Text.ToLower()));
                ClearAndAddList(listBoxLogicItemList, filteredList.ToList()); 
            });
            logicFileController.selectedLogicItemSubject.Subscribe(DisplayLogicItem);
            logicFileController.selectedLogicItemListRequireItemListSubject.Subscribe((it) => ClearAndAddList(listBoxLogicItemRequireItemList, it));
            logicFileController.selectedLogicItemListListConditionalItemListSubject.Subscribe((it) => ClearAndAddList(listBoxLogicItemConditionalItemList, it));
            logicFileController.selectedLogicItemConditionalItemContentSubject.Subscribe((it) => ClearAndAddList(listBoxConditionalItemContentList, it));
            logicFileController.ResolveSelectedItemAndRefreshAll();
            buttonInsertMissingRegionCheck.Click += (s, e2) => logicFileController.IsertMissingRegionFile();
            buttonInsertMissingItem.Click += (s, e2) => logicFileController.InsertMissingItemIdInIdLogic();
            buttonSaveFile.Click += (s, e2) => controller.SaveLogic(CURRENT_VERSION, logicFileController.GetListOfItemList());
        }

        private void InitLogicItemListEvent()
        {
            buttonAddNewLogicItem.Click += (a, b) => logicFileController.CreateAndInsertNewItemLogic();
            buttonRemoveNewLogicItem.Click += (a, b) => logicFileController.RemoveSelectedItemLogic();
            listBoxLogicItemList.DrawItem += (s, e) =>
            {
                var messsage = "";
                if (e.Index >= 0)
                {
                    var itemList = listBoxLogicItemList.Items[e.Index] as MajoraMaskJsonFormatLogicItem;
                    messsage = $"{itemList?.Id} ({itemList?.RequiredItems.Count + itemList?.ConditionalItems.Count} item)";
                }
                DrawListBoxLineAndRect(e, listBoxLogicItemList, messsage);
            };
            listBoxLogicItemList.SelectedValueChanged += (s, e) =>
            {
                if (isRefreshing)
                    return;
                string? logicItemId = (listBoxLogicItemList.SelectedItem as MajoraMaskJsonFormatLogicItem)?.Id;
                if (logicItemId != null)
                    logicFileController.ResolveSelectedItemAndRefreshAll(logicItemId);
            };
        }

        private void InitLogicItemEvent()
        {
            buttonSaveLogicItem.Click += (s, e) => logicFileController.SaveSelectedLogicItem(
                textBoxLogicItemId.Text,
                checkBoxLogicItemIsTrick.Checked);
        }

        private void InitLogicItemListRequireItem()
        {
            buttonAddRequireItemList.Click += (s, e) =>
            {
                var itemId = GetFromSelectedAndUncheck();
                if (itemId != null)
                    logicFileController.AddSelectedLogicItemRequireItem(itemId);
            };
            buttonRemoveRequireItemId.Click += (s, e) => logicFileController.RemoveSelectedLogicItemRequireItem();
            listBoxLogicItemRequireItemList.SelectedValueChanged += (s, e) =>
            {
                if (isRefreshing)
                    return;
                var selectedItem = listBoxLogicItemRequireItemList.SelectedItem as string;
                if (selectedItem != null)
                    logicFileController.UpdateSelectedLogicItemRequireItem(selectedItem);
            };
        }

        private void InitLogicItemListConditionalItem()
        {
            listBoxLogicItemConditionalItemList.DrawItem += (s, e) =>
            {
                string message = "";
                if (e.Index >= 0)
                {
                    var result = listBoxLogicItemConditionalItemList.Items[e.Index] as List<string>;
                    message = $"Conditional no:{e.Index}, {String.Join(", ", result)}";
                }
                DrawListBoxLineAndRect(e, listBoxLogicItemConditionalItemList, message);
            };
            listBoxLogicItemConditionalItemList.SelectedValueChanged += (s, e) => {
                if (isRefreshing)
                    return;
                var selectedItem = listBoxLogicItemConditionalItemList.SelectedItem as List<string>;
                if (selectedItem != null)
                    logicFileController.SetSelectedLogicItemConditionalItem(selectedItem);
                listBoxLogicItemConditionalItemList.Refresh();
            };
            buttonAddLogicItemConditionalItemList.Click += (s, e) => logicFileController.AddSelectedLogicItemConditionalItem();
            buttonRemoveLogicItemConditionalItemList.Click += (s, e) => logicFileController.RemoveSelectedLogicItemConditionalItem();
        }

        private void InitLogicItemListContionalItemContent()
        {
            listBoxConditionalItemContentList.SelectedValueChanged += (s, e) =>
            {
                if (isRefreshing)
                    return;
                var selectedItem = listBoxConditionalItemContentList.SelectedItem as string;
                if (selectedItem != null)
                    logicFileController.SetSelectedLogicItemListContionalItemContent(selectedItem);
            };
            buttonAddConditionalItemContent.Click += (s, e) =>
            {
                var itemId = GetFromSelectedAndUncheck();
                if (itemId != null)
                    logicFileController.AddLogicItemListContionalItemContent(itemId);
            };
            buttonRemoveConditionalItemContent.Click += (s, e) => logicFileController.RemoveLogicItemListContionalItemContent();
        }

        private void DisplayLogicItem(MajoraMaskJsonFormatLogicItem? logicItem)
        {
            isRefreshing = true;
            try
            {
                panelLogicItem.Visible = logicItem != null;
                textBoxLogicItemId.Text = logicItem?.Id ?? "";
                checkBoxLogicItemIsTrick.Checked = logicItem?.IsTrick ?? false;
            }
            finally
            {
                isRefreshing = false;
            }
        }

        private string? GetFromSelectedAndUncheck()
        {
            var selectedItem = listBoxAvailableItemId.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("No selected Id");
                return null;
            }
            listBoxAvailableItemId.SelectedIndex = -1;
            return selectedItem as string;
        }

        private void ClearAndAddList<T>(
            ListBox listBox, 
            List<T> content
            ) where T : class
        {
            var previousItem = listBox.SelectedItem;
            isRefreshing = true;
            try
            {
                listBox.BeginUpdate();
                listBox.SelectedValueChanged -= null;
                listBox.Items.Clear();
                if (content != null)
                    listBox.Items.AddRange(content.Cast<object>().ToArray());
                listBox.SelectedIndex = content?.FindIndex((it) => it == previousItem) ?? -1;
                listBox.EndUpdate();
            }
            finally
            {
                isRefreshing = false;
            }
        }

        private void DrawListBoxLineAndRect(DrawItemEventArgs e, ListBox lb, string message)
        {
            e.Graphics.FillRectangle(lb.SelectedIndex == e.Index ? Brushes.LightBlue : Brushes.White, e.Bounds);
            e.Graphics.DrawString(message, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
        }


        private void textBoxSearchLogicItemList_TextChanged(object sender, EventArgs e)
        {
            if (isRefreshing)
                return;
            var filteredList = logicFileController.logicItemListSubject.Value.Where((it) => it!.Id!.ToLower().Contains(textBoxSearchLogicItemList.Text.ToLower()));
            ClearAndAddList(listBoxLogicItemList, filteredList.ToList());
        }

        private void textBoxSearchAvailableId_TextChanged(object sender, EventArgs e)
        {
            if (isRefreshing)
                return;
            var filteredList = logicFileController.selectedLogicIdSubject.Value.Where((it) => it.ToLower().Contains(textBoxSearchAvailableId.Text.ToLower()));
            ClearAndAddList(listBoxAvailableItemId, filteredList.ToList());
        }
    }
}
