using Cyotek.Windows.Forms;
using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.MemoryReader.MemoryListener;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reactive.Subjects;
using System.Windows.Forms;

#nullable enable

namespace MajoraAutoItemTracker.UI.MainUI
{
    class MainUIController
    {
        private AbstractMemoryListener? memoryListener = null;
        public BehaviorSubject<bool> isMemoryListenerStartedSubject = new BehaviorSubject<bool>(false);

        public ImageBoxController<OcarinaOfTimeCheckLogicZone>? imageBoxMapOOT;
        public ImageBoxController<MajoraMaskCheckLogicZone>? imageBoxMapMM;

        public MainUIController()
        {
            isMemoryListenerStartedSubject.OnNext(false);
        }

        public void InitPictureBox(ImageBox imageBoxOOT, ImageBox imageBoxMM)
        {
            // Init OOT
            imageBoxMapOOT = new ImageBoxController<OcarinaOfTimeCheckLogicZone>(imageBoxOOT);
            imageBoxMapOOT.SetSrcBitmap(Properties.Resources.oot_Map);
            // Init MM
            imageBoxMapMM = new ImageBoxController<MajoraMaskCheckLogicZone>(imageBoxMM);
            imageBoxMapMM.SetSrcBitmap(Properties.Resources.mm_Map);
            //pictureBoxMapMM.OnGraphicPathClick += (it) => majoraMaskController.RefreshCheckListForCategory(lbCheckListOOT, it);
        }

        public bool StartMemoryListener(
            EmulatorName? emulatorName,
            RomType romType,
            Action<List<Tuple<OcarinaOfTimeItemLogicPopertyName, object>>> onOOTItemLogicChange,
            Action<List<Tuple<MajoraMaskItemLogicPopertyName, object>>> onMMItemLogicChange, 
            out string error)
        {
            if (emulatorName == null)
            {
                error = "No emulator selected";
                return false;
            }
            var emulatorWrapper = EmulatorWrapperProvider.CreateEmulatorFromEnum((EmulatorName)emulatorName);
            if (emulatorWrapper == null)
            {
                error = "No emulator selected";
                return false;
            }
            if (!emulatorWrapper.AttachToProcess(romType))
            {
                error = "Unable to attach to process emulator";
                return false;
            }
            try
            {
                memoryListener = MemoryListenerProvider.ProvideMemoryListener(
                    emulatorWrapper,
                    onOOTItemLogicChange,
                    onMMItemLogicChange,
                    romType);
                memoryListener.StartThread();
                isMemoryListenerStartedSubject.OnNext(true);
                error = "";
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
                memoryListener?.StopThread();
                memoryListener = null;
            }
            finally
            {
                isMemoryListenerStartedSubject.OnNext(false);
            }
        }
    }
}
