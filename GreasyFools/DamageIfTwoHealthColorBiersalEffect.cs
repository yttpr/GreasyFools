// Decompiled with JetBrains decompiler
// Type: GreasyFools.DamageIfTwoHealthColorBiersalEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class DamageIfTwoHealthColorBiersalEffect : EffectSO
  {
    public int _PurpleDamage;
    public int _RedDamage;

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
        if (target.HasUnit && (Object) target.Unit.HealthColor == (Object) Pigments.Yellow)
        {
          int num1 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num2 = caster.WillApplyDamage(entryVariable, target.Unit);
          DamageInfo damageInfo = target.Unit.Damage(num2, caster, (DeathType) 1, num1, true, true, false, (DamageType) 2);
          exitAmount += damageInfo.damageAmount;
        }
        if (target.HasUnit && (Object) target.Unit.HealthColor == (Object) Pigments.Blue)
        {
          int num3 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num4 = caster.WillApplyDamage(entryVariable, target.Unit);
          DamageInfo damageInfo = target.Unit.Damage(num4, caster, (DeathType) 1, num3, true, true, false, (DamageType) 2);
          exitAmount += damageInfo.damageAmount;
        }
        if (target.HasUnit && (Object) target.Unit.HealthColor == (Object) Pigments.Purple)
        {
          int num5 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num6 = caster.WillApplyDamage(this._PurpleDamage, target.Unit);
          DamageInfo damageInfo = target.Unit.Damage(num6, caster, (DeathType) 1, num5, true, true, false, (DamageType) 2);
          exitAmount += damageInfo.damageAmount;
        }
        if (target.HasUnit && (Object) target.Unit.HealthColor == (Object) Pigments.Red)
        {
          int num7 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num8 = caster.WillApplyDamage(this._RedDamage, target.Unit);
          DamageInfo damageInfo = target.Unit.Damage(num8, caster, (DeathType) 1, num7, true, true, false, (DamageType) 2);
          exitAmount += damageInfo.damageAmount;
        }
        if (target.HasUnit && (Object) target.Unit.HealthColor == (Object) Pigments.Gray)
        {
          int num9 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num10 = caster.WillApplyDamage(6, target.Unit);
          DamageInfo damageInfo = target.Unit.Damage(num10, caster, (DeathType) 1, num9, true, true, false, (DamageType) 2);
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
