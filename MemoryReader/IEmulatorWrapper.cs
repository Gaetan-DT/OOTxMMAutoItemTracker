using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.MemoryReader
{
    interface IEmulatorWrapper
    {
        bool AttachToProcess();
    }
}
