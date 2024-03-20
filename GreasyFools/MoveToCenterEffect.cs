// Decompiled with JetBrains decompiler
// Type: GreasyFools.MoveToCenterEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class MoveToCenterEffect : SwapToOneSideEffect
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
        if (target.HasUnit && (target.Unit.Size != 1 || target.Unit.SlotID != 2) && (target.Unit.Size != 3 || target.Unit.SlotID != 1) && target.Unit.Size < 5)
        {
          if (target.Unit.Size >= 4 && target.Unit.SlotID > 0)
          {
            this._swapRight = false;
            int num;
            base.PerformEffect(stats, caster, target.SelfArray<TargetSlotInfo>(), areTargetSlots, entryVariable, out num);
            exitAmount += num;
          }
          else if (target.Unit.SlotID < 2)
          {
            this._swapRight = true;
            int num;
            base.PerformEffect(stats, caster, target.SelfArray<TargetSlotInfo>(), areTargetSlots, entryVariable, out num);
            exitAmount += num;
          }
          else if (target.Unit.SlotID == 2 && target.Unit.Size == 2)
          {
            this._swapRight = false;
            int num;
            base.PerformEffect(stats, caster, target.SelfArray<TargetSlotInfo>(), areTargetSlots, entryVariable, out num);
            exitAmount += num;
          }
          else if (target.Unit.SlotID > 2)
          {
            this._swapRight = false;
            int num;
            base.PerformEffect(stats, caster, target.SelfArray<TargetSlotInfo>(), areTargetSlots, entryVariable, out num);
            exitAmount += num;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
