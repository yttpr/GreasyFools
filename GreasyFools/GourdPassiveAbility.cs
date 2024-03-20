// Decompiled with JetBrains decompiler
// Type: GreasyFools.GourdPassiveAbility
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class GourdPassiveAbility : BasePassiveAbilitySO
  {
    public static UnitStoredValueNames Hidden => (UnitStoredValueNames) 43991;

    public static UnitStoredValueNames Value => (UnitStoredValueNames) 43972;

    public override bool DoesPassiveTrigger => true;

    public override bool IsPassiveImmediate => true;

    public override void TriggerPassive(object sender, object args)
    {
      if (!(sender is IUnit iunit))
        return;
      if (args is CanHealReference canHealReference)
      {
        if (iunit.GetStoredValue(GourdPassiveAbility.Hidden) > 0)
          return;
        CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(iunit.ID, iunit.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
        canHealReference.value = false;
      }
      else
      {
        int storedValue = iunit.GetStoredValue(GourdPassiveAbility.Value);
        iunit.SetStoredValue(GourdPassiveAbility.Value, storedValue + 1);
        if (storedValue + 1 == 2)
          CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(iunit.ID, (ExtraSpriteType) 43991));
      }
    }

    public override void OnPassiveConnected(IUnit unit)
    {
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
