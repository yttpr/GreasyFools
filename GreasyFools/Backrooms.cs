// Decompiled with JetBrains decompiler
// Type: GreasyFools.Backrooms
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class Backrooms
  {
    public static AssetBundle Assets;
    public static YarnProgram Yarn;
    public static Material Mat;
    public const string Path = "Assets/Raams/";
    public static string[] Hard = new string[3]
    {
      "ZoneDB_Hard_01",
      "ZoneDB_Hard_02",
      "ZoneDB_Hard_03"
    };
    public static string[] Easy = new string[3]
    {
      "ZoneDB_01",
      "ZoneDB_02",
      "ZoneDB_03"
    };

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("LoadOldRun", ~BindingFlags.Default), typeof (Backrooms).GetMethod("LoadOldRun", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("OnEmbarkPressed", ~BindingFlags.Default), typeof (Backrooms).GetMethod("LoadOldRun", ~BindingFlags.Default));
      Backrooms.Assets = PymnHere.Assets;
      Backrooms.Yarn = Backrooms.Assets.LoadAsset<YarnProgram>("Assets/Raams/greasy.yarn");
      Backrooms.Mat = ((BaseRoomItem) ((LoadedAssetsHandler.GetRoomPrefab((CardType) 300, LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour").encounterRoom) as NPCRoomHandler)._npcSelectable as BasicRoomItem))._renderers[0].material;
      Backrooms.Calibrate();
      Backrooms.Add();
    }

    public static void LoadOldRun(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
      Backrooms.Add();
    }

    public static void Calibrate()
    {
      try
      {
        GourdRoom.Setup();
      }
      catch
      {
        Debug.LogError((object) "GourdRoom freefool fail setup");
      }
      try
      {
        OathsRoom.Setup();
      }
      catch
      {
        Debug.LogError((object) "OathsRoom freefool fail setup");
      }
      try
      {
        FelRoom.Setup();
      }
      catch
      {
        Debug.LogError((object) "FelRoom freefool fail setup");
      }
      try
      {
        QuorellRoom.Setup();
      }
      catch
      {
        Debug.LogError((object) "QuorellRoom freefool fail setup");
      }
      try
      {
        BiersalRoom.Setup();
      }
      catch
      {
        Debug.LogError((object) "BiersalRoom freefool fail setup");
      }
      try
      {
        DerekRoom.Setup();
      }
      catch
      {
        Debug.LogError((object) "DerekRoom freefool fail setup");
      }
      try
      {
        RedRagerRoom.Setup();
      }
      catch
      {
        Debug.LogError((object) "RedRagerRoom freefool fail setup");
      }
      try
      {
        StainRoom.Setup();
      }
      catch
      {
        Debug.LogError((object) "StainRoom freefool fail setup");
      }
    }

    public static void Add()
    {
      try
      {
        GourdRoom.Add();
      }
      catch
      {
        Debug.LogError((object) "GourdRoom freefool fail add");
      }
      try
      {
        OathsRoom.Add();
      }
      catch
      {
        Debug.LogError((object) "OathsRoom freefool fail add");
      }
      try
      {
        FelRoom.Add();
      }
      catch
      {
        Debug.LogError((object) "FelRoom freefool fail add");
      }
      try
      {
        QuorellRoom.Add();
      }
      catch
      {
        Debug.LogError((object) "QuorellRoom freefool fail add");
      }
      try
      {
        BiersalRoom.Add();
      }
      catch
      {
        Debug.LogError((object) "BiersalRoom freefool fail add");
      }
      try
      {
        DerekRoom.Add();
      }
      catch
      {
        Debug.LogError((object) "DerekRoom freefool fail add");
      }
      try
      {
        RedRagerRoom.Add();
      }
      catch
      {
        Debug.LogError((object) "RedRagerRoom freefool fail add");
      }
      try
      {
        StainRoom.Add();
      }
      catch
      {
        Debug.LogError((object) "StainRoom freefool fail add");
      }
    }

    public static void AddPool(string name, int zone)
    {
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB(Backrooms.Easy[zone]) as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB(Backrooms.Hard[zone]) as ZoneBGDataBaseSO;
      if (!((IEnumerable<string>) zoneDb2._FreeFoolsPool).Contains<string>(name))
        zoneDb2._FreeFoolsPool = new List<string>((IEnumerable<string>) zoneDb2._FreeFoolsPool)
        {
          name
        }.ToArray();
      if (((IEnumerable<string>) zoneDb1._FreeFoolsPool).Contains<string>(name))
        return;
      zoneDb1._FreeFoolsPool = new List<string>((IEnumerable<string>) zoneDb1._FreeFoolsPool)
      {
        name
      }.ToArray();
    }

    public static void MoreFool(string zone)
    {
      CardTypeInfo cardTypeInfo = new CardTypeInfo();
      cardTypeInfo._cardInfo = new CardInfo()
      {
        cardType = (CardType) 204,
        pilePosition = (PilePositionType) 2
      };
      cardTypeInfo._minimumAmount = 40;
      cardTypeInfo._maximumAmount = 40;
      ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
      List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb._deckInfo._possibleCards)
      {
        cardTypeInfo
      };
      zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
    }

    public static void BoostFoolAll()
    {
      foreach (string zone in Backrooms.Hard)
        Backrooms.MoreFool(zone);
      foreach (string zone in Backrooms.Easy)
        Backrooms.MoreFool(zone);
    }
  }
}
