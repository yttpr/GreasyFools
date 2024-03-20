// Decompiled with JetBrains decompiler
// Type: GreasyFools.MoreDamageIfEdgeEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System;

#nullable disable
namespace GreasyFools
{
  public class MoreDamageIfEdgeEffect : DamageEffect
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int num = (int) Math.Ceiling((double) ((float) entryVariable * 2f));
      return base.PerformEffect(stats, caster, targets, areTargetSlots, caster.SlotID == 0 || caster.SlotID == 4 ? num : entryVariable, out exitAmount);
    }
  }
}
