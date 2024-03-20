// Decompiled with JetBrains decompiler
// Type: GreasyFools.PreviousIfHealToFullHealth
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class PreviousIfHealToFullHealth : EffectSO
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
        if (target.HasUnit && target.Unit.IsAlive)
        {
          IntValueChangeException valueChangeException = new IntValueChangeException(entryVariable);
          CombatManager.Instance.PostNotification(RagerBerryCondition.willHeal.ToString(), (object) caster, (object) valueChangeException);
          valueChangeException.GetModifiedValue();
          target.Unit.Heal(entryVariable, (HealType) 1, true);
          if (target.Unit.CurrentHealth == target.Unit.MaximumHealth)
          {
            caster.RefreshAbilityUse();
            ++exitAmount;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
