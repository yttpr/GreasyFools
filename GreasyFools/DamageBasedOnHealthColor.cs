// Decompiled with JetBrains decompiler
// Type: GreasyFools.DamageBasedOnHealthColor
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class DamageBasedOnHealthColor : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = (DeathType) 1;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect;
    [SerializeField]
    public DamageifPigment[] manaDamages;

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
        bool flag = true;
        if (target.HasUnit)
        {
          int num1 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          for (int index = 0; index < this.manaDamages.Length; ++index)
          {
            if (target.HasUnit && (Object) target.Unit.HealthColor == (Object) this.manaDamages[index].pigmentColor)
            {
              if (this._indirect)
              {
                exitAmount += target.Unit.Damage(this.manaDamages[index].damage, (IUnit) null, this._deathType, num1, false, false, true, (DamageType) 0).damageAmount;
              }
              else
              {
                int num2 = caster.WillApplyDamage(this.manaDamages[index].damage, target.Unit);
                exitAmount += target.Unit.Damage(num2, caster, this._deathType, num1, true, true, this._ignoreShield, (DamageType) 0).damageAmount;
              }
              flag = false;
            }
          }
          if (flag)
          {
            if (this._indirect)
            {
              exitAmount += target.Unit.Damage(entryVariable, (IUnit) null, this._deathType, num1, false, false, true, (DamageType) 0).damageAmount;
            }
            else
            {
              int num3 = caster.WillApplyDamage(entryVariable, target.Unit);
              exitAmount += target.Unit.Damage(num3, caster, this._deathType, num1, true, true, this._ignoreShield, (DamageType) 0).damageAmount;
            }
          }
        }
      }
      if (exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
