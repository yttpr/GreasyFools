// Decompiled with JetBrains decompiler
// Type: GreasyFools.Deflect_StatusEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using System;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class Deflect_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
  {
    public int StatusContent => this.Amount;

    public int Restrictor { get; set; }

    public bool CanBeRemoved => this.Restrictor <= 0;

    public bool IsPositive => true;

    public string DisplayText
    {
      get
      {
        string displayText = "";
        if (this.Amount > 0)
          displayText += this.Amount.ToString();
        if (this.Restrictor > 0)
          displayText = displayText + "(" + this.Restrictor.ToString() + ")";
        return displayText;
      }
    }

    public int Amount { get; set; }

    public StatusEffectType EffectType => (StatusEffectType) 65752;

    public StatusEffectInfoSO EffectInfo { get; set; }

    public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

    public bool CanReduceDuration
    {
      get
      {
        BooleanReference booleanReference = new BooleanReference(true);
        CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new CheckHasStatusFieldReductionBlockIAction(booleanReference), false);
        return !booleanReference.value;
      }
    }

    public Deflect_StatusEffect(int amount, int restrictors = 0)
    {
      this.Amount = amount;
      this.Restrictor = restrictors;
    }

    public bool AddContent(IStatusEffect content)
    {
      this.Amount += (content as Deflect_StatusEffect).Amount;
      this.Restrictor += content.Restrictor;
      return true;
    }

    public bool TryAddContent(int amount)
    {
      bool flag;
      if (this.Amount <= 0)
      {
        flag = false;
      }
      else
      {
        this.Amount += amount;
        flag = true;
      }
      return flag;
    }

    public int JustRemoveAllContent()
    {
      int amount = this.Amount;
      this.Amount = 0;
      return amount;
    }

    public void OnTriggerAttached(IStatusEffector caller)
    {
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnBeingDamaged), ((TriggerCalls) 6).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusEffectApplied), ((TriggerCalls) 648797).ToString(), (object) caller);
    }

    public void OnTriggerDettached(IStatusEffector caller)
    {
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnBeingDamaged), ((TriggerCalls) 6).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusEffectApplied), ((TriggerCalls) 648797).ToString(), (object) caller);
    }

    public void DeleteDuration(IStatusEffector effector)
    {
      int amount = this.Amount;
      this.Amount = 0;
      if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
        return;
      effector.StatusEffectValuesChanged(this.EffectType, this.Amount - this.Amount);
    }

    public void OnSubActionTrigger(object sender, object args, bool stateCheck)
    {
      this.DeleteDuration(sender as IStatusEffector);
    }

    public void OnBeingDamaged(object sender, object args)
    {
      DamageReceivedValueChangeException valueChangeException = args as DamageReceivedValueChangeException;
      if ((args as DamageReceivedValueChangeException).amount <= 0 || !(args as DamageReceivedValueChangeException).directDamage)
        return;
      if ((args as DamageReceivedValueChangeException).amount >= this.Amount)
      {
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), this.Amount, new IntentType?(), Slots.SlotTarget(new int[1]))
        }), sender as IUnit, 0));
        (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier) new DeflectValueModifier(this.Amount));
      }
      if ((args as DamageReceivedValueChangeException).amount < this.Amount)
      {
        int amount = (args as DamageReceivedValueChangeException).amount;
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), amount, new IntentType?(), Slots.SlotTarget(new int[1]))
        }), sender as IUnit, 0));
        (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier) new DeflectValueModifier((args as DamageReceivedValueChangeException).amount));
      }
      CombatManager.Instance.AddSubAction((CombatAction) new PerformStatusEffectAction((IStatusEffect) this, sender, args, false));
    }

    public void OnStatusEffectApplied(object sender, object args)
    {
      CustomeIStatusEffectRefrence istatusEffectRefrence = args as CustomeIStatusEffectRefrence;
      ReflectStatusEffectEffect instance = ScriptableObject.CreateInstance<ReflectStatusEffectEffect>();
      instance._statusEffect = istatusEffectRefrence.statusEffect;
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance, istatusEffectRefrence.amount, new IntentType?(), Slots.SlotTarget(new int[1]))
      }), sender as IUnit, 0));
      this.DeleteDuration(sender as IStatusEffector);
    }

    public void ReduceDuration(IStatusEffector effector)
    {
      if (!this.CanReduceDuration)
        return;
      int amount = this.Amount;
      this.Amount /= 2;
      if (!this.TryRemoveStatusEffect(effector) && amount != this.Amount)
        effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
    }

    public void DettachRestrictor(IStatusEffector effector)
    {
      --this.Restrictor;
      if (this.TryRemoveStatusEffect(effector))
        return;
      effector.StatusEffectValuesChanged(this.EffectType, 0);
    }

    public bool TryRemoveStatusEffect(IStatusEffector effector)
    {
      bool flag;
      if (this.Amount > 0 || !this.CanBeRemoved)
      {
        flag = false;
      }
      else
      {
        effector.RemoveStatusEffect(this.EffectType);
        flag = true;
      }
      return flag;
    }
  }
}
