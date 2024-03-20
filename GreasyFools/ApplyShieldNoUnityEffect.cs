// Decompiled with JetBrains decompiler
// Type: GreasyFools.ApplyShieldNoUnityEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class ApplyShieldNoUnityEffect : EffectSO
  {
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
      if (this._usePreviousExitValue)
        entryVariable = this._previousExtraAddition + entryVariable * this.PreviousExitValue;
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      SlotStatusEffectInfoSO statusEffectInfoSo;
      stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 0, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        Shield_SlotStatusEffect slotStatusEffect = new Shield_SlotStatusEffect(targets[index].SlotID, entryVariable, targets[index].IsTargetCharacterSlot, 0);
        slotStatusEffect.SetEffectInformation(statusEffectInfoSo);
        if (stats.combatSlots.ApplySlotStatusEffect(targets[index].SlotID, targets[index].IsTargetCharacterSlot, entryVariable, (ISlotStatusEffect) slotStatusEffect, 1))
          exitAmount += entryVariable;
      }
      return exitAmount > 0;
    }
  }
}
