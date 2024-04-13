using MajoraAutoItemTracker.MemoryReader.MemoryListener;
using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Diagnostics;
using System.Reactive.Subjects;
using MajoraAutoItemTracker.Core.Utils;
using MajoraAutoItemTracker.Model.CheckLogic;
using System.Windows.Forms;


namespace MajoraAutoItemTracker.UI.InitConfig
{
    internal class InitConfigController
    {

        public ReplaySubject<string> rsOotStartAddress = new ReplaySubject<string>(1);
        public ReplaySubject<string> rsMmStartAddress = new ReplaySubject<string>(1);

        public BehaviorSubject<CheckSaveFormatHeader?> rsCheckSave = new BehaviorSubject<CheckSaveFormatHeader?>(null);

        public InitConfigController()
        {
            rsOotStartAddress.OnNext(RomUtils.GetStoredMemoryAddress(CurrentRom.OcarinaOfTIme).ToString("X"));
            rsMmStartAddress.OnNext(RomUtils.GetStoredMemoryAddress(CurrentRom.MajoraMask).ToString("X"));
            rsCheckSave.OnNext(CheckItemUtils.GetCheckSaveFromMemoryOrNull());
        }

        public void ResetMemoryAddress(CurrentRom currentRom)
        {
            RomUtils.UpdateStoredMemoryAddress(currentRom, 0);
            switch (currentRom)
            {
                case CurrentRom.OcarinaOfTIme:
                    rsOotStartAddress.OnNext(RomUtils.GetStoredMemoryAddress(CurrentRom.OcarinaOfTIme).ToString("X"));
                    break;
                case CurrentRom.MajoraMask:
                    rsMmStartAddress.OnNext(RomUtils.GetStoredMemoryAddress(CurrentRom.MajoraMask).ToString("X"));
                    break; 
            }
        }

        public void LoadCheckFromFile()
        {
            var checkSave = CheckItemUtils.LoadFromFile();
            if (checkSave != null)
            {
                rsCheckSave.OnNext(checkSave);
            }
        }

        public void ResetCheckSave()
        {
            if (MessageBox.Show(
                "Clear check ?",
                "Clear check ?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rsCheckSave.OnNext(null);
            }
        }


        public AbstractMemoryListener? GetMemoryListenerOrNull(
            EmulatorName? emulatorName,
            RomType? romType,
            CurrentRom currentRom,
            out string error)
        {
            if (emulatorName == null)
            {
                error = "No emulator selected";
                return null;
            }
            if (romType == null)
            {
                error = "Unknown rom type";
                return null;
            }
            var emulatorWrapper = EmulatorWrapperProvider.CreateEmulatorFromEnum((EmulatorName)emulatorName,currentRom);
            if (emulatorWrapper == null)
            {
                error = "No emulator selected";
                return null;
            }
            if (!emulatorWrapper.AttachToProcess(romType.Value))
            {
                error = "Unable to attach to process emulator";
                return null;
            }
            try
            {
                error = "";
                return MemoryListenerProvider.ProvideMemoryListener(emulatorWrapper, romType.Value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                error = e.Message;
                return null;
            }
        }

    }
}
