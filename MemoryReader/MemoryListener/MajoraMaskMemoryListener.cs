using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.MemoryReader.ModLoader64;
using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Reactive.Subjects;
using System.Reflection;
using System.Threading;

namespace MajoraAutoItemTracker
{
    class MajoraMaskMemoryListener
    {
        private const int CST_THREAD_DELLAY = 1000;

        private readonly ModLoader64Wrapper _modLoader64Wrapper;
        private readonly MajoraMemoryDataObserver _majoraMemoryDataObserver;

        private Thread _thread;
        private bool _isThreadActive;

        private MajoraMemoryData _previousMajoraMemoryData;

        public ReplaySubject<Tuple<MajoraMaskItemLogicPopertyName, object>> OnAnyItemLogicChange = new ReplaySubject<Tuple<MajoraMaskItemLogicPopertyName, object>>(1);

        public MajoraMaskMemoryListener(
            ModLoader64Wrapper modLoader64Wrapper, 
            MajoraMemoryDataObserver majoraMemoryDataObserver)
        {
            _modLoader64Wrapper = modLoader64Wrapper;
            _majoraMemoryDataObserver = majoraMemoryDataObserver;
            AddToAnyEvent(_majoraMemoryDataObserver, OnAnyItemLogicChange);
        }

        private void AddToAnyEvent(
            MajoraMemoryDataObserver observer,
            ReplaySubject<Tuple<MajoraMaskItemLogicPopertyName, object>> replaySubject)
        {
            //observer.CurrentLinkTransformation.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            observer.MagicMeter.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgMagic, value)));
            observer.HasDoubleDefense.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgDoubleDefense, value)));
            observer.EquipmentWallet.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgWallet, value)));
            observer.EquipmentQuiver.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgQuiver, value)));
            observer.EquipmentBombBag.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBombBag, value)));
            observer.HasBombersNoteBook.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBombersNote, value)));
            observer.HasOcarina.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgOcarina, value)));
            observer.HasHeroBow.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBow, value)));
            observer.HasFireArrows.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgFireArrow, value)));
            observer.HasIceArrows.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgIceArrow, value)));
            observer.HasLightArrows.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgLightArrow, value)));
            observer.HasBomb.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBombBag, value)));
            observer.HasBombchus.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBombchu, value)));
            observer.HasDekuSticks.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgStick, value)));
            observer.HasDekuNuts.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgNuts, value)));
            observer.HasMagicBeans.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBeans, value)));
            observer.HasPowderKeg.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgKeg, value)));
            observer.HasPictographBox.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgPicto, value)));
            observer.HasLensOfTruth.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgLens, value)));
            observer.HasHookShot.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgHook, value)));
            observer.HasGreatFairySword.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgGfsword, value)));
            //observer.HasTradingItem1.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasTradingItem2.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasTradingItem3.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            observer.HasBootle1.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle1, value)));
            observer.HasBootle2.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle2, value)));
            observer.HasBootle3.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle3, value)));
            observer.HasBootle4.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle4, value)));
            observer.HasBootle5.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle5, value)));
            observer.HasBootle6.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle6, value)));
            observer.HasDekuMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.DekuMask, value)));
            observer.HasGoronMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GoronMask, value)));
            observer.HasZoraMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ZoraMask, value)));
            observer.HasFierceDeityMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.FiercedeityMask, value)));
            observer.HasPostmanHat.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.PostmanMask, value)));
            observer.HasAllNightMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.AllnightMask, value)));
            observer.HasBlastMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.BlastMask, value)));
            observer.HasStoneMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.StoneMask, value)));
            observer.HasGreatFairyMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GreatfairyMask, value)));
            observer.HasKeatonMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.KeatonMask, value)));
            observer.HasBremenMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.BremenMask, value)));
            observer.HasBunnyHood.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.BunnyhoodMask, value)));
            observer.HasDonGeroMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.DonGeroMask, value)));
            observer.HasMaskOfScents.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ScentsMask, value)));
            observer.HasRomaniMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.RomaniMask, value)));
            observer.HasCircusLeaderMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.CircusleaderMask, value)));
            observer.HasKaefiMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.KafeiMask, value)));
            observer.HasCoupleMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.CoupleMask, value)));
            observer.HasMaskOfTruth.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.TruthMask, value)));
            observer.HasKamaroMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.KamaroMask, value)));
            observer.HasGibdoMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GibdoMask, value)));
            observer.HasGaroMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GaroMask, value)));
            observer.HasCaptainHat.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.CaptainMask, value)));
            observer.HasGiantMask.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GiantMask, value)));
            //observer.HasSongOfTime.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasSongOfHealing.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasEponaSong.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasSongOfSoaring.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasSongOfStorm.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasSonataOfAwakening.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasGoronLullaby.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasNewWaveBossaNova.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasElegyOfEmptyness.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasSongOathToORder.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            observer.HasBossMaskOdolwa.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.OdolwaMask, value)));
            observer.HasBoosMaskGoht.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GohtMask, value)));
            observer.HasBoosMaskGyorg.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GyorgMask, value)));
            observer.HasBoosMaskTwinmold.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.TwinmoldMask, value)));
        }

        public void Start()
        {
            _thread = new Thread(new ThreadStart(Run));
            _thread.Start();
        }

        public void Stop()
        {
            _isThreadActive = false;
        }

        private void Run()
        {
            _isThreadActive = true;
            while (_isThreadActive)
            {
                var newMajoraMemoryData = new MajoraMemoryData(_modLoader64Wrapper);
                foreach (var field in _majoraMemoryDataObserver.GetType().GetFields())
                    CompareAndUpdateField(newMajoraMemoryData, field.Name);
                _previousMajoraMemoryData = newMajoraMemoryData;
                Thread.Sleep(CST_THREAD_DELLAY);
            }
        }

        private void CompareAndUpdateField(MajoraMemoryData newMajoraMemoryData, String fieldName)
        {            
            bool triggerEventUpdate = true;
            var newMemoryDataProp = newMajoraMemoryData.GetType().GetField(fieldName).GetValue(newMajoraMemoryData);
            if (_previousMajoraMemoryData != null && newMemoryDataProp.Equals(_previousMajoraMemoryData.GetType().GetField(fieldName).GetValue(_previousMajoraMemoryData)))
                triggerEventUpdate = false;
            if (triggerEventUpdate)
            {
                var dataObserverEvent = _majoraMemoryDataObserver.GetType().GetField(fieldName).GetValue(_majoraMemoryDataObserver);
                dataObserverEvent.GetType().InvokeMember(
                    "OnNext",
                    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, 
                    null, 
                    dataObserverEvent, 
                    new object[] { newMemoryDataProp });
            }
        }
    }
}
