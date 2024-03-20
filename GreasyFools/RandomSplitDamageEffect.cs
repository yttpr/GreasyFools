// Decompiled with JetBrains decompiler
// Type: GreasyFools.RandomSplitDamageEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class RandomSplitDamageEffect : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = (DeathType) 1;
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect;
    [SerializeField]
    public bool _returnKillAsSuccess;

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
      if (entryVariable <= 0)
        return false;
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
          targetSlotInfoList.Add(target);
      }
      if (targetSlotInfoList.Count <= 0)
        return false;
      TargetSlotInfo targetSlotInfo = targetSlotInfoList[Random.Range(0, targetSlotInfoList.Count)];
      bool flag1 = false;
      if (targetSlotInfo.HasUnit)
      {
        int num1 = areTargetSlots ? targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID : -1;
        int num2 = entryVariable;
        DamageInfo damageInfo;
        if (this._indirect)
        {
          damageInfo = targetSlotInfo.Unit.Damage(num2, (IUnit) null, this._deathType, num1, false, false, true, (DamageType) 0);
        }
        else
        {
          int num3 = caster.WillApplyDamage(num2, targetSlotInfo.Unit);
          damageInfo = targetSlotInfo.Unit.Damage(num3, caster, this._deathType, num1, true, true, this._ignoreShield, (DamageType) 0);
        }
        flag1 |= damageInfo.beenKilled;
        exitAmount += damageInfo.damageAmount;
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      bool flag2 = caster.IsUnitCharacter == targetSlotInfo.Unit.IsUnitCharacter;
      Targetting_ByUnit_Side instance1 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance1.getAllies = flag2;
      instance1.getAllUnitSlots = false;
      RandomSplitDamageEffect instance2 = ScriptableObject.CreateInstance<RandomSplitDamageEffect>();
      instance2._indirect = true;
      if (exitAmount < entryVariable)
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) instance2, entryVariable - exitAmount, new IntentType?(), (BaseCombatTargettingSO) instance1)
        }), caster, 0));
      return !this._returnKillAsSuccess ? exitAmount > 0 : flag1;
    }
  }
}
