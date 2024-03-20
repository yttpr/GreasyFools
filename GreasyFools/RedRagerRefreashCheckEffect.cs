// Decompiled with JetBrains decompiler
// Type: GreasyFools.RedRagerRefreashCheckEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class RedRagerRefreashCheckEffect : EffectSO
  {
    [SerializeField]
    public bool _increase = false;
    [SerializeField]
    public int _minimumValue = 0;
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 94512;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = caster.GetStoredValue(this._valueName);
      bool flag;
      if (exitAmount < entryVariable)
      {
        flag = false;
      }
      else
      {
        exitAmount += this._increase ? entryVariable : -entryVariable;
        exitAmount = Mathf.Max(this._minimumValue, exitAmount);
        caster.SetStoredValue(this._valueName, exitAmount);
        flag = true;
      }
      return flag;
    }
  }
}
