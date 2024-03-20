// Decompiled with JetBrains decompiler
// Type: GreasyFools.ShieldExitValueGetterEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class ShieldExitValueGetterEffect : EffectSO
  {
    [SerializeField]
    public bool _Noheal;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      for (int index = 0; index < targets.Length; ++index)
      {
        bool hasUnit = targets[index].HasUnit;
        int num = 0;
        if (hasUnit)
        {
          SlotStatusEffectInfoSO statusEffectInfoSo;
          stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 0, out statusEffectInfoSo);
          if (targets[index].Unit is CharacterCombat)
          {
            if (stats.combatSlots.SlotContainsSlotStatusEffect(targets[index].Unit.SlotID, true, (SlotStatusEffectType) 0))
            {
              num += stats.combatSlots.CharacterSlots[targets[index].Unit.SlotID].TryRemoveSlotStatusEffect((SlotStatusEffectType) 0);
              Shield_SlotStatusEffect slotStatusEffect = new Shield_SlotStatusEffect(targets[index].SlotID, num, targets[index].IsTargetCharacterSlot, 0);
              slotStatusEffect.SetEffectInformation(statusEffectInfoSo);
              if (stats.combatSlots.ApplySlotStatusEffect(targets[index].SlotID, targets[index].IsTargetCharacterSlot, num, (ISlotStatusEffect) slotStatusEffect, 1))
                exitAmount += targets[index].Unit.Heal(num, (HealType) 1, true);
            }
          }
          else if (targets[index].Unit is EnemyCombat && stats.combatSlots.SlotContainsSlotStatusEffect(targets[index].Unit.SlotID, true, (SlotStatusEffectType) 0))
          {
            num += stats.combatSlots.EnemySlots[targets[index].Unit.SlotID].TryRemoveSlotStatusEffect((SlotStatusEffectType) 0);
            Shield_SlotStatusEffect slotStatusEffect = new Shield_SlotStatusEffect(targets[index].SlotID, num, targets[index].IsTargetCharacterSlot, 0);
            slotStatusEffect.SetEffectInformation(statusEffectInfoSo);
            if (stats.combatSlots.ApplySlotStatusEffect(targets[index].SlotID, targets[index].IsTargetCharacterSlot, num, (ISlotStatusEffect) slotStatusEffect, 1) && !this._Noheal)
              exitAmount += targets[index].Unit.Heal(num, (HealType) 1, true);
          }
          if (this._Noheal)
            exitAmount += num;
        }
      }
      return exitAmount > 0;
    }
  }
}
