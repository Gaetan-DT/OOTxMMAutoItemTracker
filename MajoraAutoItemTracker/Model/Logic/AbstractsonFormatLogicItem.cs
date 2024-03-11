using System;
using System.Collections.Generic;

#nullable enable

namespace MajoraAutoItemTracker.Model.Logic
{
    public abstract class AbstractsonFormatLogicItem
    {
        public abstract String? Id { get; set; }
        public abstract List<String> RequiredItems { get; set; }
        public abstract List<List<string>> ConditionalItems { get; set; }
        public abstract bool IsTrick { get; set; }
    }
}
