// Decompiled with JetBrains decompiler
// Type: GreasyFools.EZExtensions
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class EZExtensions
  {
    public static T GetRandom<T>(this T[] array)
    {
      return array.Length == 0 ? default (T) : array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static T GetRandom<T>(this List<T> list)
    {
      return list.Count <= 0 ? default (T) : list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static T[] SelfArray<T>(this T self)
    {
      return new T[1]{ self };
    }

    public static int GetStatus(this IUnit self, StatusEffectType type)
    {
      if (self is IStatusEffector istatusEffector)
      {
        foreach (IStatusEffect statusEffect in istatusEffector.StatusEffects)
        {
          if (statusEffect.EffectType == type)
            return statusEffect.StatusContent;
        }
      }
      return 0;
    }

    public static Type[] GetAllDerived(Type baze)
    {
      List<Type> typeList = new List<Type>();
      foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        foreach (Type type in assembly.GetTypes())
        {
          if (baze.IsAssignableFrom(type) && !typeList.Contains(type) && type != baze)
            typeList.Add(type);
        }
      }
      return typeList.ToArray();
    }

    public static bool PCall(Action orig, string name = null)
    {
      try
      {
        orig();
      }
      catch (Exception ex)
      {
        Debug.LogError(name != null ? (object) (name + " failed") : (object) (orig.ToString() + " failed"));
        Debug.LogError((object) (ex.ToString() + ex.Message + ex.StackTrace));
        return false;
      }
      return true;
    }
  }
}
