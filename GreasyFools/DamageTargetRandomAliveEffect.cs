// Decompiled with JetBrains decompiler
// Type: GreasyFools.DamageTargetRandomAliveEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class DamageTargetRandomAliveEffect : EffectSO
  {
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this._usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.IsAlive)
          targetSlotInfoList.Add(target);
      }
      if (targetSlotInfoList.Count <= 0)
        return false;
      int index = Random.Range(0, targetSlotInfoList.Count);
      TargetSlotInfo targetSlotInfo = targetSlotInfoList[index];
      int num1 = areTargetSlots ? targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID : -1;
      int num2 = entryVariable;
      DamageInfo damageInfo;
      if (this._indirect)
      {
        damageInfo = targetSlotInfo.Unit.Damage(num2, (IUnit) null, (DeathType) 1, num1, false, false, true, (DamageType) 0);
      }
      else
      {
        int num3 = caster.WillApplyDamage(num2, targetSlotInfo.Unit);
        damageInfo = targetSlotInfo.Unit.Damage(num3, caster, (DeathType) 1, num1, true, true, this._ignoreShield, (DamageType) 0);
      }
      exitAmount = damageInfo.damageAmount;
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
