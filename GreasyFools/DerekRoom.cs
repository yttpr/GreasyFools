// Decompiled with JetBrains decompiler
// Type: GreasyFools.DerekRoom
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
  public static class DerekRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Derek";

    private static string Files => "Derek_CH";

    private static Character chara => Derek.knight;

    private static int Zone => 1;

    private static bool Left => false;

    private static bool Center => true;

    public static Color32 Color => new Color32((byte) 107, (byte) 107, (byte) 224, byte.MaxValue);

    private static string roomName => DerekRoom.Name + "Room";

    private static string convoName => DerekRoom.Name + "Convo";

    private static string encounterName => DerekRoom.Name + "Encounter";

    private static Sprite Talk => DerekRoom.chara.frontSprite;

    private static Sprite Portal => DerekRoom.chara.unlockedSprite;

    private static string Audio => DerekRoom.chara.dialogueSound;

    private static int ID => (int) DerekRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) DerekRoom.ID, DerekRoom.Portal);
      DerekRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Raams/" + DerekRoom.Name + "Room.prefab");
      DerekRoom.Room = DerekRoom.Base.AddComponent<NPCRoomHandler>();
      DerekRoom.Room._npcSelectable = (BaseRoomItem) ((Component) DerekRoom.Room).transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      DerekRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) DerekRoom.Room._npcSelectable).transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      DerekRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = DerekRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Greasy." + DerekRoom.Name + ".TryHire";
      DerekRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = DerekRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = DerekRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = DerekRoom.roomName;
      instance2._freeFool = DerekRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) DerekRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) DerekRoom.ID
      };
      DerekRoom.Free = instance2;
      DerekRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = DerekRoom.Audio,
        portrait = DerekRoom.Talk,
        bundleTextColor = (UnityEngine.Color) DerekRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = DerekRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = DerekRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = DerekRoom.bundle;
      instance3.portraitLooksLeft = DerekRoom.Left;
      instance3.portraitLooksCenter = DerekRoom.Center;
      DerekRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + DerekRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + DerekRoom.roomName, (BaseRoomHandler) DerekRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + DerekRoom.roomName] = (BaseRoomHandler) DerekRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(DerekRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(DerekRoom.convoName, DerekRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[DerekRoom.convoName] = DerekRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(DerekRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(DerekRoom.encounterName, DerekRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[DerekRoom.encounterName] = DerekRoom.Free;
      Backrooms.AddPool(DerekRoom.encounterName, DerekRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(DerekRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(DerekRoom.speaker.speakerName, DerekRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[DerekRoom.speaker.speakerName] = DerekRoom.speaker;
    }
  }
}
