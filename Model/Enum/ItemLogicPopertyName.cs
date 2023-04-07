using System;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum ItemLogicPopertyName
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
        ImgMagic
    }

    class ItemLogicPopertyNameMethod
    {
        public static ItemLogicPopertyName FromString(string value)
        {
            switch (value)
            {
                case "ImgOcarina": return ItemLogicPopertyName.ImgOcarina;
                case "ImgBow": return ItemLogicPopertyName.ImgBow;
                case "ImgFireArrow": return ItemLogicPopertyName.ImgFireArrow;
                case "ImgIceArrow": return ItemLogicPopertyName.ImgIceArrow;
                case "ImgLightArrow": return ItemLogicPopertyName.ImgLightArrow;
                case "ImgBomb": return ItemLogicPopertyName.ImgBomb;
                case "ImgBombchu": return ItemLogicPopertyName.ImgBombchu;
                case "ImgStick": return ItemLogicPopertyName.ImgStick;
                case "ImgNuts": return ItemLogicPopertyName.ImgNuts;
                case "ImgBeans": return ItemLogicPopertyName.ImgBeans;
                case "ImgKeg": return ItemLogicPopertyName.ImgKeg;
                case "ImgPicto": return ItemLogicPopertyName.ImgPicto;
                case "ImgLens": return ItemLogicPopertyName.ImgLens;
                case "ImgHook": return ItemLogicPopertyName.ImgHook;
                case "ImgGfsword": return ItemLogicPopertyName.ImgGfsword;
                case "Imgbottle1": return ItemLogicPopertyName.Imgbottle1;
                case "Imgbottle2": return ItemLogicPopertyName.Imgbottle2;
                case "Imgbottle3": return ItemLogicPopertyName.Imgbottle3;
                case "Imgbottle4": return ItemLogicPopertyName.Imgbottle4;
                case "Imgbottle5": return ItemLogicPopertyName.Imgbottle5;
                case "Imgbottle6": return ItemLogicPopertyName.Imgbottle6;
                case "ImgScrubTrade": return ItemLogicPopertyName.ImgScrubTrade;
                case "ImgKeyMama": return ItemLogicPopertyName.ImgKeyMama;
                case "ImgLetterpendant": return ItemLogicPopertyName.ImgLetterpendant;
                case "DekuMask": return ItemLogicPopertyName.DekuMask;
                case "GoronMask": return ItemLogicPopertyName.GoronMask;
                case "ZoraMask": return ItemLogicPopertyName.ZoraMask;
                case "FiercedeityMask": return ItemLogicPopertyName.FiercedeityMask;
                case "TruthMask": return ItemLogicPopertyName.TruthMask;
                case "KafeiMask": return ItemLogicPopertyName.KafeiMask;
                case "AllnightMask": return ItemLogicPopertyName.AllnightMask;
                case "BunnyhoodMask": return ItemLogicPopertyName.BunnyhoodMask;
                case "KeatonMask": return ItemLogicPopertyName.KeatonMask;
                case "GaroMask": return ItemLogicPopertyName.GaroMask;
                case "RomaniMask": return ItemLogicPopertyName.RomaniMask;
                case "CircusleaderMask": return ItemLogicPopertyName.CircusleaderMask;
                case "PostmanMask": return ItemLogicPopertyName.PostmanMask;
                case "CoupleMask": return ItemLogicPopertyName.CoupleMask;
                case "GreatfairyMask": return ItemLogicPopertyName.GreatfairyMask;
                case "GibdoMask": return ItemLogicPopertyName.GibdoMask;
                case "DonGeroMask": return ItemLogicPopertyName.DonGeroMask;
                case "KamaroMask": return ItemLogicPopertyName.KamaroMask;
                case "CaptainMask": return ItemLogicPopertyName.CaptainMask;
                case "StoneMask": return ItemLogicPopertyName.StoneMask;
                case "BremenMask": return ItemLogicPopertyName.BremenMask;
                case "BlastMask": return ItemLogicPopertyName.BlastMask;
                case "ScentsMask": return ItemLogicPopertyName.ScentsMask;
                case "GiantMask": return ItemLogicPopertyName.GiantMask;
                case "ImgSword": return ItemLogicPopertyName.ImgSword;
                case "ImgShield": return ItemLogicPopertyName.ImgShield;
                case "ImgQuiver": return ItemLogicPopertyName.ImgQuiver;
                case "ImgBombBag": return ItemLogicPopertyName.ImgBombBag;
                case "ImgWallet": return ItemLogicPopertyName.ImgWallet;
                case "OdolwaMask": return ItemLogicPopertyName.OdolwaMask;
                case "GohtMask": return ItemLogicPopertyName.GohtMask;
                case "GyorgMask": return ItemLogicPopertyName.GyorgMask;
                case "TwinmoldMask": return ItemLogicPopertyName.TwinmoldMask;
                case "ImgBombersNote": return ItemLogicPopertyName.ImgBombersNote;
                case "ImgDoubleDefense": return ItemLogicPopertyName.ImgDoubleDefense;
                case "ImgMagic": return ItemLogicPopertyName.ImgMagic;
                default: throw new Exception($"Unknown property name: {value}");
            }
        }

        public static String ToString(ItemLogicPopertyName value)
        {
            switch (value)
            {
                case ItemLogicPopertyName.ImgOcarina: return "ImgOcarina";
                case ItemLogicPopertyName.ImgBow: return "ImgBow";
                case ItemLogicPopertyName.ImgFireArrow: return "ImgFireArrow";
                case ItemLogicPopertyName.ImgIceArrow: return "ImgIceArrow";
                case ItemLogicPopertyName.ImgLightArrow: return "ImgLightArrow";
                case ItemLogicPopertyName.ImgBomb: return "ImgBomb";
                case ItemLogicPopertyName.ImgBombchu: return "ImgBombchu";
                case ItemLogicPopertyName.ImgStick: return "ImgStick";
                case ItemLogicPopertyName.ImgNuts: return "ImgNuts";
                case ItemLogicPopertyName.ImgBeans: return "ImgBeans";
                case ItemLogicPopertyName.ImgKeg: return "ImgKeg";
                case ItemLogicPopertyName.ImgPicto: return "ImgPicto";
                case ItemLogicPopertyName.ImgLens: return "ImgLens";
                case ItemLogicPopertyName.ImgHook: return "ImgHook";
                case ItemLogicPopertyName.ImgGfsword: return "ImgGfsword";
                case ItemLogicPopertyName.Imgbottle1: return "Imgbottle1";
                case ItemLogicPopertyName.Imgbottle2: return "Imgbottle2";
                case ItemLogicPopertyName.Imgbottle3: return "Imgbottle3";
                case ItemLogicPopertyName.Imgbottle4: return "Imgbottle4";
                case ItemLogicPopertyName.Imgbottle5: return "Imgbottle5";
                case ItemLogicPopertyName.Imgbottle6: return "Imgbottle6";
                case ItemLogicPopertyName.ImgScrubTrade: return "ImgScrubTrade";
                case ItemLogicPopertyName.ImgKeyMama: return "ImgKeyMama";
                case ItemLogicPopertyName.ImgLetterpendant: return "ImgLetterpendant";
                case ItemLogicPopertyName.DekuMask: return "DekuMask";
                case ItemLogicPopertyName.GoronMask: return "GoronMask";
                case ItemLogicPopertyName.ZoraMask: return "ZoraMask";
                case ItemLogicPopertyName.FiercedeityMask: return "FiercedeityMask";
                case ItemLogicPopertyName.TruthMask: return "TruthMask";
                case ItemLogicPopertyName.KafeiMask: return "KafeiMask";
                case ItemLogicPopertyName.AllnightMask: return "AllnightMask";
                case ItemLogicPopertyName.BunnyhoodMask: return "BunnyhoodMask";
                case ItemLogicPopertyName.KeatonMask: return "KeatonMask";
                case ItemLogicPopertyName.GaroMask: return "GaroMask";
                case ItemLogicPopertyName.RomaniMask: return "RomaniMask";
                case ItemLogicPopertyName.CircusleaderMask: return "CircusleaderMask";
                case ItemLogicPopertyName.PostmanMask: return "PostmanMask";
                case ItemLogicPopertyName.CoupleMask: return "CoupleMask";
                case ItemLogicPopertyName.GreatfairyMask: return "GreatfairyMask";
                case ItemLogicPopertyName.GibdoMask: return "GibdoMask";
                case ItemLogicPopertyName.DonGeroMask: return "DonGeroMask";
                case ItemLogicPopertyName.KamaroMask: return "KamaroMask";
                case ItemLogicPopertyName.CaptainMask: return "CaptainMask";
                case ItemLogicPopertyName.StoneMask: return "StoneMask";
                case ItemLogicPopertyName.BremenMask: return "BremenMask";
                case ItemLogicPopertyName.BlastMask: return "BlastMask";
                case ItemLogicPopertyName.ScentsMask: return "ScentsMask";
                case ItemLogicPopertyName.GiantMask: return "GiantMask";
                case ItemLogicPopertyName.ImgSword: return "ImgSword";
                case ItemLogicPopertyName.ImgShield: return "ImgShield";
                case ItemLogicPopertyName.ImgQuiver: return "ImgQuiver";
                case ItemLogicPopertyName.ImgBombBag: return "ImgBombBag";
                case ItemLogicPopertyName.ImgWallet: return "ImgWallet";
                case ItemLogicPopertyName.OdolwaMask: return "OdolwaMask";
                case ItemLogicPopertyName.GohtMask: return "GohtMask";
                case ItemLogicPopertyName.GyorgMask: return "GyorgMask";
                case ItemLogicPopertyName.TwinmoldMask: return "TwinmoldMask";
                case ItemLogicPopertyName.ImgBombersNote: return "ImgBombersNote";
                case ItemLogicPopertyName.ImgDoubleDefense: return "ImgDoubleDefense";
                case ItemLogicPopertyName.ImgMagic: return "ImgMagic";
                default: return "";
            }
        }
    }
}
