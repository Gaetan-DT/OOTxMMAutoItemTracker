using System;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum MajoraMaskItemLogicPopertyName
    {
        ImgOcarina,
        ImgBow,
        ImgFireArrow,
        ImgIceArrow,
        ImgLightArrow,
        ImgBomb,
        ImgBombchu,
        ImgStick,
        ImgNuts,
        ImgBeans,
        ImgKeg,
        ImgPicto,
        ImgLens,
        ImgHook,
        ImgGfsword,
        Imgbottle1,
        Imgbottle2,
        Imgbottle3,
        Imgbottle4,
        Imgbottle5,
        Imgbottle6,
        ImgScrubTrade,
        ImgKeyMama,
        ImgLetterpendant,
        DekuMask,
        GoronMask,
        ZoraMask,
        FiercedeityMask,
        TruthMask,
        KafeiMask,
        AllnightMask,
        BunnyhoodMask,
        KeatonMask,
        GaroMask,
        RomaniMask,
        CircusleaderMask,
        PostmanMask,
        CoupleMask,
        GreatfairyMask,
        GibdoMask,
        DonGeroMask,
        KamaroMask,
        CaptainMask,
        StoneMask,
        BremenMask,
        BlastMask,
        ScentsMask,
        GiantMask,
        ImgSword,
        ImgShield,
        ImgQuiver,
        ImgBombBag,
        ImgWallet,
        OdolwaMask,
        GohtMask,
        GyorgMask,
        TwinmoldMask,
        ImgBombersNote,
        ImgDoubleDefense,
        ImgMagic,
        SongOfTime,
        SongOfHealing,
        EponaSong,
        SongOfSoaring,
        SongOfStorm,
        SonataOfAwakening,
        GoronLullaby,
        NewWaveBossaNova,
        ElegyOfEmptyness,
        SongOathToOrder,
        SunSong,
    }

    class MajoraMaskItemLogicPopertyNameMethod
    {
        public static MajoraMaskItemLogicPopertyName FromString(string value)
        {
            return (MajoraMaskItemLogicPopertyName)System.Enum.Parse(typeof(MajoraMaskItemLogicPopertyName), value);
        }

        public static String ToString(MajoraMaskItemLogicPopertyName value)
        {
            return MajoraMaskItemLogicPopertyName.ImgOcarina.ToString();
        }
    }
}
