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

        public void UpdateCheckForItem(List<ItemLogic> itemLogics, List<CheckLogic> checkLogics, bool allowTrick)
        {
            Dictionary<string, ItemLogicVariant> dictionaryItemVariant = new Dictionary<string, ItemLogicVariant>();
            foreach (var itemLogic in itemLogics)
                foreach (var itemLogicVariant in itemLogic.variants)
                    dictionaryItemVariant.Add(itemLogicVariant.idLogic, itemLogicVariant);
            // We receive a new list of item, we will see if we can update every check available
            foreach (var checkLogic in checkLogics)
                UpdateCheckAvailable(dictionaryItemVariant, checkLogic, allowTrick);
        }

        private void UpdateCheckAvailable(Dictionary<string, ItemLogicVariant> items, CheckLogic check, bool allowTrick)
        {
            var checkLogic = FindLogic(check.Id);
            if (checkLogic == null)
                return;
            var isItemLogicCanBeValidated = IsItemLogicCanBeValidated(checkLogic, items, allowTrick, new HashSet<string>());
            if (isItemLogicCanBeValidated != check.IsAvailable)
            {
                check.IsAvailable = isItemLogicCanBeValidated;
                OnCheckUpdate.OnNext(check);
            }
        }

        private bool IsItemLogicCanBeValidated(
            JsonFormatLogicItem logic, 
            Dictionary<string, ItemLogicVariant> items, 
            bool allowTrick,
            HashSet<string> recursivityCheck)
        {
            HashSet<string> currentRecursivityCheck = new HashSet<string>(recursivityCheck);
            // Check if the logic id has not already been added in previous validation
            if (currentRecursivityCheck.Contains(logic.Id))
            {
                Debug.WriteLine($"Recursivity error: Logic Id:{logic.Id} has been checked twice");
                return false;
            }
            // Check if we allow trick
            if (logic.IsTrick && !allowTrick)
                return false;
            // Check if logic is item and we got it
            if (items.TryGetValue(logic.Id, out ItemLogicVariant itemLogic) && itemLogic.hasItem) 
                return true;
            // Check if we have the require condition
            if (!IsRequireItemCanBeValidated(logic, items, allowTrick, currentRecursivityCheck)) 
                return false;
            // Check if we have any conditional item
            if (!IsAnyConditionalItemsCanBeValidated(logic, items, allowTrick, currentRecursivityCheck)) 
                return false;

            return true;
        }

        private bool IsRequireItemCanBeValidated(
            JsonFormatLogicItem logic, 
            Dictionary<string, ItemLogicVariant> items,
            bool allowTrick,
            HashSet<string> recursivityCheck)
        {
            // All require item must be valid
            recursivityCheck.Add(logic.Id);
            if (logic.RequiredItems.Count == 0)
                return true;
            foreach (var requireItemId in logic.RequiredItems)
            {
                var requireItem = FindLogic(requireItemId);
                if (requireItem == null)
                    throw new System.Exception($"itemId did not exitst: {requireItemId}");
                if (!IsItemLogicCanBeValidated(requireItem, items, allowTrick, recursivityCheck))
                    return false;
            }
            return true;
        }

        private bool IsAnyConditionalItemsCanBeValidated(
            JsonFormatLogicItem logic, 
            Dictionary<string, ItemLogicVariant> items,
            bool allowTrick,
            HashSet<string> recursivityCheck)
        {
            // Only one conditional item must be valid
            recursivityCheck.Add(logic.Id);
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
                    isConditionalItemValid = IsItemLogicCanBeValidated(conditionalItem, items, allowTrick, recursivityCheck);
                    if (!isConditionalItemValid)
                        break;
                }
                if (isConditionalItemValid)
                    return true;
            }
            return false;
        }
    }
}
