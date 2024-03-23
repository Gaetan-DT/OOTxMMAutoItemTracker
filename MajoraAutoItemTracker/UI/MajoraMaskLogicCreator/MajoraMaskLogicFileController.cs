using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;

#nullable enable

namespace MajoraAutoItemTracker.UI.MajoraMaskLogicCreator
{
    class MajoraMaskLogicFileController
    {
        // Variant used to get itemId of item
        List<ItemLogic>? listItemLogic = null;
        List<string>? listCheck = null;

        private Dictionary<string?, MajoraMaskJsonFormatLogicItem>? finalLogicItemList;
        // List of Id available in logic class
        public BehaviorSubject<List<string>> selectedLogicIdSubject = new BehaviorSubject<List<string>>(new List<string>());

        public BehaviorSubject<List<MajoraMaskJsonFormatLogicItem>> logicItemListSubject = 
            new BehaviorSubject<List<MajoraMaskJsonFormatLogicItem>>(new List<MajoraMaskJsonFormatLogicItem>());

        public BehaviorSubject<MajoraMaskJsonFormatLogicItem?> selectedLogicItemSubject = 
            new BehaviorSubject<MajoraMaskJsonFormatLogicItem?>(null);

        public BehaviorSubject<List<string>> selectedLogicItemListRequireItemListSubject = 
            new BehaviorSubject<List<string>>(new List<string>());

        public BehaviorSubject<List<List<string>>> selectedLogicItemListListConditionalItemListSubject = 
            new BehaviorSubject<List<List<string>>>(new List<List<string>>());

        public BehaviorSubject<List<string>> selectedLogicItemConditionalItemContentSubject = 
            new BehaviorSubject<List<string>>(new List<string>());

        public string? selectedLogicItemId = null;
        public string? selectedLogicItemListRequireItemListId = null;
        public List<string>? selectedLogicItemListConditionalItemListId = null;
        public string? selectedLogicItemListConditionalItemListContentId = null;

        public void InitWith(LogicFile<MajoraMaskJsonFormatLogicItem> logicFile)
        {
            finalLogicItemList = logicFile.Logic.ToDictionary((it) => it.Id);
            listItemLogic = ItemLogicMethod.LoadMajoraMaskItemLogicFromRessource();
            // Init list check
            listCheck = new List<string>();
            var listOotCategory = CheckLogicCategoryUtils.LoadMajoraMaskFromRessource();
            foreach (var ootCategory in listOotCategory)
                foreach (var logicId in ootCategory.CheckLogicId)
                    listCheck.Add(logicId);
        }

        public List<MajoraMaskJsonFormatLogicItem> GetListOfItemList()
        {
            if (finalLogicItemList == null)
            {
                Console.WriteLine("ERROR: finalLogicItemList not initialized");
                return new List<MajoraMaskJsonFormatLogicItem>();
            }
            return finalLogicItemList.Values.ToList();
        }

        private void RefreshAll()
        {
            List<MajoraMaskJsonFormatLogicItem> newLogicItemList = finalLogicItemList
                ?.Select((it) => it.Value)
                ?.ToList()
                ?? new List<MajoraMaskJsonFormatLogicItem>();
            MajoraMaskJsonFormatLogicItem? newSelectedLogicItem = null;
            List<string>? newSelectedLogicItemListRequireItemList = null;
            List<List<string>>? newSelectedLogicItemListListConditionalItemContent = null;
            List<string>? newSelectedLogicItemConditionalItemContent = null;
            if (selectedLogicItemId != null)
            {
                if (finalLogicItemList?.TryGetValue(selectedLogicItemId, out newSelectedLogicItem) ?? false)
                {
                    newSelectedLogicItemListRequireItemList = newSelectedLogicItem.RequiredItems;
                    newSelectedLogicItemListListConditionalItemContent = newSelectedLogicItem.ConditionalItems;
                    if (selectedLogicItemListConditionalItemListId != null)
                    {
                        newSelectedLogicItemConditionalItemContent = newSelectedLogicItem
                            .ConditionalItems
                            .Find((it) => it == selectedLogicItemListConditionalItemListId);
                    }
                } else
                    selectedLogicItemId = null;
            }
            logicItemListSubject.OnNext(newLogicItemList);
            if (newSelectedLogicItem != null)
                selectedLogicItemSubject.OnNext(newSelectedLogicItem);
            if (newSelectedLogicItemListRequireItemList != null)
                selectedLogicItemListRequireItemListSubject.OnNext(newSelectedLogicItemListRequireItemList);
            if (newSelectedLogicItemListListConditionalItemContent != null)
                selectedLogicItemListListConditionalItemListSubject.OnNext(newSelectedLogicItemListListConditionalItemContent);
            if (newSelectedLogicItemConditionalItemContent != null)
                selectedLogicItemConditionalItemContentSubject.OnNext(newSelectedLogicItemConditionalItemContent);
            RefreshListIdAvailable();
        }

        private void RefreshListIdAvailable()
        {
            if (listItemLogic == null)
            {
                Console.WriteLine("ERROR: listItemLogic is null");
                return;
            }
            var finalList = finalLogicItemList
                ?.Select((it) => it.Key)
                /*.Except(listCheck)*/
                ?.ToList()
                ?? new List<string?>();
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
            string? logicItemId = null,
            string? logicItemListRequireItemListId = null,
            List<string>? logicItemListConditionalItemListId = null,
            string? logicItemListConditionalItemListContentId = null)
        {
            ResolveSelectedItem(
                logicItemId,
                logicItemListRequireItemListId,
                logicItemListConditionalItemListId,
                logicItemListConditionalItemListContentId);
            RefreshAll();
        }

        private void ResolveSelectedItem(
            string? logicItemId = null,
            string? logicItemListRequireItemListId = null,
            List<string>? logicItemListConditionalItemListId = null,
            string? logicItemListConditionalItemListContentId = null)
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
            MajoraMaskJsonFormatLogicItem newItemLogic = new MajoraMaskJsonFormatLogicItem()
            {
                Id = "New itemLogic"
            };
            if (IsItemLogicAlreadyExist(newItemLogic.Id))
            {
                MessageBox.Show("Id already exist !");
                return;
            }
            finalLogicItemList?.Add(newItemLogic.Id, newItemLogic);
            ResolveSelectedItemAndRefreshAll(newItemLogic.Id);
        }

        public void RemoveSelectedItemLogic()
        {
            if (selectedLogicItemId == null)
            {
                Console.WriteLine("ERROR: RemoveSelectedItemLogic: selectedLogicItemId is null");
                return;
            }
            finalLogicItemList?.Remove(selectedLogicItemId);
            ResolveSelectedItemAndRefreshAll();
        }

        private bool IsItemLogicAlreadyExist(string itemId)
        {
            return finalLogicItemList
                ?.Select((it) => it.Key)
                ?.Contains(itemId)
                ?? false;
        }

        public void SaveSelectedLogicItem(string newId, bool isTrick)
        {
            if (selectedLogicItemId == null)
            {
                Console.WriteLine("ERROR: SaveSelectedLogicItem: selectedLogicItemId is null");
                return;
            }
            if (finalLogicItemList?.TryGetValue(
                selectedLogicItemId, 
                out MajoraMaskJsonFormatLogicItem? value) ?? false)
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
            if (finalLogicItemList == null)
                return;
            if (selectedLogicItemId == null)
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
            if (finalLogicItemList == null || selectedLogicItemId == null)
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
            if (finalLogicItemList == null || selectedLogicItemId == null)
                return;
            var newItem = new List<string>();
            finalLogicItemList[selectedLogicItemId].ConditionalItems.Add(newItem);
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId,
                selectedLogicItemListRequireItemListId,
                newItem);
        }

        public void UpdateSelectedLogicItemConditionalItem(List<string> updatedListConditionalItem)
        {
            if (finalLogicItemList == null || selectedLogicItemId == null)
                return;
            var listConditionalItem = finalLogicItemList[selectedLogicItemId]
                .ConditionalItems
                .Find((it) => it == selectedLogicItemListConditionalItemListId)
                ?? new List<string>();
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
            if (finalLogicItemList == null || selectedLogicItemId == null || selectedLogicItemListConditionalItemListId == null)
                return;
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
            if (finalLogicItemList == null || selectedLogicItemId == null)
                return;
            finalLogicItemList[selectedLogicItemId]
                .ConditionalItems
                .Find((it) => it == selectedLogicItemListConditionalItemListId)
                ?.Add(itemId);
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
            if (finalLogicItemList == null || selectedLogicItemId == null || selectedLogicItemListConditionalItemListContentId == null)
                return;
            finalLogicItemList[selectedLogicItemId]
                .ConditionalItems
                .Find((it) => it == selectedLogicItemListConditionalItemListId)
                ?.Remove(selectedLogicItemListConditionalItemListContentId);
            ResolveSelectedItemAndRefreshAll(
                selectedLogicItemId,
                selectedLogicItemListRequireItemListId,
                selectedLogicItemListConditionalItemListId);
        }

        public void IsertMissingRegionFile()
        {
            if (listCheck == null)
            {
                Console.WriteLine("ERROR: IsertMissingRegionFile: listCheck is null");
                return;
            }
            if (finalLogicItemList == null)
            {
                Console.WriteLine("ERROR: IsertMissingRegionFile: finalLogicItemList is null");
                return;
            }
            // Open file
            foreach (var logicId in listCheck)
            {
                if (!finalLogicItemList.ContainsKey(logicId))
                    finalLogicItemList.Add(logicId, new MajoraMaskJsonFormatLogicItem()
                    {
                        Id = logicId,
                        IsTrick = false
                    });
            }
            ResolveSelectedItemAndRefreshAll();
        }

        public void InsertMissingItemIdInIdLogic()
        {
            if (listItemLogic == null)
            {
                Console.WriteLine("ERROR: InsertMissingItemIdInIdLogic: listItemLogic is null");
                return;
            }
            
            if (finalLogicItemList == null)
            {
                Console.WriteLine("ERROR: InsertMissingItemIdInIdLogic: finalLogicItemList is null");
                return;
            }
            foreach (var itemLogic in listItemLogic)
                foreach (ItemLogicVariant itemLogicVariant in itemLogic.variants)
                {
                    if (itemLogicVariant.idLogic == null)
                        continue;
                    if (!finalLogicItemList.ContainsKey(itemLogicVariant.idLogic))
                        finalLogicItemList.Add(itemLogicVariant.idLogic, new MajoraMaskJsonFormatLogicItem()
                        {
                            Id = itemLogicVariant.idLogic,
                            IsTrick = false
                        });
                }
            ResolveSelectedItemAndRefreshAll();
        }
    }
}
