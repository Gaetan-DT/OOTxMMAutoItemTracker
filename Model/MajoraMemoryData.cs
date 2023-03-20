using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker
{
    using Model.Enum;

    class MajoraMemoryData
    {
        public LinkTransformation currentLinkTransformation = Model.Enum.LinkTransformation.Human;

        public void UdpateStateData(ModLoader64Wrapper mModLoader64Wrapper)
        {
            currentLinkTransformation = LinkTransformationMethods.ReadFromMemory(mModLoader64Wrapper.readInt8(MMOffsets.CURRENT_TRANSFORMATION));
        }
    }
}
