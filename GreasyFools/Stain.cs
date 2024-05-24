// Decompiled with JetBrains decompiler
// Type: GreasyFools.Stain
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class Stain
  {
    public static Character Staint;

    public static void Add()
    {
      Stain.Staint = new Character()
      {
        name = nameof (Stain),
        entityID = (EntityIDs) 6247952,
        healthColor = Pigments.Purple,
        usesBaseAbility = true,
        usesAllAbilities = false,
        walksInOverworld = true,
        isSupport = false,
        menuChar = true,
        appearsInShops = true,
        levels = new CharacterRankedData[4],
        frontSprite = ResourceLoader.LoadSprite("StainFrontt.png"),
        backSprite = ResourceLoader.LoadSprite("StainBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("Stainworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        unlockedSprite = ResourceLoader.LoadSprite("Stainmenu.png"),
        lockedSprite = ResourceLoader.LoadSprite("Stainmenu.png"),
        hurtSound = "event:/Greasy/Stain/StainHurt",
        deathSound = "event:/Greasy/Stain/StainDeath",
        dialogueSound = "event:/Greasy/Stain/StainTalk",
        passives = new BasePassiveAbilitySO[1]
        {
          DirectWrongPigmentHandler.Passive
        }
      };
      Ability ability1 = new Ability();
      ability1.name = "Rough Chop";
      ability1.description = "Deal 6-10 damage to the Opposing enemy. If no wrong pigment was used, heal this party member 4 health.";
      ability1.sprite = ResourceLoader.LoadSprite("Chop.png");
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Purple,
        Pigments.Purple
      };
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Parry_1_A").visuals;
      ability1.animationTarget = Slots.Front;
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 6, new IntentType?((IntentType) 2), Slots.Front);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 10, new IntentType?(), Slots.Front);
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), Slots.Self, (EffectConditionSO) WrongPigmentCondition.Create(false));
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Violent Chop";
      ability2.description = "Deal 8-12 damage to the Opposing enemy. If no wrong pigment was used, heal this party member 5 health.";
      ability2.effects[0]._entryVariable = 8;
      ability2.effects[0]._intent = new IntentType?((IntentType) 3);
      ability2.effects[1]._entryVariable = 12;
      ability2.effects[2]._entryVariable = 5;
      ability2.effects[2]._intent = new IntentType?((IntentType) 21);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Bloody Chop";
      ability3.description = "Deal 10-14 damage to the Opposing enemy. If no wrong pigment was used, heal this party member 5 health.";
      ability3.effects[0]._entryVariable = 10;
      ability3.effects[1]._entryVariable = 14;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Neck-Breaking Chop";
      ability4.description = "Deal 12-16 damage to the Opposing enemy. If no wrong pigment was used, heal this party member 7 health.";
      ability4.effects[0]._entryVariable = 12;
      ability4.effects[0]._intent = new IntentType?((IntentType) 4);
      ability4.effects[1]._entryVariable = 16;
      ability4.effects[2]._entryVariable = 7;
      Ability ability5 = new Ability();
      ability5.name = "Forge Skin";
      ability5.description = "Apply 4 Shield to self. If wrong pigment was used, increase this party member's damage by 1.";
      ability5.sprite = ResourceLoader.LoadSprite("Forge.png");
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability5.visuals = CustomVisuals.GetVisuals("Greasy/Forge");
      ability5.animationTarget = Slots.Self;
      ability5.effects = new Effect[2];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 4, new IntentType?((IntentType) 171), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<AddForgeEffect>(), 1, new IntentType?((IntentType) 104), Slots.Self, (EffectConditionSO) WrongPigmentCondition.Create(true));
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Forge Bone";
      ability6.description = "Apply 6 Shield to self. If wrong pigment was used, increase this party member's damage by 2.";
      ability6.effects[0]._entryVariable = 6;
      ability6.effects[1]._entryVariable = 2;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Forge Body";
      ability7.description = "Apply 8 Shield to self. If wrong pigment was used, increase this party member's damage by 2.";
      ability7.effects[0]._entryVariable = 8;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Forge Soul";
      ability8.description = "Apply 11 Shield to self. If wrong pigment was used, increase this party member's damage by 3.";
      ability8.effects[0]._entryVariable = 11;
      ability8.effects[1]._entryVariable = 3;
      Ability ability9 = new Ability();
      ability9.name = "Cleave the Meat";
      ability9.description = "Deal 5 damage to the Left and Right enemies, deal 7 damage instead if wrong pigment was used.";
      ability9.sprite = ResourceLoader.LoadSprite("Cleave.png");
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Blue
      };
      ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Purify_1_A").visuals;
      ability9.animationTarget = Slots.LeftRight;
      ability9.effects = new Effect[2];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?((IntentType) 1), Slots.LeftRight, (EffectConditionSO) WrongPigmentCondition.Create(false));
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 7, new IntentType?((IntentType) 2), Slots.LeftRight, (EffectConditionSO) WrongPigmentCondition.Create(true));
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Cleave the Flesh";
      ability10.description = "Deal 7 damage to the Left and Right enemies, deal 9 damage instead if wrong pigment was used.";
      ability10.effects[0]._entryVariable = 7;
      ability10.effects[0]._intent = new IntentType?((IntentType) 2);
      ability10.effects[1]._entryVariable = 9;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Cleave Guts";
      ability11.description = "Deal 9 damage to the Left and Right enemies, deal 12 damage instead if wrong pigment was used.";
      ability11.effects[0]._entryVariable = 9;
      ability11.effects[1]._entryVariable = 12;
      ability11.effects[1]._intent = new IntentType?((IntentType) 3);
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Cleave Bone"; //gay
      ability12.description = "Deal 11 damage to the Left and Right enemies, deal 15 damage instead if wrong pigment was used.";
      ability12.effects[0]._entryVariable = 11;
      ability12.effects[0]._intent = new IntentType?((IntentType) 3);
      ability12.effects[1]._entryVariable = 15;
      Stain.Staint.AddLevel(20, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      Stain.Staint.AddLevel(21, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      Stain.Staint.AddLevel(22, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      Stain.Staint.AddLevel(23, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      Stain.Staint.AddCharacter();
    }
  }
}
