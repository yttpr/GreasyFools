// Decompiled with JetBrains decompiler
// Type: GreasyFools.RedRager
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BepInEx;
using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class RedRager : BaseUnityPlugin
  {
    public static Character angy;

    public static void Add()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (RedRager).GetMethod("AddOtherStoredValue", ~BindingFlags.Default), (object) typeof (RedRager).GetMethod("AddStoredValue", ~BindingFlags.Default));
      PreviousEffectCondition instance1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance1.wasSuccessful = true;
      PreviousEffectCondition instance2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance2.wasSuccessful = false;
      PerformEffectPassiveAbility instance3 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance3)._passiveName = "Sleepy Rager";
      ((BasePassiveAbilitySO) instance3).passiveIcon = ResourceLoader.LoadSprite("sleepstatus", 1);
      ((BasePassiveAbilitySO) instance3).type = (PassiveAbilityTypes) 78261;
      ((BasePassiveAbilitySO) instance3)._enemyDescription = "THIS MF IS NOT SLEEPY";
      ((BasePassiveAbilitySO) instance3)._characterDescription = "So sleepy.";
      ((BasePassiveAbilitySO) instance3).specialStoredValue = (UnitStoredValueNames) 84512;
            CasterStoredValueChangeEffect awake = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            awake._valueName = (UnitStoredValueNames)84512;
            awake._minimumValue = 0;
            awake._increase = false;
      instance3.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<RedRagerRefreashCheckEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<RedRagerSleepValueEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance2),
        new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance1),
        new Effect(awake, 1, null, Slots.Self, EZEffects.DidThat<PreviousEffectCondition>(true, 1))
      });
      ((BasePassiveAbilitySO) instance3)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 14
      };
      CasterStoredValueChangeEffect instance4 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance4._minimumValue = 0;
      instance4._valueName = (UnitStoredValueNames) 84512;
      instance4._increase = true;
      CasterStoredValueChangeEffect instance5 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance5._minimumValue = 0;
      instance5._valueName = (UnitStoredValueNames) 94512;
      instance5._increase = true;
      Character character = new Character();
      character.name = nameof (RedRager);
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 78220;
      character.levels = new CharacterRankedData[4];
      character.frontSprite = ResourceLoader.LoadSprite("RedRagerFront");
      character.backSprite = ResourceLoader.LoadSprite("RedRagerBack");
      character.overworldSprite = ResourceLoader.LoadSprite("RagerRedWorld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = ResourceLoader.LoadSprite("RagerRedMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("RagerRedMenu");
      character.menuChar = true;
      character.usesBaseAbility = true;
      character.isSupport = false;
      character.usesAllAbilities = false;
      character.appearsInShops = true;
      character.hurtSound = "event:/Greasy/Rager/RagerHurt";
      character.deathSound = "event:/Greasy/Rager/RagerDeath";
      character.dialogueSound = "event:/Greasy/Rager/RagerTalk";
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance3
      };
      ExtraCCSprites_BasicSO instance6 = ScriptableObject.CreateInstance<ExtraCCSprites_BasicSO>();
      instance6._useDefault = (ExtraSpriteType) 0;
      instance6._useSpecial = (ExtraSpriteType) 78261;
      instance6._frontSprite = ResourceLoader.LoadSprite("RedRagerOMEGA_Front.png");
      instance6._backSprite = ResourceLoader.LoadSprite("RedRagerOMEGA_Back.png");
      character.extraSprites = (ExtraCharacterCombatSpritesSO) instance6;
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("gorge", 1);
      ability1.name = "Quick Gorge";
      ability1.description = "Deal 4 damage to the Opposing enemy.\nIf this kills, refresh this party member.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
      };
      ability1.effects = new Effect[2];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 4, new IntentType?((IntentType) 1), Slots.Front);
      ((DamageEffect) ability1.effects[0]._effect)._returnKillAsSuccess = true;
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) instance1);
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharcater("Pearl_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("gorge", 1);
      ability2.name = "Intense Gorge";
      ability2.description = "Deal 6 damage to the Opposing enemy.\nIf this kills, refresh this party member.";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
      };
      ability2.effects = new Effect[2];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?((IntentType) 1), Slots.Front);
      ((DamageEffect) ability2.effects[0]._effect)._returnKillAsSuccess = true;
      ability2.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) instance1);
      ability2.animationTarget = Slots.Front;
      ability2.visuals = LoadedAssetsHandler.GetCharcater("Pearl_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("gorge", 1);
      ability3.name = "Crazy Gorge";
      ability3.description = "Deal 8 damage to the Opposing enemy.\nIf this kills, refresh this party member.";
      ability3.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
      };
      ability3.effects = new Effect[2];
      ability3.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 8, new IntentType?((IntentType) 2), Slots.Front);
      ((DamageEffect) ability3.effects[0]._effect)._returnKillAsSuccess = true;
      ability3.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) instance1);
      ability3.animationTarget = Slots.Front;
      ability3.visuals = LoadedAssetsHandler.GetCharcater("Pearl_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability4 = new Ability();
      ability4.sprite = ResourceLoader.LoadSprite("gorge", 1);
      ability4.name = "THE Gorge";
      ability4.description = "Deal 9 damage to the Opposing enemy.\nIf this kills, refresh this party member.";
      ability4.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
      };
      ability4.effects = new Effect[2];
      ability4.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 9, new IntentType?((IntentType) 1), Slots.Front);
      ((DamageEffect) ability4.effects[0]._effect)._returnKillAsSuccess = true;
      ability4.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) instance1);
      ability4.animationTarget = Slots.Front;
      ability4.visuals = LoadedAssetsHandler.GetCharcater("Pearl_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("sleep", 1);
      ability5.name = "Goofy Sleep";
      ability5.description = "Goes to sleep.\nApply 2 shield to this party member's current position and heal them 1 health.\nGain a guaranteed refresh next turn, this effect stacks.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
      };
      ability5.effects = new Effect[4];
      ability5.effects[0] = new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) instance5, 1, new IntentType?(), Slots.Self);
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 2, new IntentType?((IntentType) 171), Slots.Self);
            ability5.effects[3] = new Effect(ScriptableObject.CreateInstance<HealEffect>(), 1, IntentType.Heal_1_4, Slots.Self);
      ability5.animationTarget = Slots.Self;
      ability5.visuals = CustomVisuals.GetVisuals("Greasy/Sleep");
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("sleep", 1);
      ability6.name = "Light Sleep";
      ability6.description = "Goes to sleep.\nApply 3 shield to this party member's current position and heal them 1 health.\nGain a guaranteed refresh next turn, this effect stacks.";
      ability6.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
      };
      ability6.effects = new Effect[4];
      ability6.effects[0] = new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self);
      ability6.effects[1] = new Effect((EffectSO) instance5, 1, new IntentType?(), Slots.Self);
      ability6.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 3, new IntentType?((IntentType) 171), Slots.Self);
            ability6.effects[3] = new Effect(ScriptableObject.CreateInstance<HealEffect>(), 1, IntentType.Heal_1_4, Slots.Self);
            ability6.animationTarget = Slots.Self;
      ability6.visuals = CustomVisuals.GetVisuals("Greasy/Sleep");
      Ability ability7 = new Ability();
      ability7.sprite = ResourceLoader.LoadSprite("sleep", 1);
      ability7.name = "Deep Sleep";
      ability7.description = "Goes to sleep.\nApply 4 shield to this party member's current position and heal them 1 health..\nGain a guaranteed refresh next turn, this effect stacks.";
      ability7.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
      };
      ability7.effects = new Effect[4];
      ability7.effects[0] = new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self);
      ability7.effects[1] = new Effect((EffectSO) instance5, 1, new IntentType?(), Slots.Self);
      ability7.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 4, new IntentType?((IntentType) 171), Slots.Self);
            ability7.effects[3] = new Effect(ScriptableObject.CreateInstance<HealEffect>(), 1, IntentType.Heal_1_4, Slots.Self);
            ability7.animationTarget = Slots.Self;
      ability7.visuals = CustomVisuals.GetVisuals("Greasy/Sleep");
      Ability ability8 = new Ability();
      ability8.sprite = ResourceLoader.LoadSprite("sleep", 1);
      ability8.name = "THE Sleep";
      ability8.description = "Goes to sleep.\nApply 5 shield to this party member's current position and heal them 1 health.\nGain a guaranteed refresh next turn, this effect stacks.";
      ability8.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
      };
      ability8.effects = new Effect[4];
      ability8.effects[0] = new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self);
      ability8.effects[1] = new Effect((EffectSO) instance5, 1, new IntentType?(), Slots.Self);
      ability8.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, new IntentType?((IntentType) 171), Slots.Self);
            ability8.effects[3] = new Effect(ScriptableObject.CreateInstance<HealEffect>(), 1, IntentType.Heal_1_4, Slots.Self);
            ability8.animationTarget = Slots.Self;
      ability8.visuals = CustomVisuals.GetVisuals("Greasy/Sleep");
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("essence", 1);
      ability9.name = "Healing Essence";
      ability9.description = "Heal the left party member 2 health.\nIf this fully heals the left party member, refresh this party member.";
      ability9.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability9.effects = new Effect[1];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<PreviousIfHealToFullHealth>(), 2, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability9.animationTarget = Slots.SlotTarget(new int[1]
      {
        -1
      }, true);
      ability9.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability10 = new Ability();
      ability10.sprite = ResourceLoader.LoadSprite("essence", 1);
      ability10.name = "Mending Essence";
      ability10.description = "Heal the left party member 3 health.\nIf this fully heals the left party member, refresh this party member.";
      ability10.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability10.effects = new Effect[1];
      ability10.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<PreviousIfHealToFullHealth>(), 3, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability10.animationTarget = Slots.SlotTarget(new int[1]
      {
        -1
      }, true);
      ability10.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability11 = new Ability();
      ability11.sprite = ResourceLoader.LoadSprite("essence", 1);
      ability11.name = "Repairing Essence";
      ability11.description = "Heal the left party member 4 health.\nIf this fully heals the left party member, refresh this party member.";
      ability11.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability11.effects = new Effect[1];
      ability11.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<PreviousIfHealToFullHealth>(), 4, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability11.animationTarget = Slots.SlotTarget(new int[1]
      {
        -1
      }, true);
      ability11.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability12 = new Ability();
      ability12.sprite = ResourceLoader.LoadSprite("essence", 1);
      ability12.name = "THE Essence";
      ability12.description = "Heal the left party member 5 health.\nIf this fully heals the left party member, refresh this party member.";
      ability12.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability12.effects = new Effect[1];
      ability12.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<PreviousIfHealToFullHealth>(), 5, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability12.animationTarget = Slots.SlotTarget(new int[1]
      {
        -1
      }, true);
      ability12.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
      character.AddLevel(12, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(16, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(18, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(20, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      RedRager.angy = character;
    }

    public static string AddOtherStoredValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color red = Color.red;
      string str1;
      if (storedValue == (UnitStoredValueNames)84512)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Sleep" + string.Format(" +{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else if (storedValue == GourdPassiveAbility.Value)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str5 = "Tumor" + string.Format(" +{0}", (object) value);
          string str6 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
          string str7 = "</color>";
          str1 = str6 + str5 + str7;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }
  }
}
