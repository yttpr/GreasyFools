// Decompiled with JetBrains decompiler
// Type: GreasyFools.StainRoom
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class StainRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Stain";

    private static string Files => "Stain_CH";

    private static Character chara => Stain.Staint;

    private static int Zone => 1;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 166, (byte) 19, (byte) 181, byte.MaxValue);

    private static string roomName => StainRoom.Name + "Room";

    private static string convoName => StainRoom.Name + "Convo";

    private static string encounterName => StainRoom.Name + "Encounter";

    private static Sprite Talk => StainRoom.chara.frontSprite;

    private static Sprite Portal => StainRoom.chara.overworldSprite;

    private static string Audio => StainRoom.chara.dialogueSound;

    private static int ID => (int) StainRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) StainRoom.ID, StainRoom.Portal);
      StainRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Raams/" + StainRoom.Name + "Room.prefab");
      StainRoom.Room = StainRoom.Base.AddComponent<NPCRoomHandler>();
      StainRoom.Room._npcSelectable = (BaseRoomItem) ((Component) StainRoom.Room).transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      StainRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) StainRoom.Room._npcSelectable).transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      StainRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = StainRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Greasy." + StainRoom.Name + ".TryHire";
      StainRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = StainRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = StainRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = StainRoom.roomName;
      instance2._freeFool = StainRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) StainRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) StainRoom.ID
      };
      StainRoom.Free = instance2;
      StainRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = StainRoom.Audio,
        portrait = StainRoom.Talk,
        bundleTextColor = (UnityEngine.Color) StainRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = StainRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = StainRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = StainRoom.bundle;
      instance3.portraitLooksLeft = StainRoom.Left;
      instance3.portraitLooksCenter = StainRoom.Center;
      StainRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + StainRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + StainRoom.roomName, (BaseRoomHandler) StainRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + StainRoom.roomName] = (BaseRoomHandler) StainRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(StainRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(StainRoom.convoName, StainRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[StainRoom.convoName] = StainRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(StainRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(StainRoom.encounterName, StainRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[StainRoom.encounterName] = StainRoom.Free;
      Backrooms.AddPool(StainRoom.encounterName, StainRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(StainRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(StainRoom.speaker.speakerName, StainRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[StainRoom.speaker.speakerName] = StainRoom.speaker;
    }
  }
}
