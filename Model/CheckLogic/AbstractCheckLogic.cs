using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public abstract class AbstractCheckLogic<CheckLogicZone>
    {
        public virtual String Id { get; set; }
        public virtual CheckLogicZone Zone { get; set; }
        public virtual bool IsClaim { get; set; }
        public virtual bool IsAvailable { get; set; }
    }
}
