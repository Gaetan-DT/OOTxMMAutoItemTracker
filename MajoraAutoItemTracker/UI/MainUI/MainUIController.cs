using Cyotek.Windows.Forms;
using MajoraAutoItemTracker.Core.Extensions;
using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;

namespace MajoraAutoItemTracker.UI.MainUI
{
    public class MainUIController
    {
        public ImageBoxController<OcarinaOfTimeCheckLogicZone>? imageBoxMapOOT;
        public ImageBoxController<MajoraMaskCheckLogicZone>? imageBoxMapMM;


        public void InitPictureBox(ImageBox imageBoxOOT, ImageBox imageBoxMM)
        {
            // Init OOT
            imageBoxMapOOT = new ImageBoxController<OcarinaOfTimeCheckLogicZone>(imageBoxOOT);
            imageBoxMapOOT.SetSrcBitmap(Ressources.Properties.Resources.oot_Map.ConvertToBitmap());
            // Init MM
            imageBoxMapMM = new ImageBoxController<MajoraMaskCheckLogicZone>(imageBoxMM);
            imageBoxMapMM.SetSrcBitmap(Ressources.Properties.Resources.mm_Map.ConvertToBitmap());
            //pictureBoxMapMM.OnGraphicPathClick += (it) => majoraMaskController.RefreshCheckListForCategory(lbCheckListOOT, it);
        }
    }
}
