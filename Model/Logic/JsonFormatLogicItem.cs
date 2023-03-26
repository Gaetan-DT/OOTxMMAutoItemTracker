using System;
using System.Collections.Generic;
using System.IO;

namespace MajoraAutoItemTracker.Model.Logic
{
    public class JsonFormatLogicItem
    {
        public String Id { get; set; }
        public List<String> RequiredItems { get; set; } = new List<string>();
        public List<List<string>> ConditionalItems { get; set; } = new List<List<string>>();        
        public TimeOfDay TimeNeeded { get; set; }
        public TimeOfDay TimeAvailable { get; set; }
        public TimeOfDay TimeSetup { get; set; }
        public bool IsTrick { get; set; }
        public String TrickTooltip { get; set; }
        public String TrickCategory { get; set; }
    }
}
