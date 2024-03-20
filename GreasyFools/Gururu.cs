// Decompiled with JetBrains decompiler
// Type: GreasyFools.Gururu
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class Gururu
  {
    public static void Add()
    {
      Character character = new Character();
      character.name = nameof (Gururu);
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 74921;
      character.levels = new CharacterRankedData[4];
      character.frontSprite = ResourceLoader.LoadSprite("GururuFront");
      character.backSprite = ResourceLoader.LoadSprite("GururuBack");
      character.overworldSprite = ResourceLoader.LoadSprite("GururuWorld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = ResourceLoader.LoadSprite("GururuMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("GururuMenu");
      character.menuChar = true;
      character.usesBaseAbility = true;
      character.isSupport = false;
      character.usesAllAbilities = false;
      character.appearsInShops = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Pearl_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Pearl_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Pearl_CH").dxSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        Passives.Unstable
      };
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("Extraction", 1);
      ability1.name = "Slow Extraction";
      ability1.description = "deal 5 damage to the Opposing enemy, Heal this party member for the amount of damage dealt.\nThis ability produces 2 additional pigment.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Red
      };
      ability1.effects = new Effect[2];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HeavyDamageEffect>(), 5, new IntentType?((IntentType) 1), Slots.Front);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?((IntentType) 20), Slots.Self);
      ((HealEffect) ability1.effects[1]._effect).usePreviousExitValue = true;
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharcater("SmokeStacks_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("Extraction", 1);
      ability2.name = "Blood Extraction";
      ability2.description = "deal 7 damage to the Opposing enemy, Heal this party member for the amount of damage dealt.\nThis ability produces 2 additional pigment.";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Red
      };
      ability2.effects = new Effect[2];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HeavyDamageEffect>(), 7, new IntentType?((IntentType) 2), Slots.Front);
      ability2.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?((IntentType) 20), Slots.Self);
      ((HealEffect) ability2.effects[1]._effect).usePreviousExitValue = true;
      ability2.animationTarget = Slots.Front;
      ability2.visuals = LoadedAssetsHandler.GetCharcater("SmokeStacks_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("Extraction", 1);
      ability3.name = "Flesh Extraction";
      ability3.description = "deal 9 damage to the Opposing enemy, Heal this party member for the amount of damage dealt.\nThis ability produces 2 additional pigment.";
      ability3.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Red
      };
      ability3.effects = new Effect[2];
      ability3.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HeavyDamageEffect>(), 9, new IntentType?((IntentType) 2), Slots.Front);
      ability3.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?((IntentType) 20), Slots.Self);
      ((HealEffect) ability3.effects[1]._effect).usePreviousExitValue = true;
      ability3.animationTarget = Slots.Front;
      ability3.visuals = LoadedAssetsHandler.GetCharcater("SmokeStacks_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability4 = new Ability();
      ability4.sprite = ResourceLoader.LoadSprite("Extraction", 1);
      ability4.name = "Life Extraction";
      ability4.description = "deal 12 damage to the Opposing enemy, Heal this party member for the amount of damage dealt.\nThis ability produces 2 additional pigment.";
      ability4.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Red
      };
      ability4.effects = new Effect[2];
      ability4.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HeavyDamageEffect>(), 12, new IntentType?((IntentType) 3), Slots.Front);
      ability4.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?((IntentType) 20), Slots.Self);
      ((HealEffect) ability4.effects[1]._effect).usePreviousExitValue = true;
      ability4.animationTarget = Slots.Front;
      ability4.visuals = LoadedAssetsHandler.GetCharcater("SmokeStacks_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("Pact", 1);
      ability5.name = "Awful Pact";
      ability5.description = "Consume all overflow, for each pigment consumed deal 5 indirect damage to the opposing enemy.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Purple,
        Pigments.Yellow
      };
      ability5.effects = new Effect[2];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveOverflowManaEffect>(), 5, new IntentType?((IntentType) 61), Slots.Self);
      ((RemoveOverflowManaEffect) ability5.effects[0]._effect)._fullyDeplete = true;
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?((IntentType) 1), Slots.Front);
      ((DamageEffect) ability5.effects[1]._effect)._usePreviousExitValue = true;
      ((DamageEffect) ability5.effects[1]._effect)._indirect = true;
      ability5.animationTarget = Slots.Front;
      ability5.visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[1].ability.visuals;
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("Pact", 1);
      ability6.name = "Horrible Pact";
      ability6.description = "Consume all overflow, for each pigment consumed deal 7 indirect damage to the opposing enemy.";
      ability6.cost = new ManaColorSO[2]
      {
        Pigments.Purple,
        Pigments.Yellow
      };
      ability6.effects = new Effect[2];
      ability6.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveOverflowManaEffect>(), 0, new IntentType?((IntentType) 61), Slots.Self);
      ((RemoveOverflowManaEffect) ability6.effects[0]._effect)._fullyDeplete = true;
      ability6.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 7, new IntentType?((IntentType) 2), Slots.Front);
      ((DamageEffect) ability6.effects[1]._effect)._usePreviousExitValue = true;
      ((DamageEffect) ability6.effects[1]._effect)._indirect = true;
      ability6.animationTarget = Slots.Front;
      ability6.visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[1].ability.visuals;
      Ability ability7 = new Ability();
      ability7.sprite = ResourceLoader.LoadSprite("Pact", 1);
      ability7.name = "Terrible Pact";
      ability7.description = "Consume all overflow, for each pigment consumed deal 9 indirect damage to the opposing enemy.";
      ability7.cost = new ManaColorSO[2]
      {
        Pigments.Purple,
        Pigments.Yellow
      };
      ability7.effects = new Effect[2];
      ability7.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveOverflowManaEffect>(), 0, new IntentType?((IntentType) 61), Slots.Self);
      ((RemoveOverflowManaEffect) ability7.effects[0]._effect)._fullyDeplete = true;
      ability7.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 9, new IntentType?((IntentType) 2), Slots.Front);
      ((DamageEffect) ability7.effects[1]._effect)._usePreviousExitValue = true;
      ((DamageEffect) ability7.effects[1]._effect)._indirect = true;
      ability7.animationTarget = Slots.Front;
      ability7.visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[1].ability.visuals;
      Ability ability8 = new Ability();
      ability8.sprite = ResourceLoader.LoadSprite("Pact", 1);
      ability8.name = "Gruesome Pact";
      ability8.description = "Consume all overflow, for each pigment consumed deal 12 indirect damage to the opposing enemy.";
      ability8.cost = new ManaColorSO[2]
      {
        Pigments.Purple,
        Pigments.Yellow
      };
      ability8.effects = new Effect[2];
      ability8.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveOverflowManaEffect>(), 0, new IntentType?((IntentType) 61), Slots.Self);
      ((RemoveOverflowManaEffect) ability8.effects[0]._effect)._fullyDeplete = true;
      ability8.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 12, new IntentType?((IntentType) 3), Slots.Front);
      ((DamageEffect) ability8.effects[1]._effect)._usePreviousExitValue = true;
      ((DamageEffect) ability8.effects[1]._effect)._indirect = true;
      ability8.animationTarget = Slots.Front;
      ability8.visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[1].ability.visuals;
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("Extinctor", 1);
      ability9.name = "Creepy Extinctor";
      ability9.description = "Attempt to consume 4 pigments, deal 2 damage to the Left and Right enemies for each pigment consumed";
      ability9.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability9.effects = new Effect[2];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 4, new IntentType?((IntentType) 61), Slots.Self);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?((IntentType) 0), Slots.LeftRight);
      ((DamageEffect) ability9.effects[1]._effect)._usePreviousExitValue = true;
      ability9.animationTarget = Slots.LeftRight;
      ability9.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability10 = new Ability();
      ability10.sprite = ResourceLoader.LoadSprite("Extinctor", 1);
      ability10.name = "Sinister Extinctor";
      ability10.description = "Attempt to consume 6 pigments, deal 2 damage to the Left and Right enemies for each pigment consumed";
      ability10.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability10.effects = new Effect[2];
      ability10.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 6, new IntentType?((IntentType) 61), Slots.Self);
      ability10.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?((IntentType) 0), Slots.LeftRight);
      ((DamageEffect) ability10.effects[1]._effect)._usePreviousExitValue = true;
      ability10.animationTarget = Slots.LeftRight;
      ability10.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability11 = new Ability();
      ability11.sprite = ResourceLoader.LoadSprite("Extinctor", 1);
      ability11.name = "Morbid Extinctor";
      ability11.description = "Attempt to consume 8 pigments, deal 2 damage to the Left and Right enemies for each pigment consumed";
      ability11.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability11.effects = new Effect[2];
      ability11.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 8, new IntentType?((IntentType) 61), Slots.Self);
      ability11.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?((IntentType) 0), Slots.LeftRight);
      ((DamageEffect) ability11.effects[1]._effect)._usePreviousExitValue = true;
      ability11.animationTarget = Slots.LeftRight;
      ability11.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability12 = new Ability();
      ability12.sprite = ResourceLoader.LoadSprite("Extinctor", 1);
      ability12.name = "Cataclysmal Extinctor";
      ability12.description = "Attempt to consume 9 pigments, deal 2 damage to the Left and Right enemies for each pigment consumed";
      ability12.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability12.effects = new Effect[2];
      ability12.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 10, new IntentType?((IntentType) 61), Slots.Self);
      ability12.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?((IntentType) 0), Slots.LeftRight);
      ((DamageEffect) ability12.effects[1]._effect)._usePreviousExitValue = true;
      ability12.animationTarget = Slots.LeftRight;
      ability12.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
      character.AddLevel(16, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(22, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(24, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(28, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
    }
  }
}
