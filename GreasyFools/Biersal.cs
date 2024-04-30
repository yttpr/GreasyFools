// Decompiled with JetBrains decompiler
// Type: GreasyFools.Biersal
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class Biersal
  {
    public static Character bagger;

    public static void Add()
    {
      Character character = new Character();
      character.name = nameof (Biersal);
      character.healthColor = Pigments.Red;
      character.entityID = (EntityIDs) 49917;
      character.levels = new CharacterRankedData[4];
      character.frontSprite = ResourceLoader.LoadSprite("BiersalFront");
      character.backSprite = ResourceLoader.LoadSprite("BiersalBack");
      character.overworldSprite = ResourceLoader.LoadSprite("BiersalWorld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = ResourceLoader.LoadSprite("BiersalMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("BiersalMenu");
      character.menuChar = true;
      character.usesBaseAbility = true;
      character.isSupport = false;
      character.usesAllAbilities = false;
      character.appearsInShops = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").dxSound;
      PreviousEffectCondition instance1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance1.wasSuccessful = true;
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("Tussle", 1);
      ability1.name = "Blind Murur";
      ability1.description = "Deal 8 damage to the Opposing enemy.\nExcess damage is dealt to another enemy.";
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability1.effects = new Effect[1];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DirectRandomSplitDamage>(), 8, new IntentType?((IntentType) 2), Slots.Front);
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharcater("Griffin_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("Tussle", 1);
      ability2.name = "Blind Rumble";
      ability2.description = "Deal 12 damage to the Opposing enemy.\nExcess damage is dealt indirectly to another random enemy.";
      ability2.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability2.effects = new Effect[1];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DirectRandomSplitDamage>(), 12, new IntentType?((IntentType) 3), Slots.Front);
      ability2.animationTarget = Slots.Front;
      ability2.visuals = LoadedAssetsHandler.GetCharcater("Griffin_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("Tussle", 1);
      ability3.name = "Blind Tussle";
      ability3.description = "Deal 14 damage to the Opposing enemy.\nExcess damage is dealt indirectly to another random enemy.";
      ability3.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability3.effects = new Effect[1];
      ability3.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RandomSplitDamageEffect>(), 14, new IntentType?((IntentType) 3), Slots.Front);
      ability3.animationTarget = Slots.Front;
      ability3.visuals = LoadedAssetsHandler.GetCharcater("Griffin_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability4 = new Ability();
      ability4.sprite = ResourceLoader.LoadSprite("Tussle", 1);
      ability4.name = "Blind Brawl";
      ability4.description = "Deal 16 damage to the Opposing enemy.\nExcess damage is dealt indirectly to another random enemy.";
      ability4.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability4.effects = new Effect[1];
      ability4.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RandomSplitDamageEffect>(), 16, new IntentType?((IntentType) 4), Slots.Front);
      ability4.animationTarget = Slots.Front;
      ability4.visuals = LoadedAssetsHandler.GetCharcater("Griffin_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("Splitter", 1);
      ability5.name = "Cruel Splitter";
      ability5.description = "Deal 6 damage to the Opposing enemy.\nIf this attack kills deal 5 damage to the Left and Right enemies.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability5.effects = new Effect[2];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?((IntentType) 1), Slots.Front);
      ((DamageEffect) ability5.effects[0]._effect)._returnKillAsSuccess = true;
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?((IntentType) 1), Slots.LeftRight, (EffectConditionSO) instance1);
      ability5.animationTarget = Slots.Front;
      ability5.visuals = CustomVisuals.GetVisuals("Greasy/Splitter");
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("Splitter", 1);
      ability6.name = "Ruthless Splitter";
      ability6.description = "Deal 6 damage to the Opposing enemy.\nIf this attack kills deal 8 damage to the Left and Right enemies.";
      ability6.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability6.effects = new Effect[2];
      ability6.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?((IntentType) 1), Slots.Front);
      ((DamageEffect) ability6.effects[0]._effect)._returnKillAsSuccess = true;
      ability6.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 8, new IntentType?((IntentType) 2), Slots.LeftRight, (EffectConditionSO) instance1);
      ability6.animationTarget = Slots.Front;
      ability6.visuals = CustomVisuals.GetVisuals("Greasy/Splitter");
      Ability ability7 = new Ability();
      ability7.sprite = ResourceLoader.LoadSprite("Splitter", 1);
      ability7.name = "Unforgiving Splitter";
      ability7.description = "Deal 8 damage to the Opposing enemy.\nIf this attack kills deal 11 damage to the Left and Right enemies.";
      ability7.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability7.effects = new Effect[2];
      ability7.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 8, new IntentType?((IntentType) 2), Slots.Front);
      ((DamageEffect) ability7.effects[0]._effect)._returnKillAsSuccess = true;
      ability7.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 11, new IntentType?((IntentType) 3), Slots.LeftRight, (EffectConditionSO) instance1);
      ability7.animationTarget = Slots.Front;
      ability7.visuals = CustomVisuals.GetVisuals("Greasy/Splitter");
      Ability ability8 = new Ability();
      ability8.sprite = ResourceLoader.LoadSprite("Splitter", 1);
      ability8.name = "Killer Splitter";
      ability8.description = "Deal 8 damage to the Opposing enemy.\nIf this attack kills deal 14 damage to the Left and Right enemies.";
      ability8.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability8.effects = new Effect[2];
      ability8.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 8, new IntentType?((IntentType) 2), Slots.Front);
      ((DamageEffect) ability8.effects[0]._effect)._returnKillAsSuccess = true;
      ability8.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 14, new IntentType?((IntentType) 3), Slots.LeftRight, (EffectConditionSO) instance1);
      ability8.animationTarget = Slots.Front;
      ability8.visuals = CustomVisuals.GetVisuals("Greasy/Splitter");
      DamageBasedOnHealthColor instance2 = ScriptableObject.CreateInstance<DamageBasedOnHealthColor>();
      instance2.manaDamages = new DamageifPigment[3]
      {
        new DamageifPigment(Pigments.Blue, 12),
        new DamageifPigment(Pigments.Yellow, 12),
        new DamageifPigment(Pigments.Purple, 10)
      };
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("Brute", 1);
      ability9.name = "Mighty Brute";
      ability9.description = "If the Opposing enemy health color is either Blue or Yellow deal 12 damage, if Purple deal 10 damage, if Red or Gray deal 6 damage.";
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Purple)
      };
      ability9.effects = new Effect[1];
      ability9.effects[0] = new Effect((EffectSO) instance2, 6, new IntentType?((IntentType) 4), Slots.Front);
      ability9.animationTarget = Slots.Front;
      ability9.visuals = CustomVisuals.GetVisuals("Greasy/Brute");
      DamageBasedOnHealthColor instance3 = ScriptableObject.CreateInstance<DamageBasedOnHealthColor>();
      instance3.manaDamages = new DamageifPigment[4]
      {
        new DamageifPigment(Pigments.Blue, 16),
        new DamageifPigment(Pigments.Yellow, 16),
        new DamageifPigment(Pigments.Purple, 12),
        new DamageifPigment(Pigments.Red, 8)
      };
      Ability ability10 = new Ability();
      ability10.sprite = ResourceLoader.LoadSprite("Brute", 1);
      ability10.name = "Savage Brute";
      ability10.description = "If the Opposing enemy health color is either Blue or Yellow deal 16 damage, if Purple deal 12 damage, if Red deal 8 damage, if Gray deal 6 damage.";
      ability10.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Purple)
      };
      ability10.effects = new Effect[1];
      ability10.effects[0] = new Effect((EffectSO) instance3, 6, new IntentType?((IntentType) 5), Slots.Front);
      ability10.animationTarget = Slots.Front;
      ability10.visuals = CustomVisuals.GetVisuals("Greasy/Brute");
            DamageBasedOnHealthColor instance4 = ScriptableObject.CreateInstance<DamageBasedOnHealthColor>();
      instance4.manaDamages = new DamageifPigment[4]
      {
        new DamageifPigment(Pigments.Blue, 20),
        new DamageifPigment(Pigments.Yellow, 20),
        new DamageifPigment(Pigments.Purple, 15),
        new DamageifPigment(Pigments.Red, 10)
      };
      Ability ability11 = new Ability();
      ability11.sprite = ResourceLoader.LoadSprite("Brute", 1);
      ability11.name = "Merciless Brute";
      ability11.description = "If the Opposing enemy health color is either Blue or Yellow deal 20 damage, if Purple deal 15 damage, if Red deal 10 damage, if Gray deal 6 damage.";
      ability11.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Purple)
      };
      ability11.effects = new Effect[1];
      ability11.effects[0] = new Effect((EffectSO) instance4, 6, new IntentType?((IntentType) 5), Slots.Front);
      ability11.animationTarget = Slots.Front;
      ability11.visuals = CustomVisuals.GetVisuals("Greasy/Brute");
            DamageBasedOnHealthColor instance5 = ScriptableObject.CreateInstance<DamageBasedOnHealthColor>();
      instance5.manaDamages = new DamageifPigment[4]
      {
        new DamageifPigment(Pigments.Blue, 22),
        new DamageifPigment(Pigments.Yellow, 22),
        new DamageifPigment(Pigments.Purple, 20),
        new DamageifPigment(Pigments.Red, 12)
      };
      Ability ability12 = new Ability();
      ability12.sprite = ResourceLoader.LoadSprite("Brute", 1);
      ability12.name = "Merciless Brute";
      ability12.description = "If the Opposing enemy health color is either Blue or Yellow deal 22 damage, if Purple deal 20 damage, if Red deal 12 damage, if Gray deal 6 damage.";
      ability12.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Purple)
      };
      ability12.effects = new Effect[1];
      ability12.effects[0] = new Effect((EffectSO) instance5, 6, new IntentType?((IntentType) 5), Slots.Front);
      ability12.animationTarget = Slots.Front;
      ability12.visuals = CustomVisuals.GetVisuals("Greasy/Brute");
            character.AddLevel(12, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(14, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(16, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(18, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Biersal.bagger = character;
    }
  }
}
