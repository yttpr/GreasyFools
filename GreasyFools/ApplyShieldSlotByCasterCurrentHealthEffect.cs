// Decompiled with JetBrains decompiler
// Type: GreasyFools.ApplyShieldSlotByCasterCurrentHealthEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class ApplyShieldSlotByCasterCurrentHealthEffect : EffectSO
  {
    [SerializeField]
    public bool _AddEntryVariable;
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public int _previousExtraAddition;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int num = 0;
      if (caster.IsAlive)
        num = caster.CurrentHealth;
      if (this._AddEntryVariable)
        num += entryVariable;
      if (this._usePreviousExitValue)
        num = this._previousExtraAddition + num * this.PreviousExitValue;
      exitAmount = 0;
      if (num <= 0)
        return false;
      SlotStatusEffectInfoSO statusEffectInfoSo;
      stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 0, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        Shield_SlotStatusEffect slotStatusEffect = new Shield_SlotStatusEffect(targets[index].SlotID, num, targets[index].IsTargetCharacterSlot, 0);
        slotStatusEffect.SetEffectInformation(statusEffectInfoSo);
        if (stats.combatSlots.ApplySlotStatusEffect(targets[index].SlotID, targets[index].IsTargetCharacterSlot, num, (ISlotStatusEffect) slotStatusEffect, 1))
          exitAmount += num;
      }
      return exitAmount > 0;
    }
  }
}
