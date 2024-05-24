// Decompiled with JetBrains decompiler
// Type: GreasyFools.QuorellRoom
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
  public static class QuorellRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Quorell";

    private static string Files => "Quorell_CH";

    private static Character chara => Quorell.bird;

    private static int Zone => 2;

    private static bool Left => false;

    private static bool Center => true;

    public static Color32 Color => new Color32((byte) 94, (byte) 220, (byte) 193, byte.MaxValue);

    private static string roomName => QuorellRoom.Name + "Room";

    private static string convoName => QuorellRoom.Name + "Convo";

    private static string encounterName => QuorellRoom.Name + "Encounter";

    private static Sprite Talk => QuorellRoom.chara.frontSprite;

    private static Sprite Portal => QuorellRoom.chara.overworldSprite;

    private static string Audio => QuorellRoom.chara.dialogueSound;

    private static int ID => (int) QuorellRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) QuorellRoom.ID, QuorellRoom.Portal);
      QuorellRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Raams/" + QuorellRoom.Name + "Room.prefab");
      QuorellRoom.Room = QuorellRoom.Base.AddComponent<NPCRoomHandler>();
      QuorellRoom.Room._npcSelectable = (BaseRoomItem) ((Component) QuorellRoom.Room).transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      QuorellRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) QuorellRoom.Room._npcSelectable).transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      QuorellRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = QuorellRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Greasy." + QuorellRoom.Name + ".TryHire";
      QuorellRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = QuorellRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = QuorellRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = QuorellRoom.roomName;
      instance2._freeFool = QuorellRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) QuorellRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) QuorellRoom.ID
      };
      QuorellRoom.Free = instance2;
      QuorellRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = QuorellRoom.Audio,
        portrait = QuorellRoom.Talk,
        bundleTextColor = (UnityEngine.Color) QuorellRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = QuorellRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = QuorellRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = QuorellRoom.bundle;
      instance3.portraitLooksLeft = QuorellRoom.Left;
      instance3.portraitLooksCenter = QuorellRoom.Center;
      QuorellRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + QuorellRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + QuorellRoom.roomName, (BaseRoomHandler) QuorellRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + QuorellRoom.roomName] = (BaseRoomHandler) QuorellRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(QuorellRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(QuorellRoom.convoName, QuorellRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[QuorellRoom.convoName] = QuorellRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(QuorellRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(QuorellRoom.encounterName, QuorellRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[QuorellRoom.encounterName] = QuorellRoom.Free;
      Backrooms.AddPool(QuorellRoom.encounterName, QuorellRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(QuorellRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(QuorellRoom.speaker.speakerName, QuorellRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[QuorellRoom.speaker.speakerName] = QuorellRoom.speaker;
    }
  }
}
