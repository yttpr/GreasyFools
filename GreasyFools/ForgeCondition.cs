// Decompiled with JetBrains decompiler
// Type: GreasyFools.ForgeCondition
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class ForgeCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is DamageDealtValueChangeException valueChangeException)
      {
        int storedValue = (effector as IUnit).GetStoredValue(ForgeHandler.Forge);
        valueChangeException.AddModifier((IntValueModifier) new AdditionValueModifier(true, storedValue));
      }
      return true;
    }
  }
}
