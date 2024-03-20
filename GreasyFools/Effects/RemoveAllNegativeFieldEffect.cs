// Decompiled with JetBrains decompiler
// Type: GreasyFools.Effects.RemoveAllNegativeFieldEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System.Collections.Generic;

#nullable disable
namespace GreasyFools.Effects
{
  public class RemoveAllNegativeFieldEffect : EffectSO
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
              using (List<ISlotStatusEffect>.Enumerator enumerator = new List<ISlotStatusEffect>((IEnumerable<ISlotStatusEffect>) characterSlot.StatusEffects).GetEnumerator())
              {
                while (enumerator.MoveNext())
                {
                  ISlotStatusEffect current = enumerator.Current;
                  if (!current.IsPositive)
                    exitAmount += characterSlot.TryRemoveSlotStatusEffect(current.EffectType);
                }
                break;
              }
            }
          }
        }
        else
        {
          foreach (CombatSlot enemySlot in stats.combatSlots.EnemySlots)
          {
            if (enemySlot.SlotID == target.SlotID)
            {
              using (List<ISlotStatusEffect>.Enumerator enumerator = new List<ISlotStatusEffect>((IEnumerable<ISlotStatusEffect>) enemySlot.StatusEffects).GetEnumerator())
              {
                while (enumerator.MoveNext())
                {
                  ISlotStatusEffect current = enumerator.Current;
                  if (!current.IsPositive)
                    exitAmount += enemySlot.TryRemoveSlotStatusEffect(current.EffectType);
                }
                break;
              }
            }
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
