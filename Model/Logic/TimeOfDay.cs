using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Logic
{
    [Flags]
    public enum TimeOfDay
    {
        None,
        Day1 = 1,
        Night1 = 2,
        Day2 = 4,
        Night2 = 8,
        Day3 = 16,
        Night3 = 32,
    }
}
