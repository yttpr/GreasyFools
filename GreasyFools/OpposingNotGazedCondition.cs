// Decompiled with JetBrains decompiler
// Type: GreasyFools.OpposingNotGazedCondition
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;

#nullable disable
namespace GreasyFools
{
  public class OpposingNotGazedCondition : EffectConditionSO
  {
    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter))
      {
        if (target.HasUnit && target.Unit.ContainsStatusEffect((StatusEffectType) Gaze.Type, 0))
          return false;
      }
      return true;
    }
  }
}
