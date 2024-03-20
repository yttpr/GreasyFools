// Decompiled with JetBrains decompiler
// Type: GreasyFools.ForgeHandler
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class ForgeHandler
  {
    private static BasePassiveAbilitySO _strength;

    public static UnitStoredValueNames Forge => (UnitStoredValueNames) 358016;

    public static BasePassiveAbilitySO Strength
    {
      get
      {
        if ((Object) ForgeHandler._strength == (Object) null)
        {
          PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
          ((BasePassiveAbilitySO) instance)._passiveName = nameof (Strength);
          ((BasePassiveAbilitySO) instance).passiveIcon = ResourceLoader.LoadSprite("StainFrontt.png");
          ((BasePassiveAbilitySO) instance)._characterDescription = "Increase direct damage by the amount of Strength.";
          ((BasePassiveAbilitySO) instance)._enemyDescription = ((BasePassiveAbilitySO) instance)._characterDescription;
          ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
          {
            (TriggerCalls) 16
          };
          ((BasePassiveAbilitySO) instance).type = (PassiveAbilityTypes) 358016;
          ((BasePassiveAbilitySO) instance).specialStoredValue = ForgeHandler.Forge;
          ((BasePassiveAbilitySO) instance).conditions = new EffectorConditionSO[1]
          {
            (EffectorConditionSO) ScriptableObject.CreateInstance<ForgeCondition>()
          };
          instance.effects = new EffectInfo[0];
          ((BasePassiveAbilitySO) instance).doesPassiveTriggerInformationPanel = false;
          ForgeHandler._strength = (BasePassiveAbilitySO) instance;
        }
        return ForgeHandler._strength;
      }
    }
  }
}
