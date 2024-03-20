// Decompiled with JetBrains decompiler
// Type: GreasyFools.MultiCondition
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class MultiCondition : EffectConditionSO
  {
    public EffectConditionSO[] conditions;
    public bool And = true;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      foreach (EffectConditionSO condition in this.conditions)
      {
        bool flag = condition.MeetCondition(caster, effects, currentIndex);
        if (this.And && !flag)
          return false;
        if (!this.And & flag)
          return true;
      }
      return this.And;
    }

    public static MultiCondition Create(EffectConditionSO[] cond, bool and = true)
    {
      MultiCondition instance = ScriptableObject.CreateInstance<MultiCondition>();
      instance.conditions = cond;
      instance.And = and;
      return instance;
    }

    public static MultiCondition Create(
      EffectConditionSO first,
      EffectConditionSO second,
      bool and = true)
    {
      MultiCondition instance = ScriptableObject.CreateInstance<MultiCondition>();
      instance.conditions = new EffectConditionSO[2]
      {
        first,
        second
      };
      instance.And = and;
      return instance;
    }
  }
}
