// Decompiled with JetBrains decompiler
// Type: GreasyFools.CustomIntentIconSystem
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class CustomIntentIconSystem
  {
    public static Dictionary<string, IntentInfo> Intents = new Dictionary<string, IntentInfo>();
    public static bool CanUseDamageColors;
    public static Color DamagePurple;
    public static Color DamageRed;
    private static bool AlreadySet = false;

    public static void TryAddIntent(string name, IntentInfo intent)
    {
      if (CustomIntentIconSystem.Intents.Keys.Contains<string>(name))
        return;
      CustomIntentIconSystem.Intents.Add(name, intent);
    }

    public static IntentType GetIntent(string name)
    {
      IntentInfo intentInfo;
      if (CustomIntentIconSystem.Intents.TryGetValue(name, out intentInfo))
        return intentInfo.Type;
      Debug.LogError((object) ("IntentType for: " + name + " does not exist. Did you not add it in the correct order?"));
      return (IntentType) 101;
    }

    public static void HookInIntent(IntentHandlerSO self, IntentInfo info)
    {
      if (info is CustomIntentInfo customIntentInfo)
      {
        if (self._intentDB.Keys.Contains<IntentType>(customIntentInfo.GetSoundFrom))
          info._sound = self._intentDB[customIntentInfo.GetSoundFrom]._sound;
        else
          Debug.LogError((object) ("IntentInfo: " + customIntentInfo.Name + " cannot pull sound from: " + customIntentInfo.GetSoundFrom.ToString() + " because it does not exist."));
      }
      if (!self._intentDB.TryGetValue(info.Type, out IntentInfo _))
        self._intentDB.Add(info.Type, info);
      else
        Debug.LogWarning((object) ("Intent for IntentType: " + info.Type.ToString() + " already exists!?"));
    }

    public static void AddIntentsGeneral(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      CustomIntentIconSystem.CanUseDamageColors = false;
      if (self._intentDB[(IntentType) 1] is IntentInfoDamage intentInfoDamage)
      {
        CustomIntentIconSystem.DamageRed = intentInfoDamage._enemyColor;
        CustomIntentIconSystem.DamagePurple = ((IntentInfo) intentInfoDamage)._color;
        CustomIntentIconSystem.CanUseDamageColors = true;
      }
      foreach (IntentInfo info in CustomIntentIconSystem.Intents.Values)
        CustomIntentIconSystem.HookInIntent(self, info);
    }

    public static void Setup()
    {
      if (CustomIntentIconSystem.AlreadySet)
        return;
      CustomIntentIconSystem.AlreadySet = true;
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (CustomIntentIconSystem).GetMethod("AddIntentsGeneral", ~BindingFlags.Default));
    }
  }
}
