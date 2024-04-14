using System;
using System.Collections.Generic;

namespace MajoraAutoItemTracker.Model.Logic
{
    public abstract class AbstractsonFormatLogicItem
    {
        public abstract String? Id { get; set; }
        public abstract List<String> RequiredItems { get; set; }
        public abstract List<List<string>> ConditionalItems { get; set; }
        public abstract bool IsTrick { get; set; }
        public string? ReadableName = null;
        public string? HintText = null;
        public string? HintVideoUrl = null;
    }
}
