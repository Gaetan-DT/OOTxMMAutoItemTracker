#nullable enable

using System.Linq;

namespace MajoraAutoItemTracker.Model.Item
{
    public class ItemLogic
    {
        public string? displayName { get; set; }

        public string? propertyName { get; set; }

        public ItemLogicVariant[] variants { get; set; } = new ItemLogicVariant[0];

        public bool hasItem { get; set; }

        public uint ItemCount { get; set; } 

        public int CurrentVariant { get; set; }

        public string? GetVariantIdLogicOrNull()
        {
            if (CurrentVariant >= 0 && CurrentVariant < variants.Length)
                return variants[CurrentVariant].idLogic;
            else
                return null;
        }

        public bool IsVariantClaim(string idStr)
        {
            // Check if we have the item
            if (!hasItem)
                return false;
            // Check if we have the correct variant or any superior variant for the json
            for (int variant = CurrentVariant; variant >= 0; variant--)
                if (variants[variant].idLogic == idStr)
                    return true; // we have the correct variant or higher
            return false; // We didn't have the correct variant
        }

        public override string ToString()
        {
            return $"{displayName} " +
                $"hasItem={hasItem} " +
                $"ItemCount={ItemCount} " +
                $"CurrentVariant={CurrentVariant}" +
                $"variants={variants}";
        }
    }
}
