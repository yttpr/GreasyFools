// Decompiled with JetBrains decompiler
// Type: GreasyFools.RemoveConstrictedEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class RemoveConstrictedEffect : EffectSO
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
        if (target.IsTargetCharacterSlot)
        {
          foreach (CombatSlot characterSlot in stats.combatSlots.CharacterSlots)
          {
            if (characterSlot.SlotID == target.SlotID)
            {
              exitAmount += characterSlot.TryRemoveSlotStatusEffect((SlotStatusEffectType) 1);
            }
            else
            {
              foreach (CombatSlot enemySlot in stats.combatSlots.EnemySlots)
              {
                if (enemySlot.SlotID == target.SlotID)
                  exitAmount += enemySlot.TryRemoveSlotStatusEffect((SlotStatusEffectType) 1);
              }
            }
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
