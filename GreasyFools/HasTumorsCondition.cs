// Decompiled with JetBrains decompiler
// Type: GreasyFools.HasTumorsCondition
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class HasTumorsCondition : EffectConditionSO
  {
    public int amount;

    public static UnitStoredValueNames Value => GourdPassiveAbility.Value;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      return caster.GetStoredValue(HasTumorsCondition.Value) >= this.amount;
    }

    public static HasTumorsCondition Create(int amount)
    {
      HasTumorsCondition instance = ScriptableObject.CreateInstance<HasTumorsCondition>();
      instance.amount = amount;
      return instance;
    }
  }
}
