// Decompiled with JetBrains decompiler
// Type: GreasyFools.CustomeStatusEffects
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class CustomeStatusEffects
  {
    public static StatusEffectInfoSO Deflect = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
    public static IntentInfoBasic DeflectIntent = new IntentInfoBasic();

    private static void AddDeflectStatusEffect(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      ((UnityEngine.Object) CustomeStatusEffects.Deflect).name = "Deflect";
      CustomeStatusEffects.Deflect.icon = ResourceLoader.LoadSprite("DeflectIcon");
      CustomeStatusEffects.Deflect._statusName = "Deflect";
      CustomeStatusEffects.Deflect.statusEffectType = (StatusEffectType) 65752;
      CustomeStatusEffects.Deflect._description = "Reflect all direct damage and status effects applied to this party member to the Opposing enemy, if damage is more than the stack of Deflect, reflect damage equal to the amount of Deflect, excess is dealt to this party member. Upon this status effect activating remove all stacks of Deflect.";
      CustomeStatusEffects.Deflect._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8]._applied_SE_Event;
      CustomeStatusEffects.Deflect._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].RemovedSoundEvent;
      CustomeStatusEffects.Deflect._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8]._updated_SE_Event;
      CustomeStatusEffects.Deflect._special01_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 5].AppliedSoundEvent;
      CustomeStatusEffects.Deflect._special02_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 5].AppliedSoundEvent;
      StatusEffectInfoSO statusEffectInfoSo;
      self._stats.statusEffectDataBase.TryGetValue((StatusEffectType) 65752, out statusEffectInfoSo);
      if (!((UnityEngine.Object) statusEffectInfoSo == (UnityEngine.Object) null))
        return;
      self._stats.statusEffectDataBase.Add((StatusEffectType) 65752, CustomeStatusEffects.Deflect);
    }

    private static void AddDeflectIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      ((IntentInfo) CustomeStatusEffects.DeflectIntent)._type = (IntentType) 49297;
      ((IntentInfo) CustomeStatusEffects.DeflectIntent)._sprite = ResourceLoader.LoadSprite("DeflectIcon");
      ((IntentInfo) CustomeStatusEffects.DeflectIntent)._color = Color.white;
      ((IntentInfo) CustomeStatusEffects.DeflectIntent)._sound = self._intentDB[(IntentType) 196]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) 49297, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) 49297, (IntentInfo) CustomeStatusEffects.DeflectIntent);
    }
  }
}
