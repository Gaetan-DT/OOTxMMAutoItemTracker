using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.Model
{
    class LogicResolver
    {
        private readonly Dictionary<string, JsonFormatLogicItem> _logicDictionary = new Dictionary<string, Logic.JsonFormatLogicItem>();
        public Subject<CheckLogic.CheckLogic> OnCheckUpdate { get; } = new Subject<CheckLogic.CheckLogic>();

        public bool debugMode = false;
        private int indentDebug = 0;

        public LogicResolver(LogicFile logicFile)
        {
            foreach (var logic in logicFile.Logic)
                _logicDictionary.Add(logic.Id, logic);
        }

        public void UpdateCheckForItem(List<ItemLogic> itemLogicList, List<CheckLogic.CheckLogic> checkLogicList, bool allowTrick)
        {
            WriteToDebug("-------- UpdateCheckForItem called ---------");
            // We receive a new list of item, we will see if we can update every check available
            foreach (var checkLogic in checkLogicList)
                UpdateCheckAvailable(ToDictionaryItemLogicList(itemLogicList), checkLogic, allowTrick);
            WriteToDebug("-------- UpdateCheckForItem end -------------");
        }

        private void UpdateCheckAvailable(
            Dictionary<string, ItemLogic> dicItemLogic, 
            CheckLogic.CheckLogic checkLogic, 
            bool allowTrick)
        {
            var jsonLogicItem = FindLogic(checkLogic.Id);
            if (jsonLogicItem == null)
                return;
            var isItemLogicCanBeValidated = IsItemLogicCanBeValidated(jsonLogicItem, dicItemLogic, allowTrick, new HashSet<string>());
            if (isItemLogicCanBeValidated != checkLogic.IsAvailable)
            {
                checkLogic.IsAvailable = isItemLogicCanBeValidated;
                OnCheckUpdate.OnNext(checkLogic);
            }
        }

        private bool IsItemLogicCanBeValidated(
            JsonFormatLogicItem jsonLogicItem, 
            Dictionary<string, ItemLogic> dicItemLogic, 
            bool allowTrick,
            HashSet<string> recursivityCheck)
        {
            WriteToDebug($"IsItemLogicCanBeValidated {jsonLogicItem.Id} BEGIN", false);
            HashSet<string> currentRecursivityCheck = new HashSet<string>(recursivityCheck);
            // Check if the logic id has not already been added in previous validation
            if (currentRecursivityCheck.Contains(jsonLogicItem.Id))
            {
                WriteToDebug($"IsItemLogicCanBeValidated {jsonLogicItem.Id} END WITH FALSE (Recursivity error Id has been checked twice)", true);
                return false;
            }
            // Check if we allow trick
            if (jsonLogicItem.IsTrick && !allowTrick)
            {
                WriteToDebug($"IsItemLogicCanBeValidated {jsonLogicItem.Id} END WITH FALSE (no trick allowed)", true);
                return false;
            }
            // Check if logic is an check item and we got it
            if (IsAnItemLogic(jsonLogicItem, dicItemLogic, out bool isItemLogicClaim))
            {
                WriteToDebug($"IsItemLogicCanBeValidated {jsonLogicItem.Id} END WITH {isItemLogicClaim} (item with claim check performed)", true);
                return isItemLogicClaim;
            }
                
            // Check if we have the require condition
            if (!IsRequireItemCanBeValidated(jsonLogicItem, dicItemLogic, allowTrick, currentRecursivityCheck))
            {
                WriteToDebug($"IsItemLogicCanBeValidated {jsonLogicItem.Id} END WITH FALSE (require item cannot be validated)", true);
                return false;
            }                
            // Check if we have any conditional item
            if (!IsAnyConditionalItemsCanBeValidated(jsonLogicItem, dicItemLogic, allowTrick, currentRecursivityCheck))
            {
                WriteToDebug($"IsItemLogicCanBeValidated {jsonLogicItem.Id} END WITH FALSE (conditional item cannot be validated)", true);
                return false;
            }                
            WriteToDebug($"IsItemLogicCanBeValidated {jsonLogicItem.Id} END WITH TRUE (logic without condition and not an item)", true);
            return true;
        }

        private bool IsAnItemLogic(JsonFormatLogicItem jsonLogicItem, Dictionary<string, ItemLogic> dicItemLogic, out bool isItemClaim)
        {
            // Check if it a item and get the itemLogic
            if (dicItemLogic.TryGetValue(jsonLogicItem.Id, out ItemLogic itemLogic))
            {
                isItemClaim = itemLogic.IsVariantClaim(jsonLogicItem.Id);
                return true;
            }
            else
            {
                isItemClaim = false;
                return false;
            }
        }

        private bool IsRequireItemCanBeValidated(
            JsonFormatLogicItem jsonLogicItem, 
            Dictionary<string, ItemLogic> dicItemLogic,
            bool allowTrick,
            HashSet<string> recursivityCheck)
        {
            // All require item must be valid
            recursivityCheck.Add(jsonLogicItem.Id);
            if (jsonLogicItem.RequiredItems.Count == 0)
                return true;
            foreach (var requireItemId in jsonLogicItem.RequiredItems)
            {
                var requireItem = FindLogic(requireItemId);
                if (requireItem == null)
                    throw new System.Exception($"itemId did not exitst: {requireItemId}");
                if (!IsItemLogicCanBeValidated(requireItem, dicItemLogic, allowTrick, recursivityCheck))
                    return false;
            }
            return true;
        }

        private bool IsAnyConditionalItemsCanBeValidated(
            JsonFormatLogicItem jsonLogicItem, 
            Dictionary<string, ItemLogic> dicItemLogic,
            bool allowTrick,
            HashSet<string> recursivityCheck)
        {
            // Only one conditional item must be valid
            recursivityCheck.Add(jsonLogicItem.Id);
            if (jsonLogicItem.ConditionalItems.Count == 0)
                return true;
            foreach (var conditionalItemList in jsonLogicItem.ConditionalItems)
            {
                bool isConditionalItemValid = true;
                foreach (var conditionalItemId in conditionalItemList)
                {
                    var conditionalItem = FindLogic(conditionalItemId);
                    if (conditionalItem == null)
                        throw new System.Exception($"itemId did not exitst: {conditionalItemId}");
                    isConditionalItemValid = IsItemLogicCanBeValidated(conditionalItem, dicItemLogic, allowTrick, recursivityCheck);
                    if (!isConditionalItemValid)
                        break;
                }
                if (isConditionalItemValid)
                    return true;
            }
            return false;
        }

        #region Utilities

        private JsonFormatLogicItem FindLogic(string logicIdStr)
        {
            if (!_logicDictionary.TryGetValue(logicIdStr, out JsonFormatLogicItem jsonLogicItem))
            {
                Debug.WriteLine("Unable to find logic for check: " + logicIdStr);
                return null;
            }
            return jsonLogicItem;
        }

        private Dictionary<string, ItemLogic> ToDictionaryItemLogicList(List<ItemLogic> itemLogicList)
        {
            Dictionary<string, ItemLogic> dicItemLogic = new Dictionary<string, ItemLogic>();
            foreach (var itemLogic in itemLogicList)
                foreach (var itemLogicVariant in itemLogic.variants)
                    dicItemLogic.Add(itemLogicVariant.idLogic, itemLogic);
            return dicItemLogic;
        }

        private void WriteToDebug(string message, bool endOfFunction)
        {
            if (endOfFunction)
            {
                indentDebug--;
                WriteToDebug(message);
            }
            else
            {
                WriteToDebug(message);
                indentDebug++;
            }
                
        }

        private void WriteToDebug(string message)
        {
            string intentStr = "";
            for (int i = 0; i < indentDebug; i++)
                intentStr += "\t";
            if (debugMode)
                Debug.WriteLine(intentStr + message);
        }

        #endregion
    }
}
