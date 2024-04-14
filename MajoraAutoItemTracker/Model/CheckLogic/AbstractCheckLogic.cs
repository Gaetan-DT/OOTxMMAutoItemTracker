using System.Diagnostics.CodeAnalysis;

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public abstract class AbstractCheckLogic<CheckLogicZone>
    {
        public virtual string? Id { get; set; }
        [MaybeNull, AllowNull]
        public virtual CheckLogicZone Zone { get; set; }
        public virtual bool IsClaim { get; set; }
        public virtual bool IsAvailable { get; set; }

        public override string ToString()
        {
            return $"Id={Id} " +
                $"Zone={Zone} " +
                $"IsClaim={IsClaim} " +
                $"IsAvailable={IsAvailable} ";
        }
    }
}
