using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.OOT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Logic
{
    class OcarinaOfTimeLogicResolver : AbstractLogicResolver
    {
        protected readonly Dictionary<string, OcarinaOfTimeJsonFormatLogicItem> _logicDictionary = new Dictionary<string, OcarinaOfTimeJsonFormatLogicItem>();

        public OcarinaOfTimeLogicResolver(LogicFile<OcarinaOfTimeJsonFormatLogicItem> logicFile)
        {
            foreach (var logic in logicFile.Logic)
                _logicDictionary.Add(logic.Id, logic);
        }

        public List<OcarinaOfTimeCheckLogic> UpdateCheckAndReturnListOfUpdatedCheck(
            List<ItemLogic> itemLogicList, 
            List<OcarinaOfTimeCheckLogic> checkLogicList, 
            bool allowTrick)
        {
            WriteToDebug("-------- UpdateCheckForItem called ---------");
            List<OcarinaOfTimeCheckLogic> listOfUpdatedCheck = new List<OcarinaOfTimeCheckLogic>();
            // We receive a new list of item, we will see if we can update every check available
            foreach (var checkLogic in checkLogicList)
                if (UpdateCheckAvailable(ToDictionaryItemLogicList(itemLogicList), checkLogic, allowTrick))
                    listOfUpdatedCheck.Add(checkLogic);
            WriteToDebug("-------- UpdateCheckForItem end -------------");
            return listOfUpdatedCheck;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dicItemLogic"></param>
        /// <param name="checkLogic"></param>
        /// <param name="allowTrick"></param>
        /// <returns>True if the check has been updated, otherwise false</returns>
        private bool UpdateCheckAvailable(
            Dictionary<string, ItemLogic> dicItemLogic,
            OcarinaOfTimeCheckLogic checkLogic,
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
            OcarinaOfTimeJsonFormatLogicItem jsonLogicItem,
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

        private bool IsAnItemLogic(OcarinaOfTimeJsonFormatLogicItem jsonLogicItem, Dictionary<string, ItemLogic> dicItemLogic, out bool isItemClaim)
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
            OcarinaOfTimeJsonFormatLogicItem jsonLogicItem,
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
                var requireItem = FindLogic(_logicDictionary, requireItemId);
                if (requireItem == null)
                    throw new System.Exception($"itemId did not exitst: {requireItemId}");
                if (!IsItemLogicCanBeValidated(requireItem, dicItemLogic, allowTrick, recursivityCheck))
                    return false;
            }
            return true;
        }

        private bool IsAnyConditionalItemsCanBeValidated(
            OcarinaOfTimeJsonFormatLogicItem jsonLogicItem,
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
