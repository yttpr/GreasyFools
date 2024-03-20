// Decompiled with JetBrains decompiler
// Type: GreasyFools.RemvoeRandomActionsFromTimelineEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class RemvoeRandomActionsFromTimelineEffect : EffectSO
  {
    public static int TryRemoveRandomAnyTurns(Timeline self, int turnsToRemove)
    {
      if (self.Round.Count <= 0)
        return 0;
      List<int> intList1 = new List<int>();
      for (int index = self.CurrentTurn + 1; index < self.Round.Count; ++index)
        intList1.Add(index);
      List<int> intList2 = new List<int>();
      int num = 0;
      for (; turnsToRemove > 0 && intList1.Count > 0; --turnsToRemove)
      {
        int index = Random.Range(0, intList1.Count);
        intList2.Add(intList1[index]);
        intList1.RemoveAt(index);
        ++num;
      }
      intList2.Sort();
      intList2.Reverse();
      foreach (int index in intList2)
        self.Round.RemoveAt(index);
      TurnUIInfo[] turnUiInfoArray1 = new TurnUIInfo[self.Round.Count - 1];
      for (int index1 = 1; index1 < self.Round.Count; ++index1)
      {
        TurnUIInfo[] turnUiInfoArray2 = turnUiInfoArray1;
        int index2 = index1 - 1;
        TurnInfo turnInfo = self.Round[index1];
        TurnUIInfo turnUiInfo = ((TurnInfo)  turnInfo).GenerateTurnUIInfo(index1, self.IsConfused);
        turnUiInfoArray2[index2] = turnUiInfo;
      }
      if (intList2.Count > 0)
      {
        CombatManager.Instance.AddUIAction((CombatAction) new RemoveSlotTimelineUIAction(turnUiInfoArray1, intList2.ToArray()));
        CombatManager.Instance.AddUIAction((CombatAction) new UpdateTimelinePointerUIAction(self.CurrentTurn));
      }
      return num;
    }

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = RemvoeRandomActionsFromTimelineEffect.TryRemoveRandomAnyTurns(stats.timeline, entryVariable);
      return exitAmount > 0;
    }
  }
}
