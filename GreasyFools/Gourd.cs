// Decompiled with JetBrains decompiler
// Type: GreasyFools.Gourd
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class Gourd
  {
    public static Character dies;

    public static void Add()
    {
      CasterStoredValueChangeEffect instance1 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance1._minimumValue = 0;
      instance1._valueName = GourdPassiveAbility.Value;
      instance1._increase = false;
      CasterStoreValueSetterEffect instance2 = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
      instance2._valueName = GourdPassiveAbility.Value;
      GourdPassiveAbility instance3 = ScriptableObject.CreateInstance<GourdPassiveAbility>();
      instance3._passiveName = "Blight";
      instance3.passiveIcon = ResourceLoader.LoadSprite("Passive_Tumor.png");
      instance3.type = (PassiveAbilityTypes) 43991;
      instance3._enemyDescription = "This enemy gains 1 Tumor at the start of each turn. This enemy cannot be healed from sources other than \"Recondition\".";
      instance3._characterDescription = "This character gains 1 Tumor at the start of each turn. This character cannot be healed from sources other than \"Recondition\".";
      instance3.specialStoredValue = GourdPassiveAbility.Value;
      instance3.doesPassiveTriggerInformationPanel = false;
      instance3._triggerOn = new TriggerCalls[2]
      {
        (TriggerCalls) 9,
        (TriggerCalls) 21
      };
      CasterStoredValueChangeEffect instance4 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance4._minimumValue = 0;
      instance4._valueName = GourdPassiveAbility.Hidden;
      instance4._increase = true;
      CasterStoreValueSetterEffect instance5 = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
      instance5._valueName = GourdPassiveAbility.Hidden;
      SetCasterExtraSpritesEffect instance6 = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
      instance6._spriteType = (ExtraSpriteType) 0;
      Character character = new Character();
      character.name = nameof (Gourd);
      character.healthColor = Pigments.Red;
      character.entityID = (EntityIDs) 43991;
      character.levels = new CharacterRankedData[4];
      character.frontSprite = ResourceLoader.LoadSprite("GourdFront1");
      character.backSprite = ResourceLoader.LoadSprite("GourdBack1");
      character.overworldSprite = ResourceLoader.LoadSprite("GourdWorld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = ResourceLoader.LoadSprite("GourdMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("GourdMenu");
      character.menuChar = true;
      character.usesBaseAbility = true;
      character.isSupport = false;
      character.usesAllAbilities = false;
      character.appearsInShops = true;
      character.hurtSound = "event:/Greasy/Gourd/GourdHurt";
      character.deathSound = "event:/Greasy/Gourd/GourdDeath";
      character.dialogueSound = "event:/Greasy/Gourd/GourdTalk";
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance3
      };
      ExtraCCSprites_BasicSO instance7 = ScriptableObject.CreateInstance<ExtraCCSprites_BasicSO>();
      instance7._useDefault = (ExtraSpriteType) 0;
      instance7._useSpecial = (ExtraSpriteType) 43991;
      instance7._frontSprite = ResourceLoader.LoadSprite("GourdFront2");
      instance7._backSprite = ResourceLoader.LoadSprite("GourdBack2");
      character.extraSprites = (ExtraCharacterCombatSpritesSO) instance7;
      Ability ability1 = new Ability();
      ability1.name = "Decay the Flesh";
      ability1.description = "Deal 8 damage and inflict 2 Ruptured to the Opposing enemy and the enemies next to it. Costs 2 Tumors.";
      ability1.sprite = ResourceLoader.LoadSprite("GreasyFools.Textures.Decay.png");
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability1.visuals = (AttackVisualsSO) null;
      ability1.animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create(Slots.Front, (BaseCombatTargettingSO) TargettingByTargetting.Create(Slots.Front, Slots.Sides));
      ability1.effects = new Effect[4];
      ability1.effects[0] = new Effect((EffectSO) EZEffects.GetVisuals<AnimationVisualsEffect>("Greasy/Decay", false, ability1.animationTarget), 1, new IntentType?(), Slots.Self, (EffectConditionSO) HasTumorsCondition.Create(2));
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 8, new IntentType?((IntentType) 2), ability1.animationTarget, (EffectConditionSO) HasTumorsCondition.Create(2));
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, new IntentType?((IntentType) 151), ability1.animationTarget, (EffectConditionSO) HasTumorsCondition.Create(2));
      ability1.effects[3] = new Effect((EffectSO) instance1, 2, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) HasTumorsCondition.Create(2));
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Decay the Bone";
      ability2.description = "Deal 11 damage and inflict 2 Ruptured to the Opposing enemy and the enemies next to it. Costs 2 Tumors.";
      ability2.effects[0]._entryVariable = 11;
      ability2.effects[0]._intent = new IntentType?((IntentType) 3);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Decay the Innards";
      ability3.description = "Deal 14 damage and inflict 3 Ruptured to the Opposing enemy and the enemies next to it. Costs 2 Tumors.";
      ability3.effects[0]._entryVariable = 14;
      ability3.effects[1]._entryVariable = 3;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Decay the Life";
      ability4.description = "Deal 18 damage and inflict 3 Ruptured to the Opposing enemy and the enemies next to it. Costs 2 Tumors.";
      ability4.effects[0]._entryVariable = 18;
      ability4.effects[0]._intent = new IntentType?((IntentType) 4);
      Ability ability5 = new Ability();
      ability5.name = "Flesh Recondition";
      ability5.description = "Heal this party member for the amount of tumors they have. \nApply 6 Shield to self if at 2+ Tumors. Apply Focused to self if at 3+ Tumors. \nRemove all Tumors.";
      ability5.sprite = ResourceLoader.LoadSprite("Reconstruction.png");
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Red
      };
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Amalgam_1_A").visuals;
      ability5.animationTarget = Slots.Self;
      ability5.effects = new Effect[8];
      ability5.effects[0] = new Effect((EffectSO) instance4, 1, new IntentType?((IntentType) 100), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealByTumorsEffect>(), 1, new IntentType?((IntentType) 21), Slots.Self);
      ability5.effects[2] = new Effect((EffectSO) instance5, 0, new IntentType?(), Slots.Self);
      ability5.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, new IntentType?((IntentType) 171), Slots.Self, (EffectConditionSO) HasTumorsCondition.Create(2));
      ability5.effects[4] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 4, new IntentType?(), Slots.Self, (EffectConditionSO) HasTumorsCondition.Create(4));
      ability5.effects[5] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, new IntentType?((IntentType) 156), Slots.Self, (EffectConditionSO) HasTumorsCondition.Create(3));
      ability5.effects[6] = new Effect((EffectSO) instance2, 0, new IntentType?(), Slots.Self);
      ability5.effects[7] = new Effect((EffectSO) instance6, 0, new IntentType?(), Slots.Self);
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Body Recondition";
      ability6.description = "Heal this party member for the amount of tumors they have. \nApply 8 Shield to self if at 2+ Tumors. Apply Focused to self if at 3+ Tumors. \nRemove all Tumors.";
      ability6.effects[3]._entryVariable = 8;
      ability6.effects[4]._condition = (EffectConditionSO) HasTumorsCondition.Create(3);
      ability6.effects[5]._condition = (EffectConditionSO) HasTumorsCondition.Create(3);
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Soul Recondition";
      ability7.description = "Heal this party member for the amount of tumors they have. \nApply 12 Shield to self if at 2+ Tumors. Apply Focused to self if at 3+ Tumors. \nRemove all Tumors.";
      ability7.effects[3]._entryVariable = 12;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Ultimate Recondition";
      ability8.description = "Heal this party member for the amount of tumors they have. \nApply 15 Shield to self if at 2+ Tumors. Apply Focused to self if at 3+ Tumors. \nRemove all Tumors.";
      ability8.effects[3]._entryVariable = 15;
      Ability ability9 = new Ability();
      ability9.name = "Fracturing Wreckage";
      ability9.description = "Deal 6 damage to the Opposing enemy, dealing double damage if they have Frail. Inflict 2 Frail on the Opposing enemy. \nCosts 2 Tumors.";
      ability9.sprite = ResourceLoader.LoadSprite("Wreckage.png");
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability9.visuals = (AttackVisualsSO) null;
      ability9.animationTarget = Slots.Front;
      ability9.effects = new Effect[5];
      ability9.effects[0] = new Effect((EffectSO) EZEffects.GetVisuals<AnimationVisualsEffect>("Greasy/Brute", false, Slots.Front), 1, new IntentType?(), Slots.Self, (EffectConditionSO) HasTumorsCondition.Create(2));
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) TargettingByConditionStatus.Create(Slots.Front, (StatusEffectType) 1, false), (EffectConditionSO) HasTumorsCondition.Create(2));
      ability9.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 12, new IntentType?((IntentType) 3), (BaseCombatTargettingSO) TargettingByConditionStatus.Create(Slots.Front, (StatusEffectType) 1), (EffectConditionSO) HasTumorsCondition.Create(2));
      ability9.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, new IntentType?((IntentType) 150), Slots.Front, (EffectConditionSO) HasTumorsCondition.Create(2));
      ability9.effects[4] = new Effect((EffectSO) instance1, 2, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) HasTumorsCondition.Create(2));
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Shattering Wreckage";
      ability10.description = "Deal 8 damage to the Opposing enemy, dealing double damage if they have Frail. Inflict 2 Frail on the Opposing enemy. \nCosts 2 Tumors.";
      ability10.effects[1]._entryVariable = 8;
      ability10.effects[1]._intent = new IntentType?((IntentType) 2);
      ability10.effects[2]._entryVariable = 16;
      ability10.effects[2]._intent = new IntentType?((IntentType) 4);
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Bone-Crushing Wreckage";
      ability11.description = "Deal 10 damage to the Opposing enemy, dealing double damage if they have Frail. Inflict 3 Frail on the Opposing enemy. \nCosts 2 Tumors.";
      ability11.effects[1]._entryVariable = 10;
      ability11.effects[2]._entryVariable = 20;
      ability11.effects[3]._entryVariable = 3;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Pulverizing Wreckage";
      ability12.description = "Deal 12 damage to the Opposing enemy, dealing double damage if they have Frail. Inflict 3 Frail on the Opposing enemy. \nCosts 2 Tumors.";
      ability12.effects[1]._entryVariable = 12;
      ability12.effects[1]._intent = new IntentType?((IntentType) 3);
      ability12.effects[2]._entryVariable = 24;
      ability11.effects[2]._intent = new IntentType?((IntentType) 5);
      character.AddLevel(10, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(10, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(10, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(10, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Gourd.dies = character;
    }
  }
}
