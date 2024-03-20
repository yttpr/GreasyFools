// Decompiled with JetBrains decompiler
// Type: GreasyFools.FelRoom
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
  public static class FelRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Fel";

    private static string Files => "Fel_CH";

    private static Character chara => Fel.Felt;

    private static int Zone => 0;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 251, (byte) 242, (byte) 54, byte.MaxValue);

    private static string roomName => FelRoom.Name + "Room";

    private static string convoName => FelRoom.Name + "Convo";

    private static string encounterName => FelRoom.Name + "Encounter";

    private static Sprite Talk => FelRoom.chara.frontSprite;

    private static Sprite Portal => FelRoom.chara.unlockedSprite;

    private static string Audio => FelRoom.chara.dialogueSound;

    private static int ID => (int) FelRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) FelRoom.ID, FelRoom.Portal);
      FelRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Raams/" + FelRoom.Name + "Room.prefab");
      FelRoom.Room = FelRoom.Base.AddComponent<NPCRoomHandler>();
      FelRoom.Room._npcSelectable = (BaseRoomItem) ((Component) FelRoom.Room).transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      FelRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) FelRoom.Room._npcSelectable).transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      FelRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = FelRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Greasy." + FelRoom.Name + ".TryHire";
      FelRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = FelRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = FelRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = FelRoom.roomName;
      instance2._freeFool = FelRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) FelRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) FelRoom.ID
      };
      FelRoom.Free = instance2;
      FelRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = FelRoom.Audio,
        portrait = FelRoom.Talk,
        bundleTextColor = (UnityEngine.Color) FelRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = FelRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = FelRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = FelRoom.bundle;
      instance3.portraitLooksLeft = FelRoom.Left;
      instance3.portraitLooksCenter = FelRoom.Center;
      FelRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + FelRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + FelRoom.roomName, (BaseRoomHandler) FelRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + FelRoom.roomName] = (BaseRoomHandler) FelRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(FelRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(FelRoom.convoName, FelRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[FelRoom.convoName] = FelRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(FelRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(FelRoom.encounterName, FelRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[FelRoom.encounterName] = FelRoom.Free;
      Backrooms.AddPool(FelRoom.encounterName, FelRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(FelRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(FelRoom.speaker.speakerName, FelRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[FelRoom.speaker.speakerName] = FelRoom.speaker;
    }
  }
}
