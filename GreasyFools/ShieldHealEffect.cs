// Decompiled with JetBrains decompiler
// Type: GreasyFools.ShieldHealEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  internal class ShieldHealEffect : EffectSO
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
      for (int index = 0; index < targets.Length; ++index)
      {
        bool hasUnit = targets[index].HasUnit;
        int num1 = 0;
        if (hasUnit)
        {
          if (targets[index].Unit is CharacterCombat)
          {
            if (stats.combatSlots.SlotContainsSlotStatusEffect(targets[index].Unit.SlotID, true, (SlotStatusEffectType) 0))
            {
              int num2 = num1 + stats.combatSlots.CharacterSlots[targets[index].Unit.SlotID].TryRemoveSlotStatusEffect((SlotStatusEffectType) 0);
              exitAmount += targets[index].Unit.Heal(num2, (HealType) 1, true);
            }
          }
          else if (targets[index].Unit is EnemyCombat && stats.combatSlots.SlotContainsSlotStatusEffect(targets[index].Unit.SlotID, true, (SlotStatusEffectType) 0))
          {
            int num3 = num1 + stats.combatSlots.EnemySlots[targets[index].Unit.SlotID].TryRemoveSlotStatusEffect((SlotStatusEffectType) 0);
            exitAmount += targets[index].Unit.Heal(num3, (HealType) 1, true);
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
