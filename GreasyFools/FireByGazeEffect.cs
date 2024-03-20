// Decompiled with JetBrains decompiler
// Type: GreasyFools.FireByGazeEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class FireByGazeEffect : ApplyFireSlotEffect
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
      SlotStatusEffectInfoSO statusEffectInfoSo;
      stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 2, out statusEffectInfoSo);
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.ContainsStatusEffect((StatusEffectType) Gaze.Type, 0))
        {
          OnFire_SlotStatusEffect slotStatusEffect = new OnFire_SlotStatusEffect(target.SlotID, 0, 1);
          slotStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (stats.combatSlots.ApplySlotStatusEffect(target.SlotID, target.IsTargetCharacterSlot, 0, (ISlotStatusEffect) slotStatusEffect, 1))
            exitAmount += entryVariable;
        }
        else
        {
          int num;
          if (base.PerformEffect(stats, caster, target.SelfArray<TargetSlotInfo>(), areTargetSlots, entryVariable, out num))
            exitAmount += num;
        }
      }
      return exitAmount > 0;
    }
  }
}
