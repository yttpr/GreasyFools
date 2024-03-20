// Decompiled with JetBrains decompiler
// Type: GreasyFools.ApplyDeflectEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System;
using System.Reflection;

#nullable disable
namespace GreasyFools
{
  internal class ApplyDeflectEffect : EffectSO
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
      bool flag1;
      if (entryVariable <= 0)
      {
        flag1 = false;
      }
      else
      {
        StatusEffectInfoSO statusEffectInfoSo;
        stats.statusEffectDataBase.TryGetValue((StatusEffectType) 65752, out statusEffectInfoSo);
        for (int index1 = 0; index1 < targets.Length; ++index1)
        {
          if (targets[index1].HasUnit)
          {
            IStatusEffect istatusEffect = (IStatusEffect) new Deflect_StatusEffect(entryVariable);
            IStatusEffector unit = targets[index1].Unit as IStatusEffector;
            bool flag2 = false;
            int index2 = 999;
            for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
            {
              if (unit.StatusEffects[index3].EffectType == istatusEffect.EffectType)
              {
                index2 = index3;
                flag2 = true;
              }
            }
            if (flag2 && istatusEffect.GetType() != unit.StatusEffects[index2].GetType())
            {
              foreach (MethodBase constructor in unit.StatusEffects[index2].GetType().GetConstructors())
              {
                if (constructor.GetParameters().Length == 2)
                  istatusEffect = (IStatusEffect) Activator.CreateInstance(unit.StatusEffects[index2].GetType(), (object) entryVariable, (object) 0);
              }
            }
            istatusEffect.SetEffectInformation(statusEffectInfoSo);
            if (targets[index1].Unit.ApplyStatusEffect(istatusEffect, entryVariable))
              ++exitAmount;
          }
        }
        flag1 = exitAmount > 0;
      }
      return flag1;
    }
  }
}
