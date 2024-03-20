// Decompiled with JetBrains decompiler
// Type: GreasyFools.CasterTransformationIfHealthEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class CasterTransformationIfHealthEffect : EffectSO
  {
    [SerializeField]
    public bool _fullyHeal = true;
    [SerializeField]
    public bool _maintainTimelineAbilities;
    [SerializeField]
    public bool _maintainMaxHealth;
    [SerializeField]
    public bool _currentToMaxHealth;
    [SerializeField]
    public EnemySO _enemyTransformation;
    [SerializeField]
    public CharacterSO _characterTransformation;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (caster.CurrentHealth < 0)
      {
        caster.Heal(1, (HealType) 1, true);
        if (caster.IsUnitCharacter)
          return stats.TryTransformCharacter(caster.ID, this._characterTransformation, this._fullyHeal, this._maintainMaxHealth, this._currentToMaxHealth);
      }
      return stats.TryTransformEnemy(caster.ID, this._enemyTransformation, this._fullyHeal, this._maintainTimelineAbilities, this._maintainMaxHealth, this._currentToMaxHealth);
    }
  }
}
