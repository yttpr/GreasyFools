// Decompiled with JetBrains decompiler
// Type: GreasyFools.WrongPigmentCondition
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class WrongPigmentCondition : EffectConditionSO
  {
    public bool used;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      return caster.LastCalculatedWrongMana > 0 == this.used;
    }

    public static WrongPigmentCondition Create(bool used)
    {
      WrongPigmentCondition instance = ScriptableObject.CreateInstance<WrongPigmentCondition>();
      instance.used = used;
      return instance;
    }
  }
}
