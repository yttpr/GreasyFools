// Decompiled with JetBrains decompiler
// Type: GreasyFools.GreasyFools
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BepInEx;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  [BepInPlugin("GreasySatan.GreasyFools", "Greasy Fools", "1.0.0")]
    [BepInDependency("Bones404.BrutalAPI", (BepInDependency.DependencyFlags)1)]
    public class GreasyFools : BaseUnityPlugin
  {
    public void Awake()
    {
      EZExtensions.PCall(new Action(AbilityNameFix.Setup), "ability name fix");
      EZExtensions.PCall(new Action(HooksGeneral.Setup), "general hooks salt");
      EZExtensions.PCall(new Action(PigmentUsedCollector.Setup), "last pigment used collector");
      EZExtensions.PCall(new Action(Quorell.Add), "quorell");
      GreasyFools.QuorellAnimator();
      EZExtensions.PCall(new Action(Biersal.Add), "biersal");
      EZExtensions.PCall(new Action(RedRager.Add), "red rager");
      EZExtensions.PCall(new Action(Derek.Add), "derek");
      EZExtensions.PCall(new Action(Gourd.Add), "gourd");
      EZExtensions.PCall(new Action(Oaths.Add), "oaths");
      EZExtensions.PCall(new Action(Fel.Add), "fel");
      EZExtensions.PCall(new Action(Stain.Add), "Stain");
      EZExtensions.PCall(new Action(Ragerred.Add), "secret gyty");
      EZExtensions.PCall(new Action(TheSilliestSecretCharacter.PasscodeReader.Add), "passcode reader");
      EZExtensions.PCall(new Action(Backrooms.Setup), "free fool setup");
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (CustomeStatusEffects).GetMethod("AddDeflectStatusEffect", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (CustomeStatusEffects).GetMethod("AddDeflectIntent", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("ApplyStatusEffect", ~BindingFlags.Default), typeof (GreasyFools).GetMethod("ApplyStatusEffect", ~BindingFlags.Default));
      this.Logger.LogInfo((object) "Greasy Fools mod loaded successly");
    }

    public static bool ApplyStatusEffect(
      Func<CharacterCombat, IStatusEffect, int, bool> orig,
      CharacterCombat self,
      IStatusEffect statusEffect,
      int amount)
    {
      IStatusEffector istatusEffector = (IStatusEffector) self;
      if (istatusEffector != null)
      {
        foreach (IStatusEffect statusEffect1 in istatusEffector.StatusEffects)
        {
          if (statusEffect1.EffectType == (StatusEffectType)65752 && statusEffect.EffectType != (StatusEffectType)65752)
          {
            CustomeIStatusEffectRefrence istatusEffectRefrence = new CustomeIStatusEffectRefrence(statusEffect, amount);
            CombatManager.Instance.PostNotification(((TriggerCalls) 648797).ToString(), (object) self, (object) istatusEffectRefrence);
            return false;
          }
        }
      }
      return orig(self, statusEffect, amount);
    }

    public static bool QuorellAnimator()
    {
      try
      {
        LoadedAssetsHandler.LoadedCharacters["Quorell_CH"].characterAnimator = PymnHere.Assets.LoadAsset<RuntimeAnimatorController>("Assets/AnimationBaseData/NewBigGuy/BigAnimController.overrideController");
      }
      catch
      {
        Debug.LogError((object) "Quorell's animator failure :(");
        return false;
      }
      return true;
    }
  }
}
