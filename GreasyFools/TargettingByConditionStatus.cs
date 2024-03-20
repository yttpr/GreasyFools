// Decompiled with JetBrains decompiler
// Type: GreasyFools.TargettingByConditionStatus
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class TargettingByConditionStatus : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO orig;
    public StatusEffectType status = (StatusEffectType) 1;
    public bool Has;
    public bool EmptySlots;

    public override bool AreTargetAllies => this.orig.AreTargetAllies;

    public override bool AreTargetSlots => this.orig.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.orig.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit && this.Has == targetSlotInfo.Unit.ContainsStatusEffect(this.status, 0))
          targetSlotInfoList.Add(targetSlotInfo);
        else if (!targetSlotInfo.HasUnit && this.EmptySlots)
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }

    public static TargettingByConditionStatus Create(
      BaseCombatTargettingSO orig,
      StatusEffectType status,
      bool Has = true,
      bool empties = false)
    {
      TargettingByConditionStatus instance = ScriptableObject.CreateInstance<TargettingByConditionStatus>();
      instance.orig = orig;
      instance.status = status;
      instance.Has = Has;
      instance.EmptySlots = empties;
      return instance;
    }
  }
}
