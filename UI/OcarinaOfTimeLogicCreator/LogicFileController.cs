using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.OOT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.UI.OcarinaOfTimeLogicCreator
{
    class LogicFileController
    {
        
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
        public string selectedLogicItemListConditionalItemListId = null;
        public string selectedLogicItemListConditionalItemListContentId = null;

        public void InitWith(LogicFile<OcarinaOfTimeJsonFormatLogicItem> logicFile)
        {
            finalLogicItemList = logicFile.Logic.ToDictionary((it) => it.Id);
        }

        public void RefreshListItemId()
        {
            selectedLogicIdSubject.OnNext(finalLogicItemList.Select((it) => it.Key).ToList());
        }

        public void RefreshAll()
        {
            List<OcarinaOfTimeJsonFormatLogicItem> newLogicItemList = finalLogicItemList.Select((it) => it.Value).ToList();
            OcarinaOfTimeJsonFormatLogicItem newSelectedLogicItem = null;
            List<string> newSelectedLogicItemListRequireItemList = null;
            List<List<string>> newSelectedLogicItemListListConditional = null;
            List<string> newSelectedLogicItemConditionalItemContent = null;
            if (selectedLogicItemId != null)
            {
                
                //var result = logicItemListSubject[selectedLogicItemId];
            }
            if (selectedLogicItemListRequireItemListId != null)
            {

            }
            if (selectedLogicItemListConditionalItemListId != null)
            {

            }
            if (selectedLogicItemListConditionalItemListContentId != null)
            {

            }

            logicItemListSubject.OnNext(newLogicItemList);
            selectedLogicItemSubject.OnNext(newSelectedLogicItem);
            selectedLogicItemListRequireItemListSubject.OnNext(newSelectedLogicItemListRequireItemList);
            selectedLogicItemListListConditionalItemListSubject.OnNext(newSelectedLogicItemListListConditional);
            selectedLogicItemConditionalItemContentSubject.OnNext(newSelectedLogicItemConditionalItemContent);
        }

        public void CreateAndInsertNewItemLogic()
        {
            OcarinaOfTimeJsonFormatLogicItem newItemLogic = new OcarinaOfTimeJsonFormatLogicItem()
            {
                Id = "New itemLogic"
            };
            if (IsItemLogicAlreadyExist(newItemLogic.Id))
                throw new Exception("Id already exist");
            finalLogicItemList.Add(newItemLogic.Id, newItemLogic);
            selectedLogicItemId = newItemLogic.Id;
            selectedLogicItemListRequireItemListId = null;
            selectedLogicItemListConditionalItemListId = null;
            selectedLogicItemListConditionalItemListContentId = null;
            RefreshAll();
        }

        private bool IsItemLogicAlreadyExist(string itemId)
        {
            return finalLogicItemList
                .Select((it) => it.Key)
                .Contains(itemId);
        }
    }
}
