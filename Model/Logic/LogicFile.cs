using Newtonsoft.Json;
using System.Collections.Generic;

namespace MajoraAutoItemTracker.Model.Logic
{
    class LogicFile
    {
        public int Version { get; set; }
        public List<JsonFormatLogicItem> Logic { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static LogicFile FromJson(string json)
        {
            var _logic = JsonConvert.DeserializeObject<LogicFile>(json);
            /*
            foreach (var logicItem in _logic.Logic)
            {
                if (System.Enum.TryParse(logicItem.Id, out Item item))
                {
                    var multiLocationAttribute = item.GetAttribute<MultiLocationAttribute>();
                    if (multiLocationAttribute != null)
                    {
                        logicItem.RequiredItems.Clear();
                        logicItem.ConditionalItems.Clear();
                        logicItem.TimeAvailable = TimeOfDay.None;
                        logicItem.TimeNeeded = TimeOfDay.None;
                        logicItem.TimeSetup = TimeOfDay.None;
                        logicItem.IsTrick = false;
                        logicItem.TrickTooltip = null;
                        foreach (var location in multiLocationAttribute.Locations)
                        {
                            logicItem.ConditionalItems.Add(new List<string> { location.ToString() });
                        }
                        logicItem.IsMultiLocation = true;
                    }
                }
            }
            */
            return _logic;
        }
    }
}
