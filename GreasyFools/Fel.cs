// Decompiled with JetBrains decompiler
// Type: GreasyFools.Fel
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class Fel
  {
    public static Character Felt;

    public static void Add()
    {
      Fel.Felt = new Character()
      {
        name = nameof (Fel),
        entityID = (EntityIDs) 624794,
        healthColor = Pigments.Blue,
        usesBaseAbility = true,
        usesAllAbilities = false,
        walksInOverworld = true,
        isSupport = false,
        menuChar = true,
        appearsInShops = true,
        levels = new CharacterRankedData[4],
        frontSprite = ResourceLoader.LoadSprite("FelFront.png"),
        backSprite = ResourceLoader.LoadSprite("FelBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("FelWorld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        unlockedSprite = ResourceLoader.LoadSprite("FelMenu.png"),
        lockedSprite = ResourceLoader.LoadSprite("FelMenu.png"),
        hurtSound = LoadedAssetsHandler.GetCharcater("Thype_CH").damageSound,
        deathSound = LoadedAssetsHandler.GetCharcater("Thype_CH").deathSound,
        dialogueSound = LoadedAssetsHandler.GetCharcater("Thype_CH").dxSound,
        passives = new BasePassiveAbilitySO[1]
        {
          Passiver.Multiattack(2, true)
        }
      };
      Ability ability1 = new Ability();
      ability1.name = "Spectral Smooth";
      ability1.description = "Heal the Left and Right allies 0-4 health.";
      ability1.sprite = ResourceLoader.LoadSprite("Smooth.png");
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Mend_1_A").visuals;
      ability1.animationTarget = Slots.Sides;
      ability1.effects = new Effect[1];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealRandom0ToEntryEffect>(), 4, new IntentType?((IntentType) 20), Slots.Sides);
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Eerie Smooth";
      ability2.description = "Heal the Left and Right allies 0-5 health.";
      ability2.effects[0]._entryVariable = 5;
      ability2.effects[0]._intent = new IntentType?((IntentType) 21);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Whimsical Smooth";
      ability3.description = "Heal the Far Left, Left, Right and Far Right allies 0-5 health.";
      ability3.animationTarget = Slots.SlotTarget(new int[4]
      {
        -2,
        -1,
        1,
        2
      }, true);
      ability3.effects[0]._target = ability3.animationTarget;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Chaotic Smooth";
      ability4.description = "Heal the Far Left, Left, Right, and Far Right allies 0-6 health.";
      ability4.effects[0]._entryVariable = 6;
      Ability ability5 = new Ability();
      ability5.name = "Poke Their Flesh";
      ability5.description = "Deal 2 damage to the Opposing enemy and inflict 2 Ruptured. Move the Opposing enemy to the Left or Right.";
      ability5.sprite = ResourceLoader.LoadSprite("Poke .png");
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Showdown_1_A").visuals;
      ability5.animationTarget = Slots.Front;
      ability5.effects = new Effect[3];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?((IntentType) 0), Slots.Front);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, new IntentType?((IntentType) 151), Slots.Front);
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?((IntentType) 40), Slots.Front);
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Poke Their Muscles";
      ability6.description = "Deal 3 damage to the Opposing enemy and inflict 3 Ruptured. Move the Opposing enemy to the Left or Right.";
      ability6.effects[0]._entryVariable = 3;
      ability6.effects[0]._intent = new IntentType?((IntentType) 1);
      ability6.effects[1]._entryVariable = 3;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Poke Their Nerves";
      ability7.description = "Deal 4 damage to the Opposing enemy and inflict 4 Ruptured. Move the Opposing enemy to the Left or Right.";
      ability7.effects[0]._entryVariable = 4;
      ability7.effects[1]._entryVariable = 4;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Poke Their Organs";
      ability8.description = "Deal 5 damage to the Opposing enemy and inflict 5 Ruptured. Move the Opposing enemy to the Left or Right.";
      ability8.effects[0]._entryVariable = 5;
      ability8.effects[1]._entryVariable = 5;
      Ability ability9 = new Ability();
      ability9.name = "Phantom Vindication";
      ability9.description = "Remove Constricted from this party member's position and restore their movement. \nApply 1-3 Shield to this party member's position.";
      ability9.sprite = ResourceLoader.LoadSprite("Vindicate.png");
      ability9.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals;
      ability9.animationTarget = Slots.Self;
      ability9.effects = new Effect[4];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveConstrictedEffect>(), 1, new IntentType?((IntentType) 210), Slots.Self);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability9.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?(), Slots.Self);
      ability9.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRandomShieldBetweenPreviousAndEntryEffect>(), 3, new IntentType?((IntentType) 171), Slots.Self);
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Erratic Vindication";
      ability10.description = "Remove Constricted from this party member's position and restore their movement. \nApply 1-5 Shield to this party member's position.";
      ability10.effects[3]._entryVariable = 5;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Certain Vindication";
      ability11.description = "Remove Constricted from this party member's position and restore their movement. \nApply 1-7 Shield to this party member's position.";
      ability11.effects[3]._entryVariable = 7;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Mystic Vindication";
      ability12.description = "Remove Constricted from this party member's position and restore their movement. \nApplu 1-9 Shield to this party member's position.";
      ability12.effects[3]._entryVariable = 9;
      Fel.Felt.AddLevel(10, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      Fel.Felt.AddLevel(12, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      Fel.Felt.AddLevel(14, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      Fel.Felt.AddLevel(16, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      Fel.Felt.AddCharacter();
    }
  }
}
