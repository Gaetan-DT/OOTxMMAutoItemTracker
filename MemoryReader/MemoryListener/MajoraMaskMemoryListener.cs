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

        public ReplaySubject<Tuple<ItemLogicPopertyName, object>> OnAnyItemLogicChange = new ReplaySubject<Tuple<ItemLogicPopertyName, object>>(1);

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
            ReplaySubject<Tuple<ItemLogicPopertyName, object>> replaySubject)
        {
            //observer.CurrentLinkTransformation.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            observer.MagicMeter.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgMagic, value)));
            observer.HasDoubleDefense.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgDoubleDefense, value)));
            observer.EquipmentWallet.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgWallet, value)));
            observer.EquipmentQuiver.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgQuiver, value)));
            observer.EquipmentBombBag.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgBombBag, value)));
            observer.HasBombersNoteBook.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgBombersNote, value)));
            observer.HasOcarina.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgOcarina, value)));
            observer.HasHeroBow.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgBow, value)));
            observer.HasFireArrows.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgFireArrow, value)));
            observer.HasIceArrows.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgIceArrow, value)));
            observer.HasLightArrows.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgLightArrow, value)));
            observer.HasBomb.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgBombBag, value)));
            observer.HasBombchus.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgBombchu, value)));
            observer.HasDekuSticks.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgStick, value)));
            observer.HasDekuNuts.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgNuts, value)));
            observer.HasMagicBeans.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgBeans, value)));
            observer.HasPowderKeg.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgKeg, value)));
            observer.HasPictographBox.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgPicto, value)));
            observer.HasLensOfTruth.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgLens, value)));
            observer.HasHookShot.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgHook, value)));
            observer.HasGreatFairySword.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgGfsword, value)));
            //observer.HasTradingItem1.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasTradingItem2.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            //observer.HasTradingItem3.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            observer.HasBootle1.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.Imgbottle1, value)));
            observer.HasBootle2.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.Imgbottle2, value)));
            observer.HasBootle3.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.Imgbottle3, value)));
            observer.HasBootle4.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.Imgbottle4, value)));
            observer.HasBootle5.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.Imgbottle5, value)));
            observer.HasBootle6.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.Imgbottle6, value)));
            observer.HasDekuMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.DekuMask, value)));
            observer.HasGoronMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.GoronMask, value)));
            observer.HasZoraMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ZoraMask, value)));
            observer.HasFierceDeityMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.FiercedeityMask, value)));
            observer.HasPostmanHat.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.PostmanMask, value)));
            observer.HasAllNightMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.AllnightMask, value)));
            observer.HasBlastMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.BlastMask, value)));
            observer.HasStoneMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.StoneMask, value)));
            observer.HasGreatFairyMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.GreatfairyMask, value)));
            observer.HasKeatonMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.KeatonMask, value)));
            observer.HasBremenMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.BremenMask, value)));
            observer.HasBunnyHood.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.BunnyhoodMask, value)));
            observer.HasDonGeroMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.DonGeroMask, value)));
            observer.HasMaskOfScents.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ScentsMask, value)));
            observer.HasRomaniMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.RomaniMask, value)));
            observer.HasCircusLeaderMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.CircusleaderMask, value)));
            observer.HasKaefiMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.KafeiMask, value)));
            observer.HasCoupleMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.CoupleMask, value)));
            observer.HasMaskOfTruth.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.TruthMask, value)));
            observer.HasKamaroMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.KamaroMask, value)));
            observer.HasGibdoMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.GibdoMask, value)));
            observer.HasGaroMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.GaroMask, value)));
            observer.HasCaptainHat.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.CaptainMask, value)));
            observer.HasGiantMask.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.GiantMask, value)));
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
            observer.HasBossMaskOdolwa.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.OdolwaMask, value)));
            observer.HasBoosMaskGoht.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.GohtMask, value)));
            observer.HasBoosMaskGyorg.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.GyorgMask, value)));
            observer.HasBoosMaskTwinmold.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.TwinmoldMask, value)));
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
