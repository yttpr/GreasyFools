// Decompiled with JetBrains decompiler
// Type: GreasyFools.Quorell
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using GreasyFools.Effects;
using System.Collections.Generic;
using UnityEngine;
using System;
using MonoMod.RuntimeDetour;
using System.Reflection;
using UnityEngine.UI;
using System.Collections;

#nullable disable
namespace GreasyFools
{
  internal class Quorell
  {
    public static Character bird;
    private static Sprite _menuFront;
    private static Sprite _battleFront;

    public static Sprite MenuFront
    {
      get
      {
        if ( Quorell._menuFront ==  null)
          Quorell._menuFront = ResourceLoader.LoadSprite("QuorellNormalFront.png");
        return Quorell._menuFront;
      }
    }

    public static Sprite BattleFront
    {
      get
      {
        if (Quorell._battleFront == null)
          Quorell._battleFront = ResourceLoader.LoadSprite("QuorellFront.png");
        return Quorell._battleFront;
      }
    }

    public static void Add()
    {
      Character character = new Character();
      character.name = nameof (Quorell);
      character.healthColor = Pigments.Blue;
      character.entityID = (EntityIDs) 65682;
      character.levels = new CharacterRankedData[4];
      character.frontSprite = Quorell.MenuFront;
      character.backSprite = ResourceLoader.LoadSprite("QuorellBack");
      character.overworldSprite = ResourceLoader.LoadSprite("QuorellWorld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = ResourceLoader.LoadSprite("QuorellMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("QuorellMenu");
      character.menuChar = true;
      character.usesBaseAbility = true;
      character.isSupport = true;
      character.ignoredAbilities = new List<int>() { 1 };
      character.usesAllAbilities = false;
      character.appearsInShops = true;
      character.hurtSound = "event:/Greasy/Quorell/QuorellHurt";
      character.deathSound = "event:/Greasy/Quorell/QuorellDeath";
      character.dialogueSound = "event:/Greasy/Quorell/QuorellTalk";
      character.passives = new BasePassiveAbilitySO[1]
      {
        Passives.Delicate
      };
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("RESTORE_A");
      ability1.name = "Novice Restore";
      ability1.description = "Heal the Left and Right allies 4 health and remove all negative Status Effects and Field Effects from them.";
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), Slots.Sides);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveAllNegativeStatusEffect>(), 1, new IntentType?((IntentType) 100), Slots.Sides);
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveAllNegativeFieldEffect>(), 1, new IntentType?(), Slots.Sides);
      ability1.animationTarget = Slots.Sides;
      ability1.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Intermediate Restore";
      ability2.description = "Heal the Left and Right allies 5 health and remove all negative Status Effects and Field Effects from them.";
      ability2.effects[0]._entryVariable = 5;
      ability2.effects[0]._intent = new IntentType?((IntentType) 21);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Master Restore";
      ability3.description = "Heal the Left and Right allies 6 health and remove all negative Status Effects and Field Effects from them.";
      ability3.effects[0]._entryVariable = 6;
      ability3.effects[0]._intent = new IntentType?((IntentType) 21);
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Expert Restore";
      ability4.description = "Heal the Left and Right allies 7 health and remove all negative Status Effects and Field Effects from them.";
      ability4.effects[0]._entryVariable = 7;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("NULLIFY_A");
      ability5.name = "Partial Nullify";
      ability5.description = "Remove all Status Effects from this party member and deal 5 damage to the Opposing enemy + 3 for each type of Status Effect removed.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Red,
        Pigments.Yellow
      };
      ability5.effects = new Effect[3];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveAllNegativeStatusExitByTypeEffect>(), 1, new IntentType?((IntentType) 100), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<MultiplyExitByEntryEffect>(), 3, new IntentType?(), Slots.Self);
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamagePlusExitEffect>(), 5, new IntentType?((IntentType) 1), Slots.Front);
      ability5.animationTarget = Slots.Front;
      ability5.visuals = CustomVisuals.GetVisuals("Greasy/Nullify");
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Impressive Nullify";
      ability6.description = "Remove all Status Effects from this party member and deal 7 damage to the Opposing enemy + 4 for each type of Status Effect removed.";
      ability6.effects[1]._entryVariable = 4;
      ability6.effects[2]._entryVariable = 7;
      ability6.effects[2]._intent = new IntentType?((IntentType) 2);
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Grand Nullify";
      ability7.description = "Remove all Status Effects from this party member and deal 9 damage to the Opposing enemy + 5 for each type of Status Effect removed.";
      ability7.effects[1]._entryVariable = 5;
      ability7.effects[2]._entryVariable = 9;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Magnificent Nullify";
      ability8.description = "Remove all Status Effects from this party member and deal 11 damage to the Opposing enemy + 6 for each type of Status Effect removed.";
      ability8.effects[2]._entryVariable = 11;
      ability8.effects[2]._intent = new IntentType?((IntentType) 3);
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("AFFLICTION_A.png");
      ability9.name = "Malicious Affliction";
      ability9.description = "Inflict Cursed and 1 Frail on the Opposing enemy.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Purple
      };
      ability9.effects = new Effect[2];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, new IntentType?((IntentType) 152), Slots.Front);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, new IntentType?((IntentType) 150), Slots.Front);
      ability9.animationTarget = Slots.Front;
      ability9.visuals = CustomVisuals.GetVisuals("Greasy/Affliction");
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Baleful Affliction";
      ability10.description = "Inflict Cursed, 1 Frail, and 1 Scar on the Opposing enemy.";
      ability10.effects = new Effect[3];
      ability10.effects[0] = ability9.effects[0];
      ability10.effects[1] = ability9.effects[1];
      ability10.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?((IntentType) 159), Slots.Front);
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Cruel Affliction";
      ability11.description = "Inflict Cursed, 1 Frail, 2 Ruptured, and 1 Scar on the Opposing enemy.";
      ability11.effects = new Effect[4];
      ability11.effects[0] = ability10.effects[0];
      ability11.effects[1] = ability10.effects[1];
      ability11.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, new IntentType?((IntentType) 151), Slots.Front);
      ability11.effects[3] = ability10.effects[2];
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Deadly Affliction";
      ability12.description = "Inflict Cursed, 1 Frail, 3 Ruptured, and 2 Scars on the Opposing enemy.";
      ability12.effects[2]._entryVariable = 3;
      ability12.effects[3]._entryVariable = 2;
      character.AddLevel(12, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(16, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(18, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(20, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      BrutalAPI.BrutalAPI.selCharsSO._dpsCharacters.Add(new CharacterRefString(character.charData._characterName), new CharacterIgnoredAbilities()
      {
        ignoredAbilities = new List<int>() { 0, 2 }
      });
      Quorell.bird = character;
            EZExtensions.PCall(QuorellHandler.Setup, "extra handlers wow");
    }

    public static void Menu()
    {
      try
      {
        LoadedAssetsHandler.GetCharcater("Quorell_CH").characterSprite = Quorell.MenuFront;
      }
      catch
      {
        Debug.LogWarning((object) "quorell's front sprite failed to set for menu");
      }
    }

    public static void Battle()
    {
      try
      {
        LoadedAssetsHandler.GetCharcater("Quorell_CH").characterSprite = Quorell.BattleFront;
      }
      catch
      {
        Debug.LogWarning((object) "quorell's front sprite failed to set for battle");
      }
            CharacterCombat c;
            CharacterCombatUIInfo u;
            OnCharacterClickedImmediateAction a;
            CharacterInFieldLayout l;
            CombatVisualizationController v;
    }
  }

    public static class QuorellHandler
    {
        public static void SetCharacterInformation(Action<InformationZoneLayout, CharacterCombatUIInfo, SlotCombatUIInfo> orig, InformationZoneLayout self, CharacterCombatUIInfo character, SlotCombatUIInfo characterSlot)
        {
            orig(self, character, characterSlot);
            try
            {
                if (character.Name.Contains("Quorell"))
                {
                    self.UpdateUnitPortrait(Quorell.MenuFront);
                }
            }
            catch
            {
                Debug.LogError("PAIN");
            }
        }
        public static void OnStartDrag(Action<CombatPointerLayout, DraggableCombatLayout> orig, CombatPointerLayout self, DraggableCombatLayout dragItem)
        {
            if (dragItem is CharacterInFieldLayout character)
            {
                foreach (CharacterCombatUIInfo chara in CombatManager.Instance._stats.combatUI._charactersInCombat.Values)
                {
                    if (chara.SlotID == character.SlotID)
                    {
                        if (chara.Name.Contains("Quorell"))
                        {
                            if (!self.IsDragging && !(dragItem == null))
                            {
                                self.CurrentDragItem = dragItem;
                                self.StartCoroutine(QuorellDragging(self, dragItem.SlotImage));
                            }
                            return;
                        }
                        break;
                    }
                }
            }
            orig(self, dragItem);
        }
        public static IEnumerator QuorellDragging(CombatPointerLayout self, Image dragItem)
        {
            self.IsDragging = true;
            self._dragIsActive = true;
            Vector2 oldMousePosition = self._rawMousePosition;
            GameObject currentDraggedObject = dragItem.gameObject;
            RectTransform component = dragItem.GetComponent<RectTransform>();
            self._pointerTransform.sizeDelta = component.rect.size;
            self._pointerTransform.position = component.position;
            self._pointerImage.enabled = true;
            while (self._dragIsActive && currentDraggedObject.activeInHierarchy)
            {
                self._pointerImage.sprite = Quorell.MenuFront;
                self._pointerTransform.anchoredPosition += (self._rawMousePosition - oldMousePosition) / self._canvas.scaleFactor;
                oldMousePosition = self._rawMousePosition;
                yield return null;
            }

            self._pointerImage.enabled = false;
            self._dragIsActive = false;
            self.IsDragging = false;
        }

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(InformationZoneLayout).GetMethod(nameof(InformationZoneLayout.SetCharacterInformation), ~BindingFlags.Default), typeof(QuorellHandler).GetMethod(nameof(SetCharacterInformation), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(CombatPointerLayout).GetMethod(nameof(CombatPointerLayout.OnStartDrag), ~BindingFlags.Default), typeof(QuorellHandler).GetMethod(nameof(OnStartDrag), ~BindingFlags.Default));
        }
        public static Image SlotImage
        {
            get
            {
                if (_image == null)
                {
                    GameObject trash = new GameObject();
                    _image = trash.AddComponent<Image>();
                    _image.sprite = Quorell.MenuFront;
                    trash.SetActive(true);
                }
                return _image;
            }
        }
        static Image _image;
    }

    public class QuorellInFieldLayout : CharacterInFieldLayout
    {
        public override Image SlotImage
        {
            get
            {
                if (_image == null)
                {
                    GameObject trash = new GameObject();
                    _image = trash.AddComponent<Image>();
                    _image.sprite = Quorell.MenuFront;
                }
                return _image;
            }
        }
        Image _image;
    }
}
