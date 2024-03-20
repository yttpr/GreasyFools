// Decompiled with JetBrains decompiler
// Type: GreasyFools.HooksGeneral
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class HooksGeneral
  {
    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("Damage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("DamageCH", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("Damage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("DamageEN", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("WillApplyDamageCH", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("WillApplyDamageEN", ~BindingFlags.Default));
      IDetour idetour5 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("Start", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("StartMenu", ~BindingFlags.Default));
      IDetour idetour6 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("InitializeCombat", ~BindingFlags.Default));
      IDetour idetour7 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnStart", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("PlayerTurnStart", ~BindingFlags.Default));
      IDetour idetour8 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnEnd", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("PlayerTurnEnd", ~BindingFlags.Default));
      IDetour idetour9 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("PostNotification", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("PostNotification", ~BindingFlags.Default));
      IDetour idetour10 = (IDetour) new Hook((MethodBase) typeof (EffectAction).GetMethod("Execute", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("EffectActionExecute", ~BindingFlags.Default));
      IDetour idetour11 = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("AddStoredValue", ~BindingFlags.Default));
      IDetour idetour12 = (IDetour) new Hook((MethodBase) typeof (OverworldManagerBG).GetMethod("Awake", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("AwakeOverworld", ~BindingFlags.Default));
    }

    public static DamageInfo DamageCH(
      Func<CharacterCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig,
      CharacterCombat self,
      int amount,
      IUnit killer,
      DeathType deathType,
      int targetSlotOffset = -1,
      bool addHealthMana = true,
      bool directDamage = true,
      bool ignoresShield = false,
      DamageType specialDamage = 0)
    {
      return orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
    }

    public static DamageInfo DamageEN(
      Func<EnemyCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig,
      EnemyCombat self,
      int amount,
      IUnit killer,
      DeathType deathType,
      int targetSlotOffset = -1,
      bool addHealthMana = true,
      bool directDamage = true,
      bool ignoresShield = false,
      DamageType specialDamage = 0)
    {
      return orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
    }

    public static int WillApplyDamageCH(
      Func<CharacterCombat, int, IUnit, int> orig,
      CharacterCombat self,
      int amount,
      IUnit targetUnit)
    {
      amount += self.GetStoredValue(ForgeHandler.Forge);
      return orig(self, amount, targetUnit);
    }

    public static int WillApplyDamageEN(
      Func<EnemyCombat, int, IUnit, int> orig,
      EnemyCombat self,
      int amount,
      IUnit targetUnit)
    {
      amount += self.GetStoredValue(ForgeHandler.Forge);
      return orig(self, amount, targetUnit);
    }

    public static void StartMenu(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
    }

    public static void InitializeCombat(Action<CombatManager> orig, CombatManager self)
    {
      Quorell.Battle();
      orig(self);
    }

    public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self) => orig(self);

    public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self) => orig(self);

    public static void PostNotification(
      Action<CombatManager, string, object, object> orig,
      CombatManager self,
      string call,
      object sender,
      object args)
    {
      orig(self, call, sender, args);
    }

    public static IEnumerator EffectActionExecute(
      Func<EffectAction, CombatStats, IEnumerator> orig,
      EffectAction self,
      CombatStats stats)
    {
      return orig(self, stats);
    }

    public static string AddStoredValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      string str1;
      if (storedValue == (UnitStoredValueNames)77889 && value > 0)
      {
        string str2 = "Multiattack" + string.Format(" +{0}", (object) value);
        string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
        string str4 = "</color>";
        str1 = str3 + str2 + str4;
      }
      else if (storedValue == ForgeHandler.Forge && value > 0)
      {
        string str5 = "Forge" + string.Format(" +{0}", (object) value);
        string str6 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
        string str7 = "</color>";
        str1 = str6 + str5 + str7;
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    public static void AwakeOverworld(Action<OverworldManagerBG> orig, OverworldManagerBG self)
    {
      Quorell.Menu();
      orig(self);
    }
  }
}
