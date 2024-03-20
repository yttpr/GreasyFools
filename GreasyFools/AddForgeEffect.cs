// Decompiled with JetBrains decompiler
// Type: GreasyFools.AddForgeEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class AddForgeEffect : EffectSO
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
        if (target.HasUnit)
        {
          target.Unit.SetStoredValue(ForgeHandler.Forge, target.Unit.GetStoredValue(ForgeHandler.Forge) + entryVariable);
          exitAmount += entryVariable;
        }
      }
      return exitAmount > 0;
    }
  }
}
