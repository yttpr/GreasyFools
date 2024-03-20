// Decompiled with JetBrains decompiler
// Type: GreasyFools.DamagePlusExitEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class DamagePlusExitEffect : DamageEffect
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable + ((EffectSO) this).PreviousExitValue, out exitAmount);
    }
  }
}
