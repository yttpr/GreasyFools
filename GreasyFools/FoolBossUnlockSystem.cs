// Decompiled with JetBrains decompiler
// Type: GreasyFools.FoolBossUnlockSystem
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace GreasyFools
{
  public static class FoolBossUnlockSystem
  {
    public static Dictionary<EntityIDs, FoolBossUnlockSystem.FoolItemPairs> FoolsList;
    public static PerformEffectWearable fishingRod;
    public static PerformEffectWearable wormsCan;
    public static PerformEffectWithConsumeEffectWearable catfish;
    public static ExtraLootListEffect rodFish;
    public static ExtraLootListEffect canFish;
    public static ExtraLootListEffect catFish;
    private static bool fishSet = false;
    public static Dictionary<string, bool> SaveConfigNames;
    public const string ModID = "GreasyFools";
    public static AchievementGetterUIHandler Achievements;
    public static GameInformationHolder Info;
    public static UnlockablesManager Unlocks;
    public static bool CleanedData;
    public static char[] SpecialCharacters = new char[19]
    {
      '.',
      '\'',
      '!',
      '?',
      '@',
      '#',
      '$',
      '%',
      '^',
      '&',
      '*',
      '(',
      ')',
      '=',
      '+',
      '<',
      '>',
      '/',
      '\\'
    };

    public static void MassUpdateAchievements()
    {
      foreach (FoolBossUnlockSystem.FoolItemPairs foolItemPairs in FoolBossUnlockSystem.FoolsList.Values)
        foolItemPairs.Update();
    }

    public static void AddToFishPool(string ItemName, int probability)
    {
      LootItemProbability lootItemProbability = new LootItemProbability();
      if (LoadedAssetsHandler.LoadedWearables.Keys.Contains<string>(ItemName))
      {
        lootItemProbability.itemName = ItemName;
        lootItemProbability.probability = probability;
        try
        {
          if (!FoolBossUnlockSystem.fishSet)
            FoolBossUnlockSystem.SetupFish();
          FoolBossUnlockSystem.rodFish._lootableItems = new List<LootItemProbability>((IEnumerable<LootItemProbability>) FoolBossUnlockSystem.rodFish._lootableItems)
          {
            lootItemProbability
          }.ToArray();
          if ((UnityEngine.Object) FoolBossUnlockSystem.rodFish != (UnityEngine.Object) FoolBossUnlockSystem.canFish)
            FoolBossUnlockSystem.canFish._lootableItems = new List<LootItemProbability>((IEnumerable<LootItemProbability>) FoolBossUnlockSystem.canFish._lootableItems)
            {
              lootItemProbability
            }.ToArray();
          if (!((UnityEngine.Object) FoolBossUnlockSystem.catFish != (UnityEngine.Object) FoolBossUnlockSystem.rodFish) || !((UnityEngine.Object) FoolBossUnlockSystem.catFish != (UnityEngine.Object) FoolBossUnlockSystem.canFish))
            return;
          FoolBossUnlockSystem.catFish._lootableItems = new List<LootItemProbability>((IEnumerable<LootItemProbability>) FoolBossUnlockSystem.catFish._lootableItems)
          {
            lootItemProbability
          }.ToArray();
        }
        catch (Exception ex)
        {
          Debug.Log((object) ex.Message);
          Debug.Log((object) ex.StackTrace);
        }
      }
      else
        Debug.Log((object) "YOUR ITEM DOESNT EXIST MOTHERFUCKER!!!");
    }

    public static void SetupFish()
    {
      FoolBossUnlockSystem.fishingRod = LoadedAssetsHandler.GetWearable("FishingRod_TW") as PerformEffectWearable;
      FoolBossUnlockSystem.wormsCan = LoadedAssetsHandler.GetWearable("CanOfWorms_SW") as PerformEffectWearable;
      FoolBossUnlockSystem.catfish = LoadedAssetsHandler.GetWearable("WelsCatfish_ExtraW") as PerformEffectWithConsumeEffectWearable;
      FoolBossUnlockSystem.rodFish = FoolBossUnlockSystem.fishingRod.effects[0].effect as ExtraLootListEffect;
      FoolBossUnlockSystem.canFish = FoolBossUnlockSystem.wormsCan.effects[0].effect as ExtraLootListEffect;
      FoolBossUnlockSystem.catFish = FoolBossUnlockSystem.catfish._consumptionEffects[0].effect as ExtraLootListEffect;
      FoolBossUnlockSystem.fishSet = true;
    }

    private static string baseSave
    {
      get
      {
        return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";
      }
    }

    private static string pathPlus
    {
      get
      {
        if (!Directory.Exists(FoolBossUnlockSystem.baseSave + "Mods\\"))
          Directory.CreateDirectory(FoolBossUnlockSystem.baseSave + "Mods\\");
        return FoolBossUnlockSystem.baseSave + "Mods\\";
      }
    }

    public static string SavePath
    {
      get
      {
        if (!Directory.Exists(FoolBossUnlockSystem.pathPlus + "GreasyFools\\"))
          Directory.CreateDirectory(FoolBossUnlockSystem.pathPlus + "GreasyFools\\");
        return FoolBossUnlockSystem.pathPlus + "GreasyFools\\";
      }
    }

    public static string SaveName
    {
      get
      {
        if (!File.Exists(FoolBossUnlockSystem.SavePath + "GreasyFools.config"))
          FoolBossUnlockSystem.WriteConfig(FoolBossUnlockSystem.SavePath + "GreasyFools.config");
        return FoolBossUnlockSystem.SavePath + "GreasyFools.config";
      }
    }

    public static void Setup()
    {
      if (FoolBossUnlockSystem.FoolsList == null)
        FoolBossUnlockSystem.FoolsList = new Dictionary<EntityIDs, FoolBossUnlockSystem.FoolItemPairs>();
      if (FoolBossUnlockSystem.SaveConfigNames == null)
        FoolBossUnlockSystem.SaveConfigNames = new Dictionary<string, bool>();
      FoolBossUnlockSystem.SetupFish();
      FoolBossUnlockSystem.AchievementSystem.Initialize();
      FoolBossUnlockSystem.AchievementSystem.Setup();
      FoolBossUnlockSystem.CleanedData = false;
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (UnlockablesManager).GetMethod("TryBeatBossWith", ~BindingFlags.Default), typeof (FoolBossUnlockSystem).GetMethod("TryBeatBossWith", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("Start", ~BindingFlags.Default), typeof (FoolBossUnlockSystem).GetMethod("Start", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (SelectableCharactersSO).GetMethod("PrepareCharacters", ~BindingFlags.Default), typeof (FoolBossUnlockSystem).GetMethod("PrepareCharacters", ~BindingFlags.Default));
    }

    public static void TryBeatBossWith(
      Action<UnlockablesManager, BossType, EntityIDs> orig,
      UnlockablesManager self,
      BossType boss,
      EntityIDs entity)
    {
      orig(self, boss, entity);
      FoolBossUnlockSystem.Unlocks = self;
      FoolBossUnlockSystem.FoolItemPairs foolItemPairs;
      if (!FoolBossUnlockSystem.FoolsList.TryGetValue(entity, out foolItemPairs))
        return;
      Item w;
      if (foolItemPairs.unlocks.TryGetValue(boss, out w))
      {
        string key = foolItemPairs.fool + boss.ToString() + FoolBossUnlockSystem.GetItemSystemName(w);
        bool flag;
        if (FoolBossUnlockSystem.SaveConfigNames.TryGetValue(key, out flag) & flag)
          return;
        w.AddItem();
        if (foolItemPairs.autoFishPool.ContainsKey(boss))
          FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName(foolItemPairs.unlocks[boss]), foolItemPairs.autoFishPool[boss]);
        FoolBossUnlockSystem.Unlocks._freshlyAcquiredItems.Add(FoolBossUnlockSystem.GetItemName(w));
        SaveManager.SaveFreshItemsSaveData(FoolBossUnlockSystem.Unlocks._freshlyAcquiredItems);
        FoolBossUnlockSystem.SaveConfigNames[key] = true;
        FoolBossUnlockSystem.WriteConfig(FoolBossUnlockSystem.SaveName);
      }
      foolItemPairs.Update();
    }

    public static void Start(Action<MainMenuController> orig, MainMenuController self)
    {
      FoolBossUnlockSystem.MassUpdateAchievements();
      orig(self);
      FoolBossUnlockSystem.Achievements = self._achievementGetterHandler;
      FoolBossUnlockSystem.Info = self._informationHolder;
      FoolBossUnlockSystem.Unlocks = FoolBossUnlockSystem.Info.UnlockableManager;
      FoolBossUnlockSystem.ClearUnlockPanels(FoolBossUnlockSystem.Unlocks);
    }

    public static void ClearUnlockPanels(UnlockablesManager funlocks)
    {
      if (FoolBossUnlockSystem.CleanedData)
        return;
      FoolBossUnlockSystem.CleanedData = true;
      funlocks._freshlyAcquiredItems.Clear();
      SaveManager.SaveFreshItemsSaveData(funlocks._freshlyAcquiredItems);
    }

    public static string GetItemName(Item w)
    {
      string itemName = "";
      if (w.itemPools.HasFlag((Enum) ItemPools.Treasure))
        itemName = Regex.Replace(w.name + "_TW", "\\s+", "");
      else if (w.itemPools.HasFlag((Enum) ItemPools.Shop))
        itemName = Regex.Replace(w.name + "_SW", "\\s+", "");
      else if (w.itemPools.HasFlag((Enum) ItemPools.Fish))
        itemName = Regex.Replace(w.name + "_FW", "\\s+", "");
      else if (w.itemPools.HasFlag((Enum) ItemPools.Extra))
        itemName = Regex.Replace(w.name + "_EW", "\\s+", "");
      else if (w.isShopItem)
        itemName = Regex.Replace(w.name + "_SW", "\\s+", "");
      else if (!w.isShopItem)
        itemName = Regex.Replace(w.name + "_TW", "\\s+", "");
      return itemName;
    }

    public static string GetItemSystemName(Item w)
    {
      return FoolBossUnlockSystem.RemoveSpecialChars(FoolBossUnlockSystem.GetItemName(w));
    }

    public static string RemoveSpecialChars(string source)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (char ch in source)
      {
        if (!((IEnumerable<char>) FoolBossUnlockSystem.SpecialCharacters).Contains<char>(ch))
          stringBuilder.Append(ch);
      }
      return stringBuilder.ToString();
    }

    public static void WriteConfig(string location)
    {
      StreamWriter text = File.CreateText(location);
      XmlDocument xmlDocument = new XmlDocument();
      string str = "<config";
      foreach (string key in FoolBossUnlockSystem.SaveConfigNames.Keys)
      {
        str += " ";
        str += key;
        str += "='";
        str += FoolBossUnlockSystem.SaveConfigNames[key].ToString().ToLower();
        str += "'";
      }
      string xml = str + "> </config>";
      xmlDocument.LoadXml(xml);
      xmlDocument.Save((TextWriter) text);
      text.Close();
    }

    public static void PrepareCharacters(
      Action<SelectableCharactersSO, HashSet<string>> orig,
      SelectableCharactersSO self,
      HashSet<string> unlockedCharacters)
    {
      orig(self, unlockedCharacters);
      foreach (SelectableCharacterData character in self._characters)
      {
        FoolBossUnlockSystem.FoolItemPairs foolItemPairs;
        if (character.HasCharacter && FoolBossUnlockSystem.FoolsList.TryGetValue(character.LoadedCharacter.characterEntityID, out foolItemPairs))
        {
          bool flag1 = character.HasTheDivine;
          bool flag2 = character.HasTheWitness;
          BossType bossType;
          if (foolItemPairs.unlocks.Keys.Contains<BossType>((BossType) 10))
          {
            string fool = foolItemPairs.fool;
            bossType = (BossType) 10;
            string str = bossType.ToString();
            string itemSystemName = FoolBossUnlockSystem.GetItemSystemName(foolItemPairs.unlocks[(BossType) 10]);
            string key = fool + str + itemSystemName;
            bool flag3;
            FoolBossUnlockSystem.SaveConfigNames.TryGetValue(key, out flag3);
            flag1 = flag3;
          }
          if (foolItemPairs.unlocks.Keys.Contains<BossType>((BossType) 9))
          {
            string fool = foolItemPairs.fool;
            bossType = (BossType) 9;
            string str = bossType.ToString();
            string itemSystemName = FoolBossUnlockSystem.GetItemSystemName(foolItemPairs.unlocks[(BossType) 9]);
            string key = fool + str + itemSystemName;
            bool flag4;
            FoolBossUnlockSystem.SaveConfigNames.TryGetValue(key, out flag4);
            flag2 = flag4;
          }
          character.SetAchievementState(flag2, flag1);
        }
      }
      FoolBossUnlockSystem.WriteConfig(FoolBossUnlockSystem.SaveName);
    }

    public static void Example()
    {
      Character chara = new Character();
      chara.entityID = (EntityIDs) 865753;
      chara.levels = new CharacterRankedData[1];
      chara.AddLevel(10, new Ability[0], 0);
      chara.AddCharacter();
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "weebol";
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "wibil";
      new FoolBossUnlockSystem.FoolItemPairs(chara, (Item) heavenUnlock, (Item) osmanUnlock).Add();
      EffectItem unlock = new EffectItem();
      unlock.name = "waggerwol";
      unlock.itemPools = ItemPools.Fish;
      new FoolBossUnlockSystem.FoolItemPairs((EntityIDs) 69999, "Greeble", (BossType) 10, (Item) unlock, 3).Add();
      new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 77777, (AchievementUnlockType) 5, "Achievement Name", "Unlocked a new item.", ResourceLoader.LoadSprite("weebol")).Prepare((EntityIDs) 69999, (BossType) 10);
    }

    public static class AchievementSystem
    {
      public static Dictionary<Achievement, FoolBossUnlockSystem.AchievementSystem.AchieveInfo> AchievementList;
      public static int LowerBy;

      public static void Initialize()
      {
        if (FoolBossUnlockSystem.AchievementSystem.AchievementList != null)
          return;
        FoolBossUnlockSystem.AchievementSystem.AchievementList = new Dictionary<Achievement, FoolBossUnlockSystem.AchievementSystem.AchieveInfo>();
      }

      public static bool TryGetAchievement(
        EntityIDs ID,
        BossType Boss,
        out FoolBossUnlockSystem.AchievementSystem.AchieveInfo Info)
      {
        if (FoolBossUnlockSystem.AchievementSystem.AchievementList != null)
        {
          foreach (FoolBossUnlockSystem.AchievementSystem.AchieveInfo achieveInfo in FoolBossUnlockSystem.AchievementSystem.AchievementList.Values)
          {
            if (achieveInfo.Character == ID && achieveInfo.Boss == Boss)
            {
              Info = achieveInfo;
              return true;
            }
          }
        }
        Info = (FoolBossUnlockSystem.AchievementSystem.AchieveInfo) null;
        return false;
      }

      public static Achievement[] GetAchievementList(
        Func<UnlockInformationDatabase, AchievementUnlockType, Achievement[]> orig,
        UnlockInformationDatabase self,
        AchievementUnlockType type)
      {
        List<Achievement> achievementList = new List<Achievement>((IEnumerable<Achievement>) orig(self, type));
        foreach (Achievement key in FoolBossUnlockSystem.AchievementSystem.AchievementList.Keys)
        {
          if (FoolBossUnlockSystem.AchievementSystem.AchievementList[key].List == type)
            achievementList.Add(key);
        }
        return achievementList.ToArray();
      }

      public static Achievement_t GetAchievementInfo(
        Func<UnlockInformationDatabase, Achievement, Achievement_t> orig,
        UnlockInformationDatabase self,
        Achievement achID)
      {
        FoolBossUnlockSystem.AchievementSystem.AchieveInfo achieveInfo;
        return FoolBossUnlockSystem.AchievementSystem.AchievementList.TryGetValue(achID, out achieveInfo) ? achieveInfo.Info : orig(self, achID);
      }

      public static void PopulateInformation(
        Action<UnlockedAchievementsUIHandler, IGameCheckData> orig,
        UnlockedAchievementsUIHandler self,
        IGameCheckData game)
      {
        FoolBossUnlockSystem.AchievementSystem.LowerBy = 0;
        orig(self, game);
      }

      public static void TryInitializeUnlockableAchievements(
        Action<UnlockListUIPanel, int, IUnlockCalls, Sprite[]> orig,
        UnlockListUIPanel self,
        int listID,
        IUnlockCalls calls,
        Sprite[] achInfo)
      {
        Transform child1 = ((Component) self).transform.GetChild(1);
        Transform child2 = ((Component) self).transform.GetChild(0);
        Transform child3 = child1.GetChild(0);
        int num = 0;
        List<UnlockIconUILayout> unlockIconUiLayoutList;
        for (; self._icons.Length < achInfo.Length; self._icons = unlockIconUiLayoutList.ToArray())
        {
          Transform transform = UnityEngine.Object.Instantiate<Transform>(child3, child1);
          unlockIconUiLayoutList = new List<UnlockIconUILayout>((IEnumerable<UnlockIconUILayout>) self._icons);
          for (int index = 0; index < transform.childCount; ++index)
          {
            Transform child4 = transform.GetChild(index);
            unlockIconUiLayoutList.Add(child4.GetComponent<UnlockIconUILayout>());
          }
          num += 150;
        }
        RectTransform component1 = child1.GetComponent<RectTransform>();
        RectTransform component2 = ((Component) self).transform.GetComponent<RectTransform>();
        child2.GetComponent<RectTransform>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(component1);
        Vector2 sizeDelta = component2.sizeDelta;
        sizeDelta.y += (float) num;
        component2.sizeDelta = sizeDelta;
        Transform parent = ((Component) self).transform.parent;
        parent.GetComponent<ContentSizeFitter>();
        parent.GetComponent<VerticalLayoutGroup>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(parent.GetComponent<RectTransform>());
        orig(self, listID, calls, achInfo);
      }

      public static void Setup()
      {
        IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (UnlockInformationDatabase).GetMethod("GetAchievementList", ~BindingFlags.Default), typeof (FoolBossUnlockSystem.AchievementSystem).GetMethod("GetAchievementList", ~BindingFlags.Default));
        IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (UnlockInformationDatabase).GetMethod("GetAchievementInfo", ~BindingFlags.Default), typeof (FoolBossUnlockSystem.AchievementSystem).GetMethod("GetAchievementInfo", ~BindingFlags.Default));
        IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (UnlockedAchievementsUIHandler).GetMethod("PopulateInformation", ~BindingFlags.Default), typeof (FoolBossUnlockSystem.AchievementSystem).GetMethod("PopulateInformation", ~BindingFlags.Default));
        IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (UnlockListUIPanel).GetMethod("TryInitializeUnlockableAchievements", ~BindingFlags.Default), typeof (FoolBossUnlockSystem.AchievementSystem).GetMethod("TryInitializeUnlockableAchievements", ~BindingFlags.Default));
      }

      public class AchieveInfo
      {
        public Achievement ID;
        public AchievementUnlockType List;
        public string Name;
        public string Description;
        public Sprite Icon;
        public Achievement_t Info;
        public bool IsSecret;
        public string SecretDesc;
        public EntityIDs Character;
        public BossType Boss;
        public bool Unlocked;

        public AchieveInfo(
          Achievement id,
          AchievementUnlockType type,
          string name,
          string description,
          Sprite icon,
          bool secret = false,
          string secretDesc = "")
        {
          this.Unlocked = false;
          this.ID = id;
          this.List = type;
          this.Name = name;
          this.Description = description;
          this.Icon = icon;
          this.IsSecret = secret;
          this.SecretDesc = secretDesc;
          this.Info = new Achievement_t(this.ID, this.Name, this.Description)
          {
            m_unlockedSprite = this.Icon
          };
          if (!this.IsSecret)
            return;
          this.Info.m_isSecret = this.IsSecret;
          this.Info.m_strSecretDesctription = this.SecretDesc;
        }

        public void Prepare(EntityIDs character, BossType boss)
        {
          this.Character = character;
          this.Boss = boss;
          FoolBossUnlockSystem.AchievementSystem.Initialize();
          if (!FoolBossUnlockSystem.AchievementSystem.AchievementList.Keys.Contains<Achievement>(this.ID))
          {
            if (!FoolBossUnlockSystem.AchievementSystem.TryGetAchievement(character, boss, out FoolBossUnlockSystem.AchievementSystem.AchieveInfo _))
            {
              FoolBossUnlockSystem.AchievementSystem.AchievementList.Add(this.ID, this);
              Debug.Log((object) ("Prepared achievement for " + this.Name));
            }
            else
              Debug.Log((object) ("Achievement for character " + character.ToString() + " and boss type " + boss.ToString() + " already exists!"));
          }
          else
            Debug.Log((object) ("Achievement value for " + this.ID.ToString() + " already added, dont add it twice!"));
        }

        public void SetValue(bool entry)
        {
          this.Info.m_bAchieved = entry;
          this.Info.m_offlinebAchieved = entry;
          this.Unlocked = entry;
        }
      }
    }

    public class FoolItemPairs
    {
      public EntityIDs entity;
      public string fool;
      public Dictionary<BossType, Item> unlocks;
      public Dictionary<BossType, int> autoFishPool;
      public Character _apiChara;
      public CharacterSO _charaSO;

      public Character ApiChara
      {
        get
        {
          if (this._apiChara != null)
            return this._apiChara;
          Debug.Log((object) ("NULL FoolItemPairs API character: " + this.fool + " " + this.entity.ToString()));
          return new Character();
        }
      }

      public CharacterSO CharaSO
      {
        get
        {
          if ((UnityEngine.Object) this._charaSO != (UnityEngine.Object) null)
            return this._charaSO;
          foreach (CharacterSO charaSo in LoadedAssetsHandler.LoadedCharacters.Values)
          {
            if (charaSo.characterEntityID == this.entity)
            {
              this._charaSO = charaSo;
              return charaSo;
            }
          }
          Debug.Log((object) ("NULL Fool ItemPairs CharacterSO: " + this.fool + " " + this.entity.ToString()));
          return ScriptableObject.CreateInstance<CharacterSO>();
        }
      }

      public FoolItemPairs(
        Character chara,
        Item heavenUnlock,
        Item osmanUnlock,
        int heavenFishPoolWeight = 0,
        int osmanFishPoolWeight = 0)
        : this(chara)
      {
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool == null)
          this.autoFishPool = new Dictionary<BossType, int>();
        this.unlocks.Add((BossType) 10, heavenUnlock);
        if (heavenFishPoolWeight > 0)
          this.autoFishPool.Add((BossType) 10, heavenFishPoolWeight);
        this.unlocks.Add((BossType) 9, osmanUnlock);
        if (osmanFishPoolWeight <= 0)
          return;
        this.autoFishPool.Add((BossType) 9, osmanFishPoolWeight);
      }

      public FoolItemPairs(
        CharacterSO chara,
        Item heavenUnlock,
        Item osmanUnlock,
        int heavenFishPoolWeight = 0,
        int osmanFishPoolWeight = 0)
        : this(chara)
      {
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool == null)
          this.autoFishPool = new Dictionary<BossType, int>();
        this.unlocks.Add((BossType) 10, heavenUnlock);
        if (heavenFishPoolWeight > 0)
          this.autoFishPool.Add((BossType) 10, heavenFishPoolWeight);
        this.unlocks.Add((BossType) 9, osmanUnlock);
        if (osmanFishPoolWeight <= 0)
          return;
        this.autoFishPool.Add((BossType) 9, osmanFishPoolWeight);
      }

      public FoolItemPairs(
        EntityIDs id,
        string foolName,
        Item heavenUnlock,
        Item osmanUnlock,
        int heavenFishPoolWeight = 0,
        int osmanFishPoolWeight = 0)
        : this(id, foolName)
      {
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool == null)
          this.autoFishPool = new Dictionary<BossType, int>();
        this.unlocks.Add((BossType) 10, heavenUnlock);
        if (heavenFishPoolWeight > 0)
          this.autoFishPool.Add((BossType) 10, heavenFishPoolWeight);
        this.unlocks.Add((BossType) 9, osmanUnlock);
        if (osmanFishPoolWeight <= 0)
          return;
        this.autoFishPool.Add((BossType) 9, osmanFishPoolWeight);
      }

      public FoolItemPairs(
        EntityIDs id,
        string foolName,
        BossType boss,
        Item unlock,
        int fishPoolWeight = 0)
        : this(id, foolName)
      {
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool == null)
          this.autoFishPool = new Dictionary<BossType, int>();
        this.unlocks.Add(boss, unlock);
        if (fishPoolWeight <= 0)
          return;
        this.autoFishPool.Add(boss, fishPoolWeight);
      }

      public FoolItemPairs(Character chara, BossType boss, Item unlock, int fishPoolWeight = 0)
        : this(chara)
      {
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool == null)
          this.autoFishPool = new Dictionary<BossType, int>();
        this.unlocks.Add(boss, unlock);
        if (fishPoolWeight <= 0)
          return;
        this.autoFishPool.Add(boss, fishPoolWeight);
      }

      public FoolItemPairs(CharacterSO chara, BossType boss, Item unlock, int fishPoolWeight = 0)
        : this(chara)
      {
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool == null)
          this.autoFishPool = new Dictionary<BossType, int>();
        this.unlocks.Add(boss, unlock);
        if (fishPoolWeight <= 0)
          return;
        this.autoFishPool.Add(boss, fishPoolWeight);
      }

      public FoolItemPairs(Character chara)
      {
        this._apiChara = chara;
        this.entity = chara.entityID;
        this.fool = chara.name;
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool != null)
          return;
        this.autoFishPool = new Dictionary<BossType, int>();
      }

      public FoolItemPairs(CharacterSO chara)
      {
        this._charaSO = chara;
        this.entity = chara.characterEntityID;
        this.fool = chara._characterName;
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool != null)
          return;
        this.autoFishPool = new Dictionary<BossType, int>();
      }

      public FoolItemPairs(EntityIDs id, string foolName)
      {
        this.entity = id;
        this.fool = foolName;
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool != null)
          return;
        this.autoFishPool = new Dictionary<BossType, int>();
      }

      public void AddUnlock(BossType boss, Item unlock, int fishPoolWeight = 0)
      {
        if (this.unlocks == null)
          this.unlocks = new Dictionary<BossType, Item>();
        if (this.autoFishPool == null)
          this.autoFishPool = new Dictionary<BossType, int>();
        this.unlocks.Add(boss, unlock);
        if (fishPoolWeight <= 0)
          return;
        this.autoFishPool.Add(boss, fishPoolWeight);
      }

      public void Add()
      {
        if (this.fool != null)
          this.fool = Regex.Replace(this.fool, "\\s+", "");
        if (this.unlocks == null)
        {
          Debug.Log((object) "not set up yet?");
        }
        else
        {
          if (FoolBossUnlockSystem.FoolsList == null)
            FoolBossUnlockSystem.FoolsList = new Dictionary<EntityIDs, FoolBossUnlockSystem.FoolItemPairs>();
          FoolBossUnlockSystem.FoolsList.Add(this.entity, this);
          if (FoolBossUnlockSystem.SaveConfigNames == null)
            FoolBossUnlockSystem.SaveConfigNames = new Dictionary<string, bool>();
          string saveName = FoolBossUnlockSystem.SaveName;
          FileStream inStream = File.Open(FoolBossUnlockSystem.SaveName, FileMode.Open);
          XmlDocument xmlDocument = new XmlDocument();
          xmlDocument.Load((Stream) inStream);
          foreach (BossType key in this.unlocks.Keys)
          {
            string str = this.fool + key.ToString() + FoolBossUnlockSystem.GetItemSystemName(this.unlocks[key]);
            bool flag = false;
            if (xmlDocument.GetElementsByTagName("config").Count > 0)
            {
              if (xmlDocument.GetElementsByTagName("config")[0].Attributes[str] != null)
              {
                flag = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[str].Value);
                if (flag)
                {
                  this.unlocks[key].AddItem();
                  if (this.autoFishPool.ContainsKey(key))
                    FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName(this.unlocks[key]), this.autoFishPool[key]);
                  FoolBossUnlockSystem.AchievementSystem.AchieveInfo Info;
                  if (FoolBossUnlockSystem.AchievementSystem.TryGetAchievement(this.entity, key, out Info))
                    Info.SetValue(true);
                }
              }
              FoolBossUnlockSystem.SaveConfigNames.Add(str, flag);
            }
          }
          inStream.Close();
        }
      }

      public void Update()
      {
        FileStream inStream = File.Open(FoolBossUnlockSystem.SaveName, FileMode.Open);
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load((Stream) inStream);
        foreach (BossType key in this.unlocks.Keys)
        {
          string name = this.fool + key.ToString() + FoolBossUnlockSystem.GetItemSystemName(this.unlocks[key]);
          FoolBossUnlockSystem.AchievementSystem.AchieveInfo Info;
          if (xmlDocument.GetElementsByTagName("config").Count > 0 && xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null && bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value) && FoolBossUnlockSystem.AchievementSystem.TryGetAchievement(this.entity, key, out Info))
            Info.SetValue(true);
        }
        inStream.Close();
      }
    }
  }
}
