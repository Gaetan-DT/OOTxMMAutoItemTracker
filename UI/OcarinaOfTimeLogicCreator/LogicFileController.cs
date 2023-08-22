using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.OOT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.OcarinaOfTimeLogicCreator
{
    class LogicFileController
    {
        // Variant used to get itemId of item
        List<ItemLogic> listItemLogic = null;
        List<string> listCheck = null;

        private Dictionary<string, OcarinaOfTimeJsonFormatLogicItem> finalLogicItemList;
        // List of Id available in logic class
        public BehaviorSubject<List<string>> selectedLogicIdSubject = new BehaviorSubject<List<string>>(null);

        public BehaviorSubject<List<OcarinaOfTimeJsonFormatLogicItem>> logicItemListSubject = new BehaviorSubject<List<OcarinaOfTimeJsonFormatLogicItem>>(null);
        public BehaviorSubject<OcarinaOfTimeJsonFormatLogicItem> selectedLogicItemSubject = new BehaviorSubject<OcarinaOfTimeJsonFormatLogicItem>(null);
        public BehaviorSubject<List<string>> selectedLogicItemListRequireItemListSubject = new BehaviorSubject<List<string>>(null);
        public BehaviorSubject<List<List<string>>> selectedLogicItemListListConditionalItemListSubject = new BehaviorSubject<List<List<string>>>(null);
        public BehaviorSubject<List<string>> selectedLogicItemConditionalItemContentSubject = new BehaviorSubject<List<string>>(null);

        public string selectedLogicItemId = null;
        public string selectedLogicItemListRequireItemListId = null;
        public List<string> selectedLogicItemListConditionalItemListId = null;
        public string selectedLogicItemListConditionalItemListContentId = null;

        public void InitWith(LogicFile<OcarinaOfTimeJsonFormatLogicItem> logicFile)
        {
            finalLogicItemList = logicFile.Logic.ToDictionary((it) => it.Id);
            listItemLogic = ItemLogicMethod.DeserializeOOT();
            // Init list check
            listCheck = new List<string>();
            var filePath = Application.StartupPath + @"\Resource\CheckLogic\" + OcarinaOfTimeCheckLogicCategory.CST_DEFAULT_FILE_NAME;
            var listOotCategory = OcarinaOfTimeCheckLogicCategory.LoadFromFile(filePath);
            foreach (var ootCategory in listOotCategory)
                foreach (var logicId in ootCategory.CheckLogicId)
                    listCheck.Add(logicId);
        }

        public List<OcarinaOfTimeJsonFormatLogicItem> GetListOfItemList()
        {
            return finalLogicItemList.Values.ToList();
        }

        private void RefreshAll()
        {
            List<OcarinaOfTimeJsonFormatLogicItem> newLogicItemList = finalLogicItemList.Select((it) => it.Value).ToList();
            OcarinaOfTimeJsonFormatLogicItem newSelectedLogicItem = null;
            List<string> newSelectedLogicItemListRequireItemList = null;
            List<List<string>> newSelectedLogicItemListListConditionalItemContent = null;
            List<string> newSelectedLogicItemConditionalItemContent = null;
            if (selectedLogicItemId != null)
            {
                if (finalLogicItemList.TryGetValue(selectedLogicItemId, out newSelectedLogicItem))
                {
                    newSelectedLogicItemListRequireItemList = newSelectedLogicItem.RequiredItems;
                    newSelectedLogicItemListListConditionalItemContent = newSelectedLogicItem.ConditionalItems;
                    if (selectedLogicItemListConditionalItemListId != null)
                    {
                        newSelectedLogicItemConditionalItemContent = newSelectedLogicItem.ConditionalItems.Find((it) => it == selectedLogicItemListConditionalItemListId);
                    }
                } else
                    selectedLogicItemId = null;
            }
            logicItemListSubject.OnNext(newLogicItemList);
            selectedLogicItemSubject.OnNext(newSelectedLogicItem);
            selectedLogicItemListRequireItemListSubject.OnNext(newSelectedLogicItemListRequireItemList);
            selectedLogicItemListListConditionalItemListSubject.OnNext(newSelectedLogicItemListListConditionalItemContent);
            selectedLogicItemConditionalItemContentSubject.OnNext(newSelectedLogicItemConditionalItemContent);
            RefreshListIdAvailable();
        }

        private void RefreshListIdAvailable()
        {
            var finalList = finalLogicItemList.Select((it) => it.Key).Except(listCheck).ToList();
            foreach (var itemLogic in listItemLogic)
                foreach (var itemLogicVariant in itemLogic.variants)
                {
                    if (itemLogicVariant.idLogic == null || itemLogicVariant.idLogic == "")
                        continue;
                    finalList.Add(itemLogicVariant.idLogic);
                }
            selectedLogicIdSubject.OnNext(finalList);
        }

        public void ResolveSelectedItemAndRefreshAll(
            string logicItemId = null,
            string logicItemListRequireItemListId = null,
            List<string> logicItemListConditionalItemListId = null,
            string logicItemListConditionalItemListContentId = null)
        {
            ResolveSelectedItem(
                logicItemId,
                logicItemListRequireItemListId,
                logicItemListConditionalItemListId,
                logicItemListConditionalItemListContentId);
            RefreshAll();
        }

        private void ResolveSelectedItem(
            string logicItemId = null,
            string logicItemListRequireItemListId = null,
            List<string> logicItemListConditionalItemListId = null,
            string logicItemListConditionalItemListContentId = null)
        {
            selectedLogicItemId = logicItemId;
            if (logicItemId == null)
            {
                logicItemListRequireItemListId = null;
                selectedLogicItemListRequireItemListId = null;
                logicItemListConditionalItemListId = null;
                selectedLogicItemListConditionalItemListId = null;
                logicItemListConditionalItemListContentId = null;
                selectedLogicItemListConditionalItemListContentId = null;
            }
            selectedLogicItemListRequireItemListId = logicItemListRequireItemListId;
            selectedLogicItemListConditionalItemListId = logicItemListConditionalItemListId;
            if (logicItemListConditionalItemListId == null)
            {
                logicItemListConditionalItemListContentId = null;
                selectedLogicItemListConditionalItemListContentId = null;
            }
            selectedLogicItemListConditionalItemListContentId = logicItemListConditionalItemListContentId;
        }

        public void CreateAndInsertNewItemLogic()
        {
            OcarinaOfTimeJsonFormatLogicItem newItemLogic = new OcarinaOfTimeJsonFormatLogicItem()
            {
                Id = "New itemLogic"
            };
            if (IsItemLogicAlreadyExist(newItemLogic.Id))
            {
                MessageBox.Show("Id already exist !");
                return;
            }
            finalLogicItemList.Add(newItemLogic.Id, newItemLogic);
            ResolveSelectedItemAndRefreshAll(newItemLogic.Id);
        }

        public void RemoveSelectedItemLogic()
        {
            finalLogicItemList.Remove(selectedLogicItemId);
            ResolveSelectedItemAndRefreshAll();
        }

        private bool IsItemLogicAlreadyExist(string itemId)
        {
            return finalLogicItemList
                .Select((it) => it.Key)
                .Contains(itemId);
        }

        public void SaveSelectedLogicItem(string newId, bool isTrick)
        {
            OcarinaOfTimeJsonFormatLogicItem value;
            if (finalLogicItemList.TryGetValue(selectedLogicItemId, out value))
            {
                value.Id = newId;
                value.IsTrick = isTrick;
                finalLogicItemList.Remove(selectedLogicItemId);
                finalLogicItemList.Add(value.Id, value);
            }
            ResolveSelectedItemAndRefreshAll();
        }

        public void AddSelectedLogicItemRequireItem(string itemId)
        {
            if (itemId == null)
                return;
            finalLogicItemList[selectedLogicItemId].RequiredItems.Add(itemId);
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId, 
                itemId,
                selectedLogicItemListConditionalItemListId,
                selectedLogicItemListConditionalItemListContentId);
        }

        public void UpdateSelectedLogicItemRequireItem(string itemId)
        {
            if (itemId == null)
                return;
            selectedLogicItemListRequireItemListId = itemId;
        }

        public void RemoveSelectedLogicItemRequireItem()
        {
            if (selectedLogicItemListRequireItemListId == null)
                return;
            finalLogicItemList[selectedLogicItemId].RequiredItems.Remove(selectedLogicItemListRequireItemListId);
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId, 
                null, 
                selectedLogicItemListConditionalItemListId, 
                selectedLogicItemListConditionalItemListContentId);
        }

        public void AddSelectedLogicItemConditionalItem()
        {
            var newItem = new List<string>();
            finalLogicItemList[selectedLogicItemId].ConditionalItems.Add(newItem);
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId,
                selectedLogicItemListRequireItemListId,
                newItem);
        }

        public void UpdateSelectedLogicItemConditionalItem(List<string> updatedListConditionalItem)
        {
            var listConditionalItem = finalLogicItemList[selectedLogicItemId].ConditionalItems.Find((it) => it == selectedLogicItemListConditionalItemListId);
            listConditionalItem.Clear();
            listConditionalItem.AddRange(updatedListConditionalItem);
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId,
                selectedLogicItemListRequireItemListId,
                listConditionalItem);
        }

        public void SetSelectedLogicItemConditionalItem(List<string> updatedListConditionalItem)
        {
            selectedLogicItemListConditionalItemListId = updatedListConditionalItem;
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId,
                selectedLogicItemListRequireItemListId,
                updatedListConditionalItem);
        }

        public void RemoveSelectedLogicItemConditionalItem()
        {
            finalLogicItemList[selectedLogicItemId].ConditionalItems.Remove(selectedLogicItemListConditionalItemListId);
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId,
                selectedLogicItemListRequireItemListId);
        }

        public void AddLogicItemListContionalItemContent(string itemId)
        {
            if (itemId == null)
                return;
            if (selectedLogicItemListConditionalItemListId == null)
            {
                MessageBox.Show("No conditional item list selected !");
            }
            finalLogicItemList[selectedLogicItemId].ConditionalItems.Find((it) => it == selectedLogicItemListConditionalItemListId).Add(itemId);
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId,
                selectedLogicItemListRequireItemListId,
                selectedLogicItemListConditionalItemListId,
                itemId);
        }

        public void SetSelectedLogicItemListContionalItemContent(string selectedItemId)
        {
            if (selectedItemId == null)
                return;
            selectedLogicItemListConditionalItemListContentId = selectedItemId;
        }

        public void RemoveLogicItemListContionalItemContent()
        {
            finalLogicItemList[selectedLogicItemId].ConditionalItems.Find((it) => it == selectedLogicItemListConditionalItemListId).Remove(selectedLogicItemListConditionalItemListContentId);
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId,
                selectedLogicItemListRequireItemListId,
                selectedLogicItemListConditionalItemListId);
        }

        public void IsertMissingRegionFile()
        {
            // Open file
            foreach (var logicId in listCheck)
            {
                if (!finalLogicItemList.ContainsKey(logicId))
                    finalLogicItemList.Add(logicId, new OcarinaOfTimeJsonFormatLogicItem()
                    {
                        Id = logicId,
                        IsTrick = false
                    });
            }
            ResolveSelectedItemAndRefreshAll();
        }
    }
}
