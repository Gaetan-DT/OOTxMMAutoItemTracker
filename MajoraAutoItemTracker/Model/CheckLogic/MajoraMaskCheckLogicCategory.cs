using System.Collections.Generic;

#nullable enable

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public class MajoraMaskCheckLogicCategory
    {
        public string? Name { get; set; }
        public int SquarePositionX { get; set; }
        public int SquarePositionY { get; set; }
        public List<string> CheckLogicId { get; set; } = new List<string>();
    }
}
