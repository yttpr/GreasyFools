// Decompiled with JetBrains decompiler
// Type: GreasyFools.CustomeIStatusEffectRefrence
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class CustomeIStatusEffectRefrence
  {
    public IStatusEffect statusEffect;
    public StatusEffectType statusEffectType;
    public bool isStatusPositive;
    public bool value;
    public int amount;

    public CustomeIStatusEffectRefrence(IStatusEffect statusEffect, int amountToApply)
    {
      this.statusEffect = statusEffect;
      this.statusEffectType = this.statusEffect.EffectType;
      this.isStatusPositive = this.statusEffect.IsPositive;
      this.value = true;
      this.amount = amountToApply;
    }
  }
}
