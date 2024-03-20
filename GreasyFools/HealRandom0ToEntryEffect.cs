// Decompiled with JetBrains decompiler
// Type: GreasyFools.HealRandom0ToEntryEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class HealRandom0ToEntryEffect : HealEffect
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
        int num;
        if (base.PerformEffect(stats, caster, target.SelfArray<TargetSlotInfo>(), areTargetSlots, Random.Range(0, entryVariable + 1), out num))
          exitAmount += num;
      }
      return exitAmount > 0;
    }
  }
}
