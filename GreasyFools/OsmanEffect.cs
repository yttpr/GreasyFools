// Decompiled with JetBrains decompiler
// Type: GreasyFools.OsmanEffect
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class OsmanEffect : EffectSO
  {
    private static Sprite image;
    private static Ability _abil;
    public static bool Char;
    public static bool Enem;

    public static string GUH => "SinnoksOverworld.png";

    public static Sprite Image
    {
      get
      {
        if ((Object) OsmanEffect.image == (Object) null)
          OsmanEffect.image = ResourceLoader.LoadSprite(OsmanEffect.GUH);
        return OsmanEffect.image;
      }
    }

    public static Ability Abil
    {
      get
      {
        if (OsmanEffect._abil == null)
        {
          OsmanEffect._abil = new Ability();
          OsmanEffect._abil.name = "Slap";
          OsmanEffect._abil.description = LoadedAssetsHandler.GetCharacterAbility("Slap_A")._description;
          OsmanEffect._abil.sprite = LoadedAssetsHandler.GetCharacterAbility("Slap_A").abilitySprite;
          OsmanEffect._abil.rarity = 5;
          OsmanEffect._abil.cost = new ManaColorSO[1]
          {
            Pigments.Yellow
          };
          OsmanEffect._abil.visuals = (AttackVisualsSO) null;
          OsmanEffect._abil.animationTarget = Slots.Front;
          OsmanEffect._abil.effects = new Effect[2];
          AnimationVisualsIfUnitEffect instance = ScriptableObject.CreateInstance<AnimationVisualsIfUnitEffect>();
          instance._visuals = ((LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").passiveAbilities[0] as ExtraAttackPassiveAbility)._extraAbility.ability.effects[0].effect as AnimationVisualsIfUnitEffect)._visuals;
          instance._animationTarget = Slots.Front;
          instance._noUnitAnimationTarget = Slots.Front;
          instance._noUnitVisuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
          OsmanEffect._abil.effects[0] = new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Front);
          OsmanEffect._abil.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?((IntentType) 0), Slots.Front);
        }
        return OsmanEffect._abil;
      }
    }

    public static void AddCH()
    {
      Character character = new Character()
      {
        name = OsmanEffect.GUH,
        healthColor = Pigments.Red,
        entityID = (EntityIDs) 0,
        levels = new CharacterRankedData[1],
        frontSprite = OsmanEffect.Image
      };
      character.backSprite = character.frontSprite;
      character.overworldSprite = ResourceLoader.LoadSprite(OsmanEffect.GUH, pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = character.frontSprite;
      character.unlockedSprite = character.frontSprite;
      character.menuChar = false;
      character.usesBaseAbility = true;
      character.isSupport = false;
      character.usesAllAbilities = false;
      character.appearsInShops = false;
      character.hurtSound = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").damageSound;
      character.deathSound = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetSpeakerData("Osman_SpeakerData")._defaultBundle.dialogueSound;
      character.passives = new BasePassiveAbilitySO[8]
      {
        Passiver.Leaky(9),
        Passives.Skittish,
        Passives.Delicate,
        Passives.Withering,
        Passives.Pure,
        Passives.Slippery,
        Passives.Dying,
        Passives.Enfeebled
      };
      character.baseAbility = OsmanEffect.Abil;
      character.AddLevel(80, new Ability[0], 0);
      character.AddCharacter();
      OsmanEffect.Char = true;
    }

    public static void AddEN()
    {
      Enemy enemy = new Enemy()
      {
        name = OsmanEffect.GUH,
        health = 80,
        size = 1,
        healthColor = Pigments.Red,
        hurtSound = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").damageSound,
        deathSound = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").deathSound,
        entityID = (EntityIDs) 0,
        combatSprite = OsmanEffect.Image,
        overworldAliveSprite = OsmanEffect.Image,
        overworldDeadSprite = OsmanEffect.Image,
        passives = new BasePassiveAbilitySO[6]
        {
          Passives.Skittish,
          Passives.Withering,
          Passiver.Abomination,
          Passiver.Multiattack(10),
          Passiver.Overexert(27),
          LoadedAssetsHandler.GetEnemy("MudLung_EN").passiveAbilities[0]
        },
        priority = 0,
        abilitySelector = (BaseAbilitySelectorSO) ScriptableObject.CreateInstance<AbilitySelector_ByRarity>(),
        prefab = PymnHere.Assets.LoadAsset<GameObject>("Assets/Geese/Osman/Osman_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
      };
      enemy.prefab._gibs = PymnHere.Assets.LoadAsset<GameObject>("Assets/Geese/Osman/Osman_Gibs.prefab").GetComponent<ParticleSystem>();
      enemy.prefab.SetDefaultParams();
      enemy.abilities = new Ability[1]{ OsmanEffect.Abil };
      enemy.enemyID = "Yay_EN";
      enemy.AddEnemy();
      OsmanEffect.Enem = true;
    }

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (Random.Range(0, 100) < 50)
      {
        if (Random.Range(0, 100) < 1)
        {
          if (!OsmanEffect.Char)
            OsmanEffect.AddCH();
          CombatManager.Instance.AddSubAction((CombatAction) new SpawnCharacterAction(LoadedAssetsHandler.GetCharcater(OsmanEffect.GUH + "_CH"), -1, false, "", false, 0, 1, 2, 80, (WearableStaticModifiers) null));
          ++exitAmount;
        }
      }
      else if (Random.Range(0, 100) < 1)
      {
        if (!OsmanEffect.Enem)
          OsmanEffect.AddEN();
        CombatManager.Instance.AddSubAction((CombatAction) new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("Yay_EN"), -1, false, false, (SpawnType) 1));
        ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
