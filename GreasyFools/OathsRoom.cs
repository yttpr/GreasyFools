// Decompiled with JetBrains decompiler
// Type: GreasyFools.OathsRoom
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
  public static class OathsRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Oaths";

    private static string Files => "Oaths_CH";

    private static Character chara => Oaths.Oatmeal;

    private static int Zone => 2;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 251, (byte) 73, (byte) 73, byte.MaxValue);

    private static string roomName => OathsRoom.Name + "Room";

    private static string convoName => OathsRoom.Name + "Convo";

    private static string encounterName => OathsRoom.Name + "Encounter";

    private static Sprite Talk => OathsRoom.chara.frontSprite;

    private static Sprite Portal => OathsRoom.chara.overworldSprite;

    private static string Audio => OathsRoom.chara.dialogueSound;

    private static int ID => (int) OathsRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) OathsRoom.ID, OathsRoom.Portal);
      OathsRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Raams/" + OathsRoom.Name + "Room.prefab");
      OathsRoom.Room = OathsRoom.Base.AddComponent<NPCRoomHandler>();
      OathsRoom.Room._npcSelectable = (BaseRoomItem) ((Component) OathsRoom.Room).transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      OathsRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) OathsRoom.Room._npcSelectable).transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      OathsRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = OathsRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Greasy." + OathsRoom.Name + ".TryHire";
      OathsRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = OathsRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = OathsRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = OathsRoom.roomName;
      instance2._freeFool = OathsRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) OathsRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) OathsRoom.ID
      };
      OathsRoom.Free = instance2;
      OathsRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = OathsRoom.Audio,
        portrait = OathsRoom.Talk,
        bundleTextColor = (UnityEngine.Color) OathsRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = OathsRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = OathsRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = OathsRoom.bundle;
      instance3.portraitLooksLeft = OathsRoom.Left;
      instance3.portraitLooksCenter = OathsRoom.Center;
      OathsRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + OathsRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + OathsRoom.roomName, (BaseRoomHandler) OathsRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + OathsRoom.roomName] = (BaseRoomHandler) OathsRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(OathsRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(OathsRoom.convoName, OathsRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[OathsRoom.convoName] = OathsRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(OathsRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(OathsRoom.encounterName, OathsRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[OathsRoom.encounterName] = OathsRoom.Free;
      Backrooms.AddPool(OathsRoom.encounterName, OathsRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(OathsRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(OathsRoom.speaker.speakerName, OathsRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[OathsRoom.speaker.speakerName] = OathsRoom.speaker;
    }
  }
}
