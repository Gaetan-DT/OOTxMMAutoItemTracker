using Newtonsoft.Json;
using System.Collections.Generic;

#nullable enable

namespace MajoraAutoItemTracker.Model.Logic
{
    public class LogicFile<JsonFormatLogicItem>
    {
        public int Version { get; set; }
        public List<JsonFormatLogicItem> Logic { get; set; } = new List<JsonFormatLogicItem>();

        public override string ToString()
        {
            return LogicFileUtils.ToJsonStr(this);
        }
    }
}
