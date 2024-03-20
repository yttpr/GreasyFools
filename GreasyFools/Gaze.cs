// Decompiled with JetBrains decompiler
// Type: GreasyFools.Gaze
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class Gaze
  {
    public static int Intent = 543021;
    public static string Name = nameof (Gaze);
    public static string Desc = "This unit is being stared at and certain attacks against this unit will become empowered.";
    public static Sprite image = ResourceLoader.LoadSprite("Gazed.png");
    public static IntentInfo gazeIntent = (IntentInfo) new IntentInfoBasic();
    public static StatusEffectInfoSO gazeInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();

    public static int Type => Gaze.Intent;

    public static void AddGazeIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      Gaze.gazeIntent._type = (IntentType) Gaze.Intent;
      Gaze.gazeIntent._sprite = Gaze.image;
      Gaze.gazeIntent._color = Color.white;
      Gaze.gazeIntent._sound = self._intentDB[(IntentType) 159]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) Gaze.Intent, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) Gaze.Intent, Gaze.gazeIntent);
    }

    public static void AddGazeStatus(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      ((UnityEngine.Object) Gaze.gazeInfo).name = Gaze.Name;
      Gaze.gazeInfo.icon = Gaze.image;
      Gaze.gazeInfo._statusName = Gaze.Name;
      Gaze.gazeInfo.statusEffectType = (StatusEffectType) Gaze.Type;
      Gaze.gazeInfo._description = Gaze.Desc;
      Gaze.gazeInfo._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 3].AppliedSoundEvent;
      Gaze.gazeInfo._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 3].UpdatedSoundEvent;
      Gaze.gazeInfo._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 3].RemovedSoundEvent;
      StatusEffectInfoSO statusEffectInfoSo;
      self._stats.statusEffectDataBase.TryGetValue((StatusEffectType) Gaze.Type, out statusEffectInfoSo);
      if (!((UnityEngine.Object) statusEffectInfoSo == (UnityEngine.Object) null))
        return;
      self._stats.statusEffectDataBase.Add((StatusEffectType) Gaze.Type, Gaze.gazeInfo);
    }

    public static void Add()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (Gaze).GetMethod("AddGazeStatus", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (Gaze).GetMethod("AddGazeIntent", ~BindingFlags.Default));
    }
  }
}
