// Decompiled with JetBrains decompiler
// Type: GreasyFools.Passiver
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class Passiver
  {
    public static BasePassiveAbilitySO Fleeting(int amount)
    {
      FleetingPassiveAbility fleetingPassiveAbility = Object.Instantiate<FleetingPassiveAbility>(Passives.Fleeting as FleetingPassiveAbility);
      ((BasePassiveAbilitySO) fleetingPassiveAbility)._passiveName = "Fleeting (" + amount.ToString() + ")";
      ((BasePassiveAbilitySO) fleetingPassiveAbility)._characterDescription = "After " + amount.ToString() + " rounds this party member will flee... Coward.";
      ((BasePassiveAbilitySO) fleetingPassiveAbility)._enemyDescription = "After " + amount.ToString() + " rounds this enemy will flee.";
      fleetingPassiveAbility._turnsBeforeFleeting = amount;
      return (BasePassiveAbilitySO) fleetingPassiveAbility;
    }

    public static BasePassiveAbilitySO Overexert(int amount)
    {
      IntegerReferenceOverEqualValueEffectorCondition instance = ScriptableObject.CreateInstance<IntegerReferenceOverEqualValueEffectorCondition>();
      instance.compareValue = amount;
      BasePassiveAbilitySO passiveAbilitySo = Object.Instantiate<BasePassiveAbilitySO>(LoadedAssetsHandler.GetEnemy("Scrungie_EN").passiveAbilities[2]);
      passiveAbilitySo._passiveName = "Overexert (" + amount.ToString() + ")";
      passiveAbilitySo._characterDescription = "Won't work with this version.";
      passiveAbilitySo._enemyDescription = "Upon receiving " + amount.ToString() + " or more direct damage, cancel 1 of this enemy's actions.";
      passiveAbilitySo.conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) instance
      };
      return passiveAbilitySo;
    }

    public static BasePassiveAbilitySO Leaky(int amount)
    {
      PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance)._passiveName = "Leaky (" + amount.ToString() + ")";
      ((BasePassiveAbilitySO) instance).passiveIcon = Passives.Leaky.passiveIcon;
      ((BasePassiveAbilitySO) instance)._enemyDescription = "Upon receiving direct damage, this enemy generates " + amount.ToString() + " extra pigment of its health color.";
      ((BasePassiveAbilitySO) instance)._characterDescription = "Upon receiving direct damage, this character generates " + amount.ToString() + " extra pigment of its health color.";
      ((BasePassiveAbilitySO) instance).type = (PassiveAbilityTypes) 32;
      ((BasePassiveAbilitySO) instance).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 12
      };
      instance.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), amount, new IntentType?(), Slots.Self)
      });
      return (BasePassiveAbilitySO) instance;
    }

    public static BasePassiveAbilitySO Multiattack(int amount, bool fool = false)
    {
      if (!fool)
      {
        IntegerSetterPassiveAbility setterPassiveAbility = Object.Instantiate<IntegerSetterPassiveAbility>(Passives.Multiattack as IntegerSetterPassiveAbility);
        ((BasePassiveAbilitySO) setterPassiveAbility)._passiveName = "Multi Attack (" + amount.ToString() + ")";
        ((BasePassiveAbilitySO) setterPassiveAbility)._characterDescription = "won't work boowomp";
        ((BasePassiveAbilitySO) setterPassiveAbility)._enemyDescription = "This enemy will perform " + amount.ToString() + " actions each turn.";
        setterPassiveAbility.integerValue = amount - 1;
        return (BasePassiveAbilitySO) setterPassiveAbility;
      }
      PerformDoubleEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "MultiAttack (" + amount.ToString() + ")";
      ((BasePassiveAbilitySO) instance1).passiveIcon = Passives.Multiattack.passiveIcon;
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 13;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "This shouldn't be on an enemy.";
      ((BasePassiveAbilitySO) instance1)._characterDescription = "This party member can perform " + amount.ToString() + " abilities per turn.";
      ((BasePassiveAbilitySO) instance1).specialStoredValue = (UnitStoredValueNames) 77889;
      CasterSetStoredValueEffect instance2 = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
      instance2._valueName = (UnitStoredValueNames) 77889;
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance2, amount - 1, new IntentType?(), Slots.Self)
      });
      RefreshIfStoredValueNotZero instance3 = ScriptableObject.CreateInstance<RefreshIfStoredValueNotZero>();
      instance3._valueName = (UnitStoredValueNames) 77889;
      ScriptableObject.CreateInstance<CasterLowerStoredValueEffect>()._valueName = (UnitStoredValueNames) 77889;
      instance1._secondTriggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 14
      };
      instance1._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = false;
      instance1._secondDoesPerformPopUp = false;
      return (BasePassiveAbilitySO) instance1;
    }

    public static BasePassiveAbilitySO Inferno(int amount)
    {
      PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance)._passiveName = "Inferno (" + amount.ToString() + ")";
      ((BasePassiveAbilitySO) instance).passiveIcon = Passives.Inferno.passiveIcon;
      ((BasePassiveAbilitySO) instance)._enemyDescription = "On turn start, this enemy inflicts " + amount.ToString() + " Fire on their position.";
      ((BasePassiveAbilitySO) instance)._characterDescription = "On turn start, this character inflicts " + amount.ToString() + " Fire on their position.";
      ((BasePassiveAbilitySO) instance).type = (PassiveAbilityTypes) 28;
      ((BasePassiveAbilitySO) instance).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), amount, new IntentType?(), Slots.Self)
      });
      return (BasePassiveAbilitySO) instance;
    }

    public static BasePassiveAbilitySO Abomination
    {
      get => LoadedAssetsHandler.GetEnemy("OneManBand_EN").passiveAbilities[1];
    }
  }
}
