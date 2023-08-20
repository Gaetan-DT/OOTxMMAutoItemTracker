using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Logic.OOT
{
    class OcarinaOfTimeJsonFormatLogicItem
    {
        public String Id { get; set; }
        public List<String> RequiredItems { get; set; } = new List<string>();
        public List<List<string>> ConditionalItems { get; set; } = new List<List<string>>();
        public bool IsTrick { get; set; }
    }
}
