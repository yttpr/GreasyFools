// Decompiled with JetBrains decompiler
// Type: GreasyFools.CasterLowerStoredValueEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class CasterLowerStoredValueEffect : EffectSO
  {
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 2;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      int num = caster.GetStoredValue(this._valueName) - entryVariable;
      if (num < 0)
        num = 0;
      caster.SetStoredValue(this._valueName, num);
      return exitAmount > 0;
    }
  }
}
