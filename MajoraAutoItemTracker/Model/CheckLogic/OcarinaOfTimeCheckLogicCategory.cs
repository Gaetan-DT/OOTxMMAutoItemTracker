using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

#nullable enable

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public class OcarinaOfTimeCheckLogicCategory
    {
        public string? Name { get; set; }
        public int SquarePositionX { get; set; }
        public int SquarePositionY { get; set; }
        public List<string> CheckLogicId { get; set; } = new List<string>();
    }
}
