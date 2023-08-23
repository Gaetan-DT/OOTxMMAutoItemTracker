using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemWallet
    {
        ItemDefaultWallet,
        ItemAdultWallet,
        ItemGiantWallet
    }

    class OotItemWalletMethod
    {
        public static OotItemWallet FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }

        public static OotItemWallet FromString(string item)
        {
            throw new Exception("Not yet implemented");
        }

        public static string ToString(OotItemWallet item)
        {
            throw new Exception("Not yet implemented");
        }
    }
}
