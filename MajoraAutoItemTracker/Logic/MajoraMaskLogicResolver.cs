using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.MM;
using System;
using System.Collections.Generic;

#nullable enable

namespace MajoraAutoItemTracker.Logic
{
    public class MajoraMaskLogicResolver : AbstractLogicResolver
    {
        private readonly Dictionary<string, MajoraMaskJsonFormatLogicItem> _logicDictionary = new Dictionary<string, MajoraMaskJsonFormatLogicItem>();

        public MajoraMaskLogicResolver(LogicFile<MajoraMaskJsonFormatLogicItem> logicFile)
        {
            foreach (var logic in logicFile.Logic)
                if (logic.Id != null)
                    _logicDictionary.Add(logic.Id, logic);
                else
                    Console.WriteLine($"Err: Unable to load logic, id is null [{logic}]");
        }

        public List<MajoraMaskCheckLogic> UpdateCheckAndReturnListOfUpdatedCheck(
            List<ItemLogic> itemLogicList,
            List<MajoraMaskCheckLogic> checkLogicList,
            bool allowTrick)
        {
            WriteToDebug("-------- UpdateCheckForItem called ---------");
            List<MajoraMaskCheckLogic> listOfUpdatedCheck = new List<MajoraMaskCheckLogic>();
            // We receive a new list of item, we will see if we can update every check available
            foreach (var checkLogic in checkLogicList)
                if (UpdateCheckAvailable(ToDictionaryItemLogicList(itemLogicList), checkLogic, allowTrick))
                    listOfUpdatedCheck.Add(checkLogic);
            WriteToDebug("-------- UpdateCheckForItem end -------------");
            return listOfUpdatedCheck;
        }

        public void UpdateCheckForItem(
            List<ItemLogic> itemLogicList, 
            List<MajoraMaskCheckLogic> checkLogicList, 
            bool allowTrick)
        {
            WriteToDebug("-------- UpdateCheckForItem called ---------");
            // We receive a new list of item, we will see if we can update every check available
            foreach (var checkLogic in checkLogicList)
                UpdateCheckAvailable(ToDictionaryItemLogicList(itemLogicList), checkLogic, allowTrick);
            WriteToDebug("-------- UpdateCheckForItem end -------------");
        }

        private bool UpdateCheckAvailable(
            Dictionary<string, ItemLogic> dicItemLogic,
            MajoraMaskCheckLogic checkLogic, 
            bool allowTrick)
        {
            var jsonLogicItem = FindLogic(_logicDictionary, checkLogic.Id);
            if (jsonLogicItem == null)
                return false;
            var isItemLogicCanBeValidated = IsItemLogicCanBeValidated(jsonLogicItem, dicItemLogic, allowTrick, new HashSet<string>());
            if (isItemLogicCanBeValidated != checkLogic.IsAvailable)
            {
                checkLogic.IsAvailable = isItemLogicCanBeValidated;
                return true;
            }
            return false;
        }

        private bool IsItemLogicCanBeValidated(
            MajoraMaskJsonFormatLogicItem jsonLogicItem, 
            Dictionary<string, ItemLogic> dicItemLogic, 
            bool allowTrick,
            HashSet<string> recursivityCheck)
        {
            WriteToDebug($"IsItemLogicCanBeValidated {jsonLogicItem.Id} BEGIN", false);
            HashSet<string> currentRecursivityCheck = new HashSet<string>(recursivityCheck);
            // Check if the logic id has not already been added in previous validation
            if (jsonLogicItem.Id == null)
            {
                WriteToDebug($"IsItemLogicCanBeValidated {jsonLogicItem.Id} END WITH FALSE (Id is null)", true);
                return false;
            }
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

        private bool IsAnItemLogic(MajoraMaskJsonFormatLogicItem jsonLogicItem, Dictionary<string, ItemLogic> dicItemLogic, out bool isItemClaim)
        {
            if (jsonLogicItem.Id == null)
            {
                isItemClaim = false;
                return false;
            }
            // Check if it a item and get the itemLogic
            else if (dicItemLogic.TryGetValue(jsonLogicItem.Id, out ItemLogic itemLogic))
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
            MajoraMaskJsonFormatLogicItem jsonLogicItem, 
            Dictionary<string, ItemLogic> dicItemLogic,
            bool allowTrick,
            HashSet<string> recursivityCheck)
        {
            if (jsonLogicItem.Id == null) 
            { 
                return false; 
            }
            // All require item must be valid
            recursivityCheck.Add(jsonLogicItem.Id);
            if (jsonLogicItem.RequiredItems.Count == 0)
                return true;
            foreach (var requireItemId in jsonLogicItem.RequiredItems)
            {
                var requireItem = FindLogic(_logicDictionary, requireItemId);
                if (requireItem == null)
                    throw new System.Exception($"itemId did not exitst: {requireItemId}");
                if (!IsItemLogicCanBeValidated(requireItem, dicItemLogic, allowTrick, recursivityCheck))
                    return false;
            }
            return true;
        }

        private bool IsAnyConditionalItemsCanBeValidated(
            MajoraMaskJsonFormatLogicItem jsonLogicItem, 
            Dictionary<string, ItemLogic> dicItemLogic,
            bool allowTrick,
            HashSet<string> recursivityCheck)
        {
            if (jsonLogicItem.Id == null)
            {
                return false;
            }
            // Only one conditional item must be valid
            recursivityCheck.Add(jsonLogicItem.Id);
            if (jsonLogicItem.ConditionalItems.Count == 0)
                return true;
            foreach (var conditionalItemList in jsonLogicItem.ConditionalItems)
            {
                bool isConditionalItemValid = true;
                foreach (var conditionalItemId in conditionalItemList)
                {
                    var conditionalItem = FindLogic(_logicDictionary, conditionalItemId);
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
    }
}
