using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.MemoryReader.MemoryListener;
using MajoraAutoItemTracker.MemoryReader.ModLoader64;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class MainUIController
    {
        private const string CST_MM_MAP_PATH = @"\Resource\Map\82k78q66tcha1.png";
        private const string CST_OOT_MAP_PATH = @"\Resource\Map\OOT.png";

        private AbstractMemoryListener memoryListener = null;
        public ReplaySubject<bool> isMemoryListenerStartedSubject = new ReplaySubject<bool>();
        public ReplaySubject<Tuple<MajoraMaskItemLogicPopertyName, object>> OnAnyItemLogicChange = new ReplaySubject<Tuple<MajoraMaskItemLogicPopertyName, object>>();

        public PictureBoxZoomMoveController<OcarinaOfTimeCheckLogicZone> pictureBoxMapOOT;
        public PictureBoxZoomMoveController<MajoraMaskCheckLogicZone> pictureBoxMapMM;

        public MainUIController()
        {
            isMemoryListenerStartedSubject.OnNext(false);
        }

        public void InitPictureBox(Panel panelOOT, Panel panelMM)
        {
            // Init OOT
            pictureBoxMapOOT = new PictureBoxZoomMoveController<OcarinaOfTimeCheckLogicZone>(panelOOT);
            pictureBoxMapOOT.SetSrcImage(Image.FromFile(Application.StartupPath + CST_OOT_MAP_PATH));
            // Init MM
            pictureBoxMapMM = new PictureBoxZoomMoveController<MajoraMaskCheckLogicZone>(panelMM);
            pictureBoxMapMM.SetSrcImage(Image.FromFile(Application.StartupPath + CST_MM_MAP_PATH));
            //pictureBoxMapMM.OnGraphicPathClick += (it) => majoraMaskController.RefreshCheckListForCategory(lbCheckListOOT, it);
        }

        public bool StartMemoryListener(
            AbstractRomController emulatorWrapper,
            RomType romType,
            Action<Tuple<MajoraMaskItemLogicPopertyName, object>> onItemLogicChange, 
            out string error)
        {
            error = "";
            if (emulatorWrapper == null)
            {
                error = "No emulator selected";
                return false;
            }
            if (!emulatorWrapper.AttachToProcess())
            {
                error = "Unable to attach to process emulator";
                return false;
            }
            try
            {
                memoryListener = MemoryListenerProvider.ProvideMemoryListener(emulatorWrapper, OnAnyItemLogicChange, romType);
                memoryListener.StartThread();
                OnAnyItemLogicChange.Subscribe(onItemLogicChange);
                isMemoryListenerStartedSubject.OnNext(true);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                error = e.Message;
                return false;
            }
        }

        public void StopMemoryListener()
        {
            try
            {
                memoryListener.StartThread();
                memoryListener = null;
            }
            finally
            {
                isMemoryListenerStartedSubject.OnNext(false);
            }
        }
    }
}
