using MajoraAutoItemTracker.Model.Item;
using System.Collections.Generic;
using System.Diagnostics;

#nullable enable

namespace MajoraAutoItemTracker.Logic
{
    abstract class AbstractLogicResolver
    {
        public bool debugMode = false;
        private int indentDebug = 0;

        #region Utilities

        protected JsonFormatLogicItem? FindLogic<JsonFormatLogicItem>(
            Dictionary<string, JsonFormatLogicItem> logicDictionary, 
            string? logicIdStr
            ) where JsonFormatLogicItem : class
        {
            if (logicIdStr == null)
            {
                Debug.WriteLine("Unable to find logic for check: " + logicIdStr);
                return null;
            }
            if (!logicDictionary.TryGetValue(logicIdStr, out JsonFormatLogicItem jsonLogicItem))
            {
                Debug.WriteLine("Unable to find logic for check: " + logicIdStr);
                return null;
            }
            return jsonLogicItem;
        }

        protected Dictionary<string, ItemLogic> ToDictionaryItemLogicList(List<ItemLogic> itemLogicList)
        {
            Dictionary<string, ItemLogic> dicItemLogic = new Dictionary<string, ItemLogic>();
            foreach (var itemLogic in itemLogicList)
                foreach (var itemLogicVariant in itemLogic.variants)
                {
                    if (itemLogicVariant.idLogic == null)
                        continue;
                    if (!dicItemLogic.ContainsKey(itemLogicVariant.idLogic)) // Can be duplicate ex:Bottle
                        dicItemLogic.Add(itemLogicVariant.idLogic, itemLogic);
                }
            return dicItemLogic;
        }

        protected void WriteToDebug(string message, bool endOfFunction)
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

        protected void WriteToDebug(string message)
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
