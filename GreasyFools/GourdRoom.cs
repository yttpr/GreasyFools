// Decompiled with JetBrains decompiler
// Type: GreasyFools.GourdRoom
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
  public static class GourdRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Gourd";

    private static string Files => "Gourd_CH";

    private static Character chara => Gourd.dies;

    private static int Zone => 1;

    private static bool Left => false;

    private static bool Center => true;

    public static Color32 Color => new Color32((byte) 199, (byte) 21, (byte) 21, byte.MaxValue);

    private static string roomName => GourdRoom.Name + "Room";

    private static string convoName => GourdRoom.Name + "Convo";

    private static string encounterName => GourdRoom.Name + "Encounter";

    private static Sprite Talk => GourdRoom.chara.frontSprite;

    private static Sprite Portal => GourdRoom.chara.unlockedSprite;

    private static string Audio => GourdRoom.chara.dialogueSound;

    private static int ID => (int) GourdRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) GourdRoom.ID, GourdRoom.Portal);
      GourdRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Raams/" + GourdRoom.Name + "Room.prefab");
      GourdRoom.Room = GourdRoom.Base.AddComponent<NPCRoomHandler>();
      GourdRoom.Room._npcSelectable = (BaseRoomItem) ((Component) GourdRoom.Room).transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      GourdRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) GourdRoom.Room._npcSelectable).transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      GourdRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = GourdRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Greasy." + GourdRoom.Name + ".TryHire";
      GourdRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = GourdRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = GourdRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = GourdRoom.roomName;
      instance2._freeFool = GourdRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) GourdRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) GourdRoom.ID
      };
      GourdRoom.Free = instance2;
      GourdRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = GourdRoom.Audio,
        portrait = GourdRoom.Talk,
        bundleTextColor = (UnityEngine.Color) GourdRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = GourdRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = GourdRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = GourdRoom.bundle;
      instance3.portraitLooksLeft = GourdRoom.Left;
      instance3.portraitLooksCenter = GourdRoom.Center;
      GourdRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + GourdRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + GourdRoom.roomName, (BaseRoomHandler) GourdRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + GourdRoom.roomName] = (BaseRoomHandler) GourdRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(GourdRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(GourdRoom.convoName, GourdRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[GourdRoom.convoName] = GourdRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(GourdRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(GourdRoom.encounterName, GourdRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[GourdRoom.encounterName] = GourdRoom.Free;
      Backrooms.AddPool(GourdRoom.encounterName, GourdRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(GourdRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(GourdRoom.speaker.speakerName, GourdRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[GourdRoom.speaker.speakerName] = GourdRoom.speaker;
    }
  }
}
