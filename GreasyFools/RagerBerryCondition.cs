// Decompiled with JetBrains decompiler
// Type: GreasyFools.RagerBerryCondition
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class RagerBerryCondition : EffectorConditionSO
  {
    public static TriggerCalls willHeal = (TriggerCalls) 2801035;
    public static Sprite icon = ResourceLoader.LoadSprite("OMEGA_sleepstatus.png");

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      switch (args)
      {
        case DamageDealtValueChangeException valueChangeException1:
          valueChangeException1.AddModifier((IntValueModifier) new MultiplyIntValueModifier(true, 2));
          CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(effector.ID, effector.IsUnitCharacter, "OMEGA Sleepy Rager", RagerBerryCondition.icon));
          return false;
        case IntValueChangeException valueChangeException2:
          valueChangeException2.AddModifier((IntValueModifier) new MultiplyIntValueModifier(true, 2));
          CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(effector.ID, effector.IsUnitCharacter, "OMEGA Sleepy Rager", RagerBerryCondition.icon));
          return false;
        default:
          return true;
      }
    }
  }
}
