// Decompiled with JetBrains decompiler
// Type: GreasyFools.AbilityNameFix
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace GreasyFools
{
  public static class AbilityNameFix
  {
    public static global::CharacterAbility CharacterAbility(
      Func<Ability, global::CharacterAbility> orig,
      Ability self)
    {
      global::CharacterAbility characterAbility = orig(self);
      characterAbility.ability._abilityName = self.name;
      characterAbility.ability._description = self.description;
      ((UnityEngine.Object) characterAbility.ability).name = self.name;
      return characterAbility;
    }

    public static EnemyAbilityInfo EnemyAbility(Func<Ability, EnemyAbilityInfo> orig, Ability self)
    {
      EnemyAbilityInfo enemyAbilityInfo = orig(self);
      enemyAbilityInfo.ability._abilityName = self.name;
      enemyAbilityInfo.ability._description = self.description;
      ((UnityEngine.Object) enemyAbilityInfo.ability).name = self.name;
      return enemyAbilityInfo;
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (Ability).GetMethod("CharacterAbility", ~BindingFlags.Default), typeof (AbilityNameFix).GetMethod("CharacterAbility", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (Ability).GetMethod("EnemyAbility", ~BindingFlags.Default), typeof (AbilityNameFix).GetMethod("EnemyAbility", ~BindingFlags.Default));
    }
  }
}
