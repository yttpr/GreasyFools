// Decompiled with JetBrains decompiler
// Type: GreasyFools.ReflectStatusEffectEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class ReflectStatusEffectEffect : EffectSO
  {
    [SerializeField]
    public IStatusEffect _statusEffect;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.Unit.ApplyStatusEffect(this._statusEffect, entryVariable))
          exitAmount += entryVariable;
      }
      return exitAmount > 0;
    }
  }
}
