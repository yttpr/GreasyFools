// Decompiled with JetBrains decompiler
// Type: GreasyFools.Ragerred
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class Ragerred
  {
    public static Character Eepy;

    public static void Add()
    {
      Character self = new Character();
      self.name = nameof (Ragerred);
      self.healthColor = Pigments.Purple;
      self.entityID = (EntityIDs) 98512;
      self.frontSprite = ResourceLoader.LoadSprite("PFront");
      self.backSprite = ResourceLoader.LoadSprite("PBack");
      self.overworldSprite = ResourceLoader.LoadSprite("PWorld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      self.lockedSprite = ResourceLoader.LoadSprite("PMenu");
      self.unlockedSprite = ResourceLoader.LoadSprite("PMenu");
      self.menuChar = true;
      self.usesBaseAbility = true;
      self.usesAllAbilities = false;
      self.passives = new BasePassiveAbilitySO[1]
      {
        Passives.Pure
      };
      self.isSupport = false;
      self.appearsInShops = false;
      self.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
      self.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
      self.levels = new CharacterRankedData[4];
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("Yum");
      ability1.name = "he ate";
      ability1.description = "Eat the enemy and deal 6 damage to the opposing...?";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
      };
      ability1.effects = new Effect[1];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?((IntentType) 1), Slots.Front);
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharcater("Burnout_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("Yum");
      ability2.name = "he consumed";
      ability2.description = "Eat the enemy and deal 8 damage to the opposing...?";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
      };
      ability2.effects = new Effect[1];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 8, new IntentType?((IntentType) 2), Slots.Front);
      ability2.animationTarget = Slots.Front;
      ability2.visuals = LoadedAssetsHandler.GetCharcater("Burnout_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("Yum");
      ability3.name = "he feasted";
      ability3.description = "Eat the enemy and deal 10 damage to the opposing...?";
      ability3.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
      };
      ability3.effects = new Effect[1];
      ability3.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?((IntentType) 2), Slots.Front);
      ability3.animationTarget = Slots.Front;
      ability3.visuals = LoadedAssetsHandler.GetCharcater("Burnout_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability4 = new Ability();
      ability4.sprite = ResourceLoader.LoadSprite("Yum");
      ability4.name = "he gorged";
      ability4.description = "Eat the enemy and deal 12 damage to the opposing...?";
      ability4.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
      };
      ability4.effects = new Effect[1];
      ability4.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 12, new IntentType?((IntentType) 3), Slots.Front);
      ability4.animationTarget = Slots.Front;
      ability4.visuals = LoadedAssetsHandler.GetCharcater("Burnout_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("Zul");
      ability5.name = "he healed";
      ability5.description = "Heal this and the Left and Right party members 4 health.";
      ability5.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability5.effects = new Effect[1];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[3]
      {
        -1,
        0,
        1
      }, true));
      ability5.animationTarget = Slots.Self;
      ability5.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("Zul");
      ability6.name = "he mended";
      ability6.description = "Heal this and the Left and Right party members 6 health.";
      ability6.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability6.effects = new Effect[1];
      ability6.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 6, new IntentType?((IntentType) 21), Slots.SlotTarget(new int[3]
      {
        -1,
        0,
        1
      }, true));
      ability6.animationTarget = Slots.Self;
      ability6.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability7 = new Ability();
      ability7.sprite = ResourceLoader.LoadSprite("Zul");
      ability7.name = "he medicinized";
      ability7.description = "Heal this and the Left and Right party members 8 health.";
      ability7.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability7.effects = new Effect[1];
      ability7.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 8, new IntentType?((IntentType) 21), Slots.SlotTarget(new int[3]
      {
        -1,
        0,
        1
      }, true));
      ability7.animationTarget = Slots.Self;
      ability7.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability8 = new Ability();
      ability8.sprite = ResourceLoader.LoadSprite("Zul");
      ability8.name = "he repaired";
      ability8.description = "Heal this and the Left and Right party members 10 health.";
      ability8.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability8.effects = new Effect[1];
      ability8.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 10, new IntentType?((IntentType) 21), Slots.SlotTarget(new int[3]
      {
        -1,
        0,
        1
      }, true));
      ability8.animationTarget = Slots.Self;
      ability8.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("Slep");
      ability9.name = "sleep";
      ability9.description = "do nothing";
      ability9.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability9.effects = new Effect[1];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<OsmanEffect>(), 0, new IntentType?((IntentType) 100), Slots.Self);
      ability9.animationTarget = Slots.Self;
      ability9.visuals = ((AnimationVisualsEffect) ((PerformEffectWearable) LoadedAssetsHandler.GetWearable("DemonCore_SW")).effects[0].effect)._visuals;
      self.AddLevel(12, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      self.AddLevel(16, new Ability[3]
      {
        ability2,
        ability6,
        ability9
      }, 1);
      self.AddLevel(22, new Ability[3]
      {
        ability3,
        ability7,
        ability9
      }, 2);
      self.AddLevel(26, new Ability[3]
      {
        ability4,
        ability8,
        ability9
      }, 3);
      self.SilentAddCharacter();
      Ragerred.Eepy = self;
    }
  }
}
