// Decompiled with JetBrains decompiler
// Type: GreasyFools.RemoveAllFieldEffectEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  internal class RemoveAllFieldEffectEffect : EffectSO
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
        if (targets[index].HasUnit)
        {
          if (targets[index].Unit is CharacterCombat)
            exitAmount += stats.combatSlots.CharacterSlots[targets[index].Unit.SlotID].TryRemoveSlotStatusEffect((SlotStatusEffectType) 0);
          else if (targets[index].Unit is EnemyCombat)
            exitAmount += stats.combatSlots.EnemySlots[targets[index].Unit.SlotID].TryRemoveSlotStatusEffect((SlotStatusEffectType) 0);
        }
      }
      return exitAmount > 0;
    }
  }
}
