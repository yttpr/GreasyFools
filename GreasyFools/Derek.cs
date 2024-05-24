// Decompiled with JetBrains decompiler
// Type: GreasyFools.Derek
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  internal class Derek
  {
    public static Character knight;

    public static void Add()
    {
      Character character = new Character();
      character.name = nameof (Derek);
      character.healthColor = Pigments.Blue;
      character.entityID = (EntityIDs) 74899;
      character.levels = new CharacterRankedData[4];
      character.frontSprite = ResourceLoader.LoadSprite("DerekFront");
      character.backSprite = ResourceLoader.LoadSprite("DerekBack");
      character.overworldSprite = ResourceLoader.LoadSprite("DerekWorld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = ResourceLoader.LoadSprite("DerekMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("DerekMenu");
      character.menuChar = true;
      character.usesBaseAbility = true;
      character.isSupport = false;
      character.usesAllAbilities = false;
      character.appearsInShops = true;
      character.hurtSound = "event:/Greasy/Derek/DerekHurt";
      character.deathSound = "event:/Greasy/Derek/DerekDeath";
      character.dialogueSound = "event:/Greasy/Derek/DerekTalk";
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("Pummel.png");
      ability1.name = "Pummel the Guard";
      ability1.description = "Deal 6 damage to the Opposing enemy. Deal double if this party member is in the center position.\nMove the Opposing enemy towards the center of the field.";
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Red,
        Pigments.Red
      };
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?((IntentType) 101), Slots.Front);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DoubleDamageIfCenterEffect>(), 6, new IntentType?((IntentType) 3), Slots.Front);
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoveToCenterEffect>(), 1, new IntentType?((IntentType) 40), Slots.Front);
      ability1.animationTarget = Slots.Front;
            ability1.visuals = CustomVisuals.GetVisuals("Greasy/Pummel");//LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").abilities[0].ability.visuals;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Pummel the Armor";
      ability2.description = "Deal 8 damage to the Opposing enemy. Deal double if this party member is in the center position.\nMove the Opposing enemy towards the center of the field.";
      ability2.effects[1]._entryVariable = 8;
      ability2.effects[1]._intent = new IntentType?((IntentType) 4);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Pummel the Limbs";
      ability3.description = "Deal 10 damage to the Opposing enemy. Deal double if this party member is in the center position.\nMove the Opposing enemy towards the center of the field.";
      ability3.effects[1]._entryVariable = 10;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Pummel the Spirit";
      ability4.description = "Deal 12 damage to the Opposing enemy. Deal double if this party member is in the center position.\nMove the Opposing enemy towards the center of the field.";
      ability4.effects[1]._entryVariable = 12;
      ability4.effects[1]._intent = new IntentType?((IntentType) 5);
      ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
      GenericTargetting_BySlot_Index instance1 = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
      instance1.getAllies = true;
      instance1.slotPointerDirections = new int[2]{ 0, 4 };
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("Intimidate.png");
      ability5.name = "Menacing Intimidate";
      ability5.description = "Deal 4 damage to the Opposing enemy and inflict 1 Scar. If this party member is on the edge of the field, deal double damage and inflict another Scar. \nMove the Opposing enemy towards the center of the field.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Purple,
        Pigments.Red
      };
      ability5.effects = new Effect[5];
      ability5.effects[0] = ability1.effects[0];
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoreDamageIfEdgeEffect>(), 4, new IntentType?((IntentType) 2), Slots.Front);
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(), Slots.Front);
      ability5.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?((IntentType) 159), Slots.Front, (EffectConditionSO) ScriptableObject.CreateInstance<OnEdgeCondition>());
      ability5.effects[4] = ability1.effects[2];
      ability5.animationTarget = Slots.Front;
      ability5.visuals = CustomVisuals.GetVisuals("Greasy/Intimidate");
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Terrifying Intimidate";
      ability6.description = "Deal 5 damage to the Opposing enemy and inflict 1 Scar. If this party member is on the edge of the field, deal double damage and inflict another 2 Scars. \nMove the Opposing enemy towards the center of the field.";
      ability6.effects[1]._entryVariable = 5;
      ability6.effects[1]._intent = new IntentType?((IntentType) 2);
      ability6.effects[3]._entryVariable = 2;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Horrifying Intimidate";
      ability7.description = "Deal 6 damage to the Opposing enemy and inflict 1 Scar. If this party member is on the edge of the field, deal double damage and inflict another 2 Scars. \nMove the Opposing enemy towards the center of the field.";
      ability7.effects[1]._entryVariable = 6;
      ability7.effects[1]._intent = new IntentType?((IntentType) 3);
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Nightmarish Intimidate";
      ability8.description = "Deal 6 damage to the Opposing enemy and inflict 1 Scar. If this party member is on the edge of the field, deal double damage and inflict another 3 Scars. \nMove the Opposing enemy towards the center of the field.";
      ability8.effects[3]._entryVariable = 6;
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("Buckler");
      ability9.name = "Robust Buckler";
      ability9.description = "Deal 3 damage to the enemy facing the lowest health party member, then apply 6 Shield to that party member's position.";
      TargettingWeakestUnit instance2 = ScriptableObject.CreateInstance<TargettingWeakestUnit>();
      instance2.getAllies = true;
      instance2.getAllUnitSlots = true;
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Red
      };
      ability9.effects = new Effect[2];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 3, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) TargettingByTargetting.Create((BaseCombatTargettingSO) instance2, Slots.Front));
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, new IntentType?((IntentType) 171), (BaseCombatTargettingSO) instance2);
      ability9.animationTarget = (BaseCombatTargettingSO) instance2;
            ability9.visuals = CustomVisuals.GetVisuals("Greasy/Buckler");//LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Wieldy Buckler";
      ability10.description = "Deal 4 damage to the enemy facing the lowest health party member, then apply 8 Shield to that party member's position.";
      ability10.effects[0]._entryVariable = 4;
      ability10.effects[1]._entryVariable = 8;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Heavy Buckler";
      ability11.description = "Deal 5 damage to the enemy facing the lowest health party member, then apply 10 Shield to that party member's position.";
      ability11.effects[0]._entryVariable = 5;
      ability11.effects[1]._entryVariable = 10;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Massive Buckler";
      ability12.description = "Deal 6 damage to the enemy facing the lowest health party member, then apply 12 Shield to that party member's position.";
      ability12.effects[0]._entryVariable = 6;
      ability12.effects[1]._entryVariable = 12;
      character.AddLevel(22, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(24, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(26, new Ability[3]
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
      Derek.knight = character;
    }
  }
}
