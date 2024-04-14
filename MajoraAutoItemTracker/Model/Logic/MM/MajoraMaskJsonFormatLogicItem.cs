using System;
using System.Collections.Generic;

#nullable enable

namespace MajoraAutoItemTracker.Model.Logic.MM
{
    public class MajoraMaskJsonFormatLogicItem : AbstractsonFormatLogicItem
    {
        public override string? Id { get; set; }
        public override List<String> RequiredItems { get; set; } = new List<string>();
        public override List<List<string>> ConditionalItems { get; set; } = new List<List<string>>();
        public TimeOfDay TimeNeeded { get; set; }
        public TimeOfDay TimeAvailable { get; set; }
        public TimeOfDay TimeSetup { get; set; }
        public override bool IsTrick { get; set; }
        public string? TrickTooltip { get; set; }
        public string? TrickCategory { get; set; }
    }
}
