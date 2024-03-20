// Decompiled with JetBrains decompiler
// Type: GreasyFools.CharacterEXT
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class CharacterEXT
  {
    public static void SilentAddCharacter(this Character self)
    {
      self.charData.LoadedCharacter = self.c;
      self.charData._characterName = self.characterID == "" ? self.name + "_CH" : self.characterID;
      if (self.menuChar)
      {
        self.charData._portrait = self.unlockedSprite;
        self.charData._noPortrait = self.lockedSprite;
      }
      self.charData._isSecret = self.isSecret;
      ((Object) self.c).name = self.charData._characterName;
      self.c._characterName = self.name;
      self.c.characterEntityID = self.entityID;
      self.c.healthColor = self.healthColor;
      self.c.usesBasicAbility = self.usesBaseAbility;
      self.c.basicCharAbility = self.baseAbility == null ? BrutalAPI.BrutalAPI.slapCharAbility : self.baseAbility.CharacterAbility();
      self.c.usesAllAbilities = self.usesAllAbilities;
      self.c.rankedData = self.levels;
      self.c.passiveAbilities = self.passives;
      self.c.characterSprite = self.frontSprite;
      self.c.characterBackSprite = self.backSprite;
      self.c.extraCombatSprites = self.extraSprites;
      self.c.characterOWSprite = self.overworldSprite;
      self.c.movesOnOverworld = self.walksInOverworld;
      self.c.damageSound = self.hurtSound;
      self.c.deathSound = self.deathSound;
      self.c.speakerDataName = self.name;
      self.c.dxSound = self.dialogueSound;
      if (!self.appearsInShops)
      {
        for (int index = 0; index < BrutalAPI.BrutalAPI.hardAreas.Count; ++index)
          BrutalAPI.BrutalAPI.hardAreas[index]._omittedCharacters.Add(self.charData._characterName);
        for (int index = 0; index < BrutalAPI.BrutalAPI.easyAreas.Count; ++index)
          BrutalAPI.BrutalAPI.easyAreas[index]._omittedCharacters.Add(self.charData._characterName);
      }
      if (!LoadedAssetsHandler.LoadedCharacters.ContainsKey(self.charData._characterName))
        LoadedAssetsHandler.LoadedCharacters.Add(self.charData._characterName, self.c);
      BrutalAPI.BrutalAPI.moddedChars.Add(self.c);
    }

    public static void AddToMenu(this Character self)
    {
      SelectableCharacterData[] characters = BrutalAPI.BrutalAPI.selCharsSO._characters;
      List<SelectableCharacterData> selectableCharacterDataList = new List<SelectableCharacterData>();
      foreach (SelectableCharacterData selectableCharacterData in characters)
        selectableCharacterDataList.Add(selectableCharacterData);
      selectableCharacterDataList.Add(self.charData);
      BrutalAPI.BrutalAPI.selCharsSO._characters = selectableCharacterDataList.ToArray();
      if (self.isSupport)
        BrutalAPI.BrutalAPI.selCharsSO._supportCharacters.Add(new CharacterRefString(self.charData._characterName), new CharacterIgnoredAbilities()
        {
          ignoredAbilities = self.ignoredAbilities
        });
      else
        BrutalAPI.BrutalAPI.selCharsSO._dpsCharacters.Add(new CharacterRefString(self.charData._characterName), new CharacterIgnoredAbilities()
        {
          ignoredAbilities = self.ignoredAbilities
        });
    }
  }
}
