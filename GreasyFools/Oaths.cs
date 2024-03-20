// Decompiled with JetBrains decompiler
// Type: GreasyFools.Oaths
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using System;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class Oaths
  {
    public static Character Oatmeal;

    public static void Add()
    {
      EZExtensions.PCall(new Action(Gaze.Add), "gaze setup");
      Connection_PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance)._passiveName = "Obsession";
      ((BasePassiveAbilitySO) instance).passiveIcon = ResourceLoader.LoadSprite("Obsession.png");
      ((BasePassiveAbilitySO) instance)._characterDescription = "At the start of combat, inflict Gaze on the Opposing enemy.";
      ((BasePassiveAbilitySO) instance)._enemyDescription = ((BasePassiveAbilitySO) instance)._characterDescription;
      ((BasePassiveAbilitySO) instance).conditions = new EffectorConditionSO[0];
      ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 1000
      };
      ((BasePassiveAbilitySO) instance).type = (PassiveAbilityTypes) 8301354;
      instance.disconnectionEffects = new EffectInfo[0];
      instance.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyGazeEffect>(), 1, new IntentType?(), Slots.Front)
      });
      instance.immediateEffect = false;
      ((BasePassiveAbilitySO) instance).doesPassiveTriggerInformationPanel = false;
      Oaths.Oatmeal = new Character()
      {
        name = nameof (Oaths),
        entityID = (EntityIDs) 624793,
        healthColor = Pigments.Purple,
        usesBaseAbility = true,
        usesAllAbilities = false,
        walksInOverworld = true,
        isSupport = false,
        menuChar = true,
        appearsInShops = true,
        levels = new CharacterRankedData[4],
        frontSprite = ResourceLoader.LoadSprite("OathsFront.png"),
        backSprite = ResourceLoader.LoadSprite("OathsBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("OathsWorld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        unlockedSprite = ResourceLoader.LoadSprite("OathsMenu.png"),
        lockedSprite = ResourceLoader.LoadSprite("OathsMenu.png"),
        hurtSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound,
        deathSound = LoadedAssetsHandler.GetCharcater("Rags_CH").deathSound,
        dialogueSound = LoadedAssetsHandler.GetCharcater("Rags_CH").dxSound,
        passives = new BasePassiveAbilitySO[1]
        {
          (BasePassiveAbilitySO) instance
        }
      };
      TargettingByConditionStatus target = TargettingByConditionStatus.Create(Slots.Front, (StatusEffectType) Gaze.Type);
      TargettingByConditionStatus byConditionStatus1 = TargettingByConditionStatus.Create(Slots.Front, target.status, false, true);
      TargettingByConditionStatus byConditionStatus2 = TargettingByConditionStatus.Create((BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(false, false), target.status);
      Ability ability1 = new Ability();
      ability1.name = "Condemn to Pain";
      ability1.description = "If the Opposing enemy has Gaze, deal 10 damage to them. \nOtherwise, deal 3-5 damage to them.";
      ability1.sprite = ResourceLoader.LoadSprite("Condemn.png");
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Showdown_1_A").visuals;
      ability1.animationTarget = Slots.Front;
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?((IntentType) 2), (BaseCombatTargettingSO) target);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 3, new IntentType?(), (BaseCombatTargettingSO) byConditionStatus1);
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 5, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) byConditionStatus1);
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Condemn to Suffering";
      ability2.description = "If the Opposing enemy has Gaze, deal 12 damage to them. \nOtherwise, deal 3-7 damage to them.";
      ability2.effects[0]._entryVariable = 12;
      ability2.effects[0]._intent = new IntentType?((IntentType) 3);
      ability2.effects[2]._entryVariable = 7;
      ability2.effects[2]._intent = new IntentType?((IntentType) 2);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Condemn to Torture";
      ability3.description = "If the Opposing enemy has Gaze, deal 13 damage to them. \nOtherwise, deal 5-9 damage to them.";
      ability3.effects[0]._entryVariable = 13;
      ability3.effects[1]._entryVariable = 5;
      ability3.effects[2]._entryVariable = 9;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Condemn to Oblivion";
      ability4.description = "If the Opposing enemy has Gaze, deal 14 damage to them. \nOtherwise, deal 5-11 damage to them.";
      ability4.effects[0]._entryVariable = 14;
      ability4.effects[2]._entryVariable = 11;
      ability4.effects[2]._intent = new IntentType?((IntentType) 3);
      Ability ability5 = new Ability();
      ability5.name = "Smoulder Embers";
      ability5.description = "Deal 5 damage and inflict 1 Fire on the Left and Right enemies. \nIf either has Gaze, apply an infinite amount of Fire on their position instead.";
      ability5.sprite = ResourceLoader.LoadSprite("Smoulder.png");
      ability5.cost = new ManaColorSO[4]
      {
        Pigments.Yellow,
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Sear_1_A").visuals;
      ability5.animationTarget = Slots.LeftRight;
      ability5.effects = new Effect[2];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?((IntentType) 1), Slots.LeftRight);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<FireByGazeEffect>(), 1, new IntentType?((IntentType) 172), Slots.LeftRight);
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Smoulder Blaze";
      ability6.description = "Deal 8 damage and inflict 1 Fire on the Left and Right enemies. \nIf either has Gaze, apply an infinite amount of Fire on their position instead.";
      ability6.effects[0]._entryVariable = 8;
      ability6.effects[0]._intent = new IntentType?((IntentType) 2);
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Smoulder Inferno";
      ability7.description = "Deal 10 damage and inflict 1 Fire on the Left and Right enemies. \nIf either has Gaze, apply an infinite amount of Fire on their position instead.";
      ability7.effects[0]._entryVariable = 10;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Smoulder Soul";
      ability8.description = "Deal 11 damage and inflict 1-2 Fire on the Left and Right enemies. \nIf either has Gaze, apply an infinite amount of Fire on their position instead.";
      ability8.cost = new ManaColorSO[4]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Yellow),
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability8.effects = new Effect[6];
      ability8.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 11, new IntentType?((IntentType) 3), Slots.LeftRight);
      ability8.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?((IntentType) 172), (BaseCombatTargettingSO) TargettingByConditionStatus.Create(Slots.Left, target.status, false), (EffectConditionSO) Conditions.Chance(50));
      ability8.effects[2] = new Effect(ability8.effects[1]._effect, 2, new IntentType?(), ability8.effects[1]._target, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false));
      ability8.effects[3] = new Effect(ability8.effects[1]._effect, 1, new IntentType?((IntentType) 172), (BaseCombatTargettingSO) TargettingByConditionStatus.Create(Slots.Right, target.status, false), (EffectConditionSO) Conditions.Chance(50));
      ability8.effects[4] = new Effect(ability8.effects[1]._effect, 2, new IntentType?(), ability8.effects[3]._target, ability8.effects[2]._condition);
      ability8.effects[5] = new Effect(ability7.effects[1]._effect, 1, new IntentType?((IntentType) 172), (BaseCombatTargettingSO) TargettingByConditionStatus.Create(Slots.LeftRight, target.status));
      Ability ability9 = new Ability();
      ability9.name = "Faint Exposure";
      ability9.description = "Deal 6 damage to the Opposing enemy and all enemies with Gaze. \nWill not attack the Opposing enemy twice.";
      ability9.sprite = ResourceLoader.LoadSprite("Exposure.png");
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability9.visuals = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals;
      ability9.animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create((BaseCombatTargettingSO) byConditionStatus1, (BaseCombatTargettingSO) byConditionStatus2);
      ability9.effects = new Effect[2];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) byConditionStatus1);
      ability9.effects[1] = new Effect(ability9.effects[0]._effect, 6, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) byConditionStatus2);
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Painful Exposure";
      ability10.description = "Deal 8 damage to the Opposing enemy and all enemies with Gaze. \nWill not attack the Opposing enemy twice.";
      ability10.effects[0]._entryVariable = 8;
      ability10.effects[0]._intent = new IntentType?((IntentType) 2);
      ability10.effects[1]._entryVariable = 8;
      ability10.effects[1]._intent = new IntentType?((IntentType) 2);
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Critical Exposure";
      ability11.description = "Deal 10 damage to the Opposing enemy and all enemies with Gaze. \nWill not attack the Opposing enemy twice.";
      ability11.effects[0]._entryVariable = 10;
      ability11.effects[1]._entryVariable = 10;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Omnipresent Exposure";
      ability12.description = "Deal 12 damage to the Opposing enemy and all enemies with Gaze. \nWill not attack the Opposing enemy twice.";
      ability12.effects[0]._entryVariable = 12;
      ability12.effects[0]._intent = new IntentType?((IntentType) 3);
      ability12.effects[1]._entryVariable = 12;
      ability12.effects[1]._intent = new IntentType?((IntentType) 3);
      Oaths.Oatmeal.AddLevel(16, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      Oaths.Oatmeal.AddLevel(17, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      Oaths.Oatmeal.AddLevel(18, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      Oaths.Oatmeal.AddLevel(19, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      Oaths.Oatmeal.AddCharacter();
    }
  }
}
