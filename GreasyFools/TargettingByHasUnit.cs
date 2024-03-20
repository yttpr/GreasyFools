// Decompiled with JetBrains decompiler
// Type: GreasyFools.TargettingByHasUnit
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class TargettingByHasUnit : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO source;

    public override bool AreTargetAllies => this.source.AreTargetAllies;

    public override bool AreTargetSlots => this.source.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.source.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit)
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }

    public static TargettingByHasUnit Create(BaseCombatTargettingSO orig)
    {
      TargettingByHasUnit instance = ScriptableObject.CreateInstance<TargettingByHasUnit>();
      instance.source = orig;
      return instance;
    }
  }
}
