// Decompiled with JetBrains decompiler
// Type: GreasyFools.TheSilliestSecretCharacter
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using Tools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

#nullable disable
namespace GreasyFools
{
  internal class TheSilliestSecretCharacter
  {
    public static class PasscodeReader
    {
      public static char[] passkey = new char[8]
      {
        'r',
        'a',
        'g',
        'e',
        'r',
        'r',
        'e',
        'd'
      };
      public static char[] altCAPSkey = new char[8]
      {
        'R',
        'A',
        'G',
        'E',
        'R',
        'R',
        'E',
        'D'
      };
      public static bool[] keyReader = new bool[TheSilliestSecretCharacter.PasscodeReader.passkey.Length];
      public static int place = 0;
      public static bool solved = false;

      public static void Add()
      {
        IDetour idetour = (IDetour) new Hook((MethodBase) typeof (Keyboard).GetMethod("OnTextInput", ~BindingFlags.Default), typeof (TheSilliestSecretCharacter.PasscodeReader).GetMethod("KeyPressed", ~BindingFlags.Default));
      }

      public static void SecretChara()
      {
        EZExtensions.PCall(new Action(( Ragerred.Eepy).AddToMenu), "ragerred");
        TheSilliestSecretCharacter.PasscodeReader.UpdateMenuUI();
      }

      public static void KeyPressed(Action<Keyboard, char> orig, Keyboard self, char c)
      {
        orig(self, c);
        if (TheSilliestSecretCharacter.PasscodeReader.solved)
          return;
        if (TheSilliestSecretCharacter.PasscodeReader.place >= TheSilliestSecretCharacter.PasscodeReader.keyReader.Length)
        {
          TheSilliestSecretCharacter.PasscodeReader.SecretChara();
          TheSilliestSecretCharacter.PasscodeReader.solved = true;
        }
        else if ((int) c == (int) TheSilliestSecretCharacter.PasscodeReader.passkey[TheSilliestSecretCharacter.PasscodeReader.place] || (int) c == (int) TheSilliestSecretCharacter.PasscodeReader.altCAPSkey[TheSilliestSecretCharacter.PasscodeReader.place])
        {
          int index = 0;
          while (index < TheSilliestSecretCharacter.PasscodeReader.place && TheSilliestSecretCharacter.PasscodeReader.keyReader[index])
            ++index;
          TheSilliestSecretCharacter.PasscodeReader.keyReader[TheSilliestSecretCharacter.PasscodeReader.place] = true;
          ++TheSilliestSecretCharacter.PasscodeReader.place;
          if (TheSilliestSecretCharacter.PasscodeReader.place < TheSilliestSecretCharacter.PasscodeReader.keyReader.Length)
            return;
          TheSilliestSecretCharacter.PasscodeReader.SecretChara();
          TheSilliestSecretCharacter.PasscodeReader.solved = true;
        }
        else
        {
          TheSilliestSecretCharacter.PasscodeReader.place = 0;
          TheSilliestSecretCharacter.PasscodeReader.Clear();
        }
      }

      public static void Clear()
      {
        TheSilliestSecretCharacter.PasscodeReader.place = 0;
        TheSilliestSecretCharacter.PasscodeReader.keyReader = new bool[TheSilliestSecretCharacter.PasscodeReader.passkey.Length];
      }

      public static void UpdateMenuUI()
      {
        BrutalAPI.BrutalAPI.mainMenuController.FinalizeMainMenuSounds();
        NtfUtils.notifications?.PostNotification(Utils.saveGameNtf);
        SceneManager.LoadScene("MainMenu_Scene");
      }
    }
  }
}
