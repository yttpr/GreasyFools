// Decompiled with JetBrains decompiler
// Type: GreasyFools.DirectWrongPigmentHandler
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using Tools;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class DirectWrongPigmentHandler
  {
    private static BasePassiveAbilitySO _passive;

    public static PassiveAbilityTypes type => (PassiveAbilityTypes) 7015243;

    public static BasePassiveAbilitySO Passive
    {
      get
      {
        if ((UnityEngine.Object) DirectWrongPigmentHandler._passive == (UnityEngine.Object) null)
        {
          PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
          ((BasePassiveAbilitySO) instance)._passiveName = "Tainted";
          ((BasePassiveAbilitySO) instance).passiveIcon = ResourceLoader.LoadSprite("Tainted.png");
          ((BasePassiveAbilitySO) instance)._characterDescription = "Wrong Pigment damage now deals direct damage.";
          ((BasePassiveAbilitySO) instance)._enemyDescription = ((BasePassiveAbilitySO) instance)._characterDescription;
          ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
          {
            (TriggerCalls) 1000
          };
          ((BasePassiveAbilitySO) instance).type = DirectWrongPigmentHandler.type;
          ((BasePassiveAbilitySO) instance).conditions = new EffectorConditionSO[0];
          instance.effects = new EffectInfo[0];
          DirectWrongPigmentHandler._passive = (BasePassiveAbilitySO) instance;
          DirectWrongPigmentHandler.Setup();
        }
        return DirectWrongPigmentHandler._passive;
      }
    }

    public static int ManaDamage(
      Func<CharacterCombat, int, bool, DeathType, int> orig,
      CharacterCombat self,
      int amount,
      bool useManaSound,
      DeathType deathType)
    {
      if (!self.ContainsPassiveAbility(DirectWrongPigmentHandler.type) || deathType != (DeathType)10)
        return orig(self, amount, useManaSound, deathType);
      int slotId = self.SlotID;
      int num1 = self.SlotID + self.Size - 1;
      DamageReceivedValueChangeException valueChangeException1 = new DamageReceivedValueChangeException(amount, (DamageType) 5, true, false, slotId, num1);
      CombatManager instance1 = CombatManager.Instance;
      TriggerCalls triggerCalls = (TriggerCalls) 6;
      string str1 = triggerCalls.ToString();
      CharacterCombat characterCombat1 = self;
      DamageReceivedValueChangeException valueChangeException2 = valueChangeException1;
      instance1.PostNotification(str1, (object) characterCombat1, (object) valueChangeException2);
      int modifiedValue = valueChangeException1.GetModifiedValue();
      int num2 = Mathf.Max(self.CurrentHealth - modifiedValue, 0);
      int num3 = self.CurrentHealth - num2;
      if (num3 != 0)
      {
        self.GetHit();
        self.CurrentHealth = num2;
        CombatManager.Instance.AddUIAction((CombatAction) new CharacterDamagedUIAction(self.ID, self.CurrentHealth, self.MaximumHealth, modifiedValue, useManaSound ? (DamageType) 5 : (DamageType) 0, true));
        if (self.IsAlive)
          CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new AddManaToManaBarAction(self.HealthColor, Utils.characterManaAmount, self.IsUnitCharacter, self.ID), false);
        CombatManager instance2 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 12;
        string str2 = triggerCalls.ToString();
        CharacterCombat characterCombat2 = self;
        IntegerReference integerReference1 = new IntegerReference(num3);
        instance2.PostNotification(str2, (object) characterCombat2, (object) integerReference1);
        CombatManager instance3 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 5;
        string str3 = triggerCalls.ToString();
        CharacterCombat characterCombat3 = self;
        IntegerReference integerReference2 = new IntegerReference(num3);
        instance3.PostNotification(str3, (object) characterCombat3, (object) integerReference2);
      }
      else
        CombatManager.Instance.AddUIAction((CombatAction) new CharacterNotDamagedUIAction(self.ID, useManaSound ? (DamageType) 5 : (DamageType) 0));
      if (self.IsAlive && self.CurrentHealth == 0 && num3 != 0)
        CombatManager.Instance.AddSubAction((CombatAction) new CharacterDeathAction(self.ID, (IUnit) null, deathType));
      return num3;
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("ManaDamage", ~BindingFlags.Default), typeof (DirectWrongPigmentHandler).GetMethod("ManaDamage", ~BindingFlags.Default));
    }
  }
}
