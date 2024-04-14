using System;
using System.Collections.Generic;

namespace MajoraAutoItemTracker.Model.Logic.OOT
{
    public class OcarinaOfTimeJsonFormatLogicItem : AbstractsonFormatLogicItem
    {
        public override string? Id { get; set; }
        public override List<String> RequiredItems { get; set; } = new List<string>();
        public override List<List<string>> ConditionalItems { get; set; } = new List<List<string>>();
        public override bool IsTrick { get; set; }
    }
}
