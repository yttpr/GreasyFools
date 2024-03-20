// Decompiled with JetBrains decompiler
// Type: GreasyFools.DamageIfNotFrailEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System.Collections.Generic;

#nullable disable
namespace GreasyFools
{
  public class DamageIfNotFrailEffect : DamageEffect
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in targets)
      {
        if (!target.HasUnit || !target.Unit.ContainsStatusEffect((StatusEffectType) 1, 0))
          targetSlotInfoList.Add(target);
      }
      return base.PerformEffect(stats, caster, targetSlotInfoList.ToArray(), areTargetSlots, entryVariable, out exitAmount);
    }
  }
}
