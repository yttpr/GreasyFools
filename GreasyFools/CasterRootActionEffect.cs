// Decompiled with JetBrains decompiler
// Type: GreasyFools.CasterRootActionEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class CasterRootActionEffect : EffectSO
  {
    public Effect[] effects;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      EffectInfo[] effectInfoArray = ExtensionMethods.ToEffectInfoArray(this.effects);
      exitAmount = 0;
      CombatManager.Instance.AddRootAction((CombatAction) new EffectAction(effectInfoArray, caster, 0));
      return true;
    }

    public static CasterRootActionEffect Create(Effect[] e)
    {
      CasterRootActionEffect instance = ScriptableObject.CreateInstance<CasterRootActionEffect>();
      instance.effects = e;
      return instance;
    }
  }
}
