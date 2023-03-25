using MajoraAutoItemTracker.Model.Check;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.Model
{
    class LogicResolver
    {
        private Dictionary<string, JsonFormatLogicItem> _logicDictionary = new Dictionary<string, Logic.JsonFormatLogicItem>();
        public Subject<CheckLogic> OnCheckUpdate { get; } = new Subject<CheckLogic>();

        public LogicResolver(LogicFile logicHeader)
        {
            foreach (var logic in logicHeader.Logic)
                _logicDictionary.Add(logic.Id, logic);
        }

        private Logic.JsonFormatLogicItem FindLogic(string logicId)
        {
            Logic.JsonFormatLogicItem logic;
            if (!_logicDictionary.TryGetValue(logicId, out logic))
            {
                Debug.WriteLine("Unable to find logic for check: " + logicId);
                return null;
            }
            return logic;
        }

        public void UpdateCheckForItem(List<ItemLogic> itemLogics, List<CheckLogic> checkLogics)
        {
            Dictionary<string, ItemLogicVariant> dictionaryItemVariant = new Dictionary<string, ItemLogicVariant>();
            foreach (var itemLogic in itemLogics)
                foreach (var itemLogicVariant in itemLogic.variants)
                    dictionaryItemVariant.Add(itemLogicVariant.idLogic, itemLogicVariant);
            // We receive a new list of item, we will see if we can update every check available
            foreach (var checkLogic in checkLogics)
                UpdateCheckAvailable(dictionaryItemVariant, checkLogic);
        }

        private void UpdateCheckAvailable(Dictionary<string, ItemLogicVariant> items, CheckLogic check)
        {
            var checkLogic = FindLogic(check.Id);
            if (checkLogic == null)
                return;
            var isItemLogicCanBeValidated = IsItemLogicCanBeValidated(checkLogic, items);
            if (isItemLogicCanBeValidated != check.IsAvailable)
            {
                check.IsAvailable = IsItemLogicCanBeValidated(checkLogic, items);
                OnCheckUpdate.OnNext(check);
            }
        }

        private bool IsItemLogicCanBeValidated(Logic.JsonFormatLogicItem logic, Dictionary<string, ItemLogicVariant> items)
        {
            // Check the logic if the condition to make the logic are true
            ItemLogicVariant itemLogic;

            // Check if logic is item and we got it
            if (items.TryGetValue(logic.Id, out itemLogic) && itemLogic.hasItem)
                return true;

            // Check if we have the require condition
            if (!IsRequireItemCanBeValidated(logic, items))
                return false;

            // Check if we have any conditional item
            if (!IsAnyConditionalItemsCanBeValidated(logic, items))
                return false;

            return true;
        }

        private bool IsRequireItemCanBeValidated(Logic.JsonFormatLogicItem logic, Dictionary<string, ItemLogicVariant> items)
        {
            // All require item must be valid
            if (logic.RequiredItems.Count == 0)
                return true;
            foreach (var requireItemId in logic.RequiredItems)
            {
                var requireItem = FindLogic(requireItemId);
                if (requireItem == null)
                    throw new System.Exception($"itemId did not exitst: {requireItemId}");
                if (!IsItemLogicCanBeValidated(requireItem, items))
                    return false;
            }
            return true;
        }

        private bool IsAnyConditionalItemsCanBeValidated(Logic.JsonFormatLogicItem logic, Dictionary<string, ItemLogicVariant> items)
        {
            // Only one conditional item must be valid
            if (logic.ConditionalItems.Count == 0)
                return true;
            foreach (var conditionalItemList in logic.ConditionalItems)
            {
                bool isConditionalItemValid = true;
                foreach (var conditionalItemId in conditionalItemList)
                {
                    var conditionalItem = FindLogic(conditionalItemId);
                    if (conditionalItem == null)
                        throw new System.Exception($"itemId did not exitst: {conditionalItemId}");
                    isConditionalItemValid = IsItemLogicCanBeValidated(conditionalItem, items);
                    if (isConditionalItemValid == false)
                        break;
                }
                if (isConditionalItemValid)
                    return true;
            }
            return false;
        }
    }
}
