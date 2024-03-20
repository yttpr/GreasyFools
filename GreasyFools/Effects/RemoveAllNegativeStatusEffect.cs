// Decompiled with JetBrains decompiler
// Type: GreasyFools.Effects.RemoveAllNegativeStatusEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System.Collections.Generic;

#nullable disable
namespace GreasyFools.Effects
{
  public class RemoveAllNegativeStatusEffect : EffectSO
  {
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
        if (target.HasUnit && target.Unit is IStatusEffector unit)
        {
          foreach (IStatusEffect istatusEffect in new List<IStatusEffect>((IEnumerable<IStatusEffect>) unit.StatusEffects))
          {
            if (!istatusEffect.IsPositive)
              exitAmount += target.Unit.TryRemoveStatusEffect(istatusEffect.EffectType);
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
