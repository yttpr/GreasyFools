// Decompiled with JetBrains decompiler
// Type: GreasyFools.RemoveAllNegativeStatusEffectsDamageEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class RemoveAllNegativeStatusEffectsDamageEffect : EffectSO
  {
    [SerializeField]
    public int _timesAmount = 2;

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
        int num1 = 0;
        if (target.HasUnit)
        {
          if (target.Unit is IStatusEffector unit)
          {
            foreach (IStatusEffect statusEffect in unit.StatusEffects)
            {
              if (!statusEffect.IsPositive)
              {
                num1 += statusEffect.StatusContent;
                statusEffect.TryRemoveStatusEffect(unit);
              }
            }
          }
          int num2 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num3 = caster.WillApplyDamage(entryVariable + num1 * this._timesAmount, target.Unit);
          DamageInfo damageInfo = target.Unit.Damage(num3, caster, (DeathType) 1, num2, true, true, false, (DamageType) 2);
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
