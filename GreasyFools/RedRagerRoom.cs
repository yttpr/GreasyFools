// Decompiled with JetBrains decompiler
// Type: GreasyFools.RedRagerRoom
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
  public static class RedRagerRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "RedRager";

    private static string Files => "RedRager_CH";

    private static Character chara => RedRager.angy;

    private static int Zone => 0;

    private static bool Left => false;

    private static bool Center => true;

    public static Color32 Color => new Color32((byte) 199, (byte) 27, (byte) 27, byte.MaxValue);

    private static string roomName => RedRagerRoom.Name + "Room";

    private static string convoName => RedRagerRoom.Name + "Convo";

    private static string encounterName => RedRagerRoom.Name + "Encounter";

    private static Sprite Talk => RedRagerRoom.chara.frontSprite;

    private static Sprite Portal => RedRagerRoom.chara.unlockedSprite;

    private static string Audio => RedRagerRoom.chara.dialogueSound;

    private static int ID => (int) RedRagerRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) RedRagerRoom.ID, RedRagerRoom.Portal);
      RedRagerRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Raams/" + RedRagerRoom.Name + "Room.prefab");
      RedRagerRoom.Room = RedRagerRoom.Base.AddComponent<NPCRoomHandler>();
      RedRagerRoom.Room._npcSelectable = (BaseRoomItem) ((Component) RedRagerRoom.Room).transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      RedRagerRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) RedRagerRoom.Room._npcSelectable).transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      RedRagerRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      ExtraMungItem extraMungItem = ((Component) RedRagerRoom.Room).transform.GetChild(1).gameObject.AddComponent<ExtraMungItem>();
            extraMungItem._renderers = new SpriteRenderer[]
            {
                extraMungItem.transform.GetChild(0).GetComponent<SpriteRenderer>(),
            };
            extraMungItem._renderers[0].material = Backrooms.Mat;
            Room._extraSelectable = extraMungItem;
      ((BaseRoomItem) extraMungItem)._renderers = new SpriteRenderer[1]
      {
        ((Component) extraMungItem).transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      ((BaseRoomItem) extraMungItem)._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = RedRagerRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Greasy." + RedRagerRoom.Name + ".TryHire";
      RedRagerRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = RedRagerRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = RedRagerRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = RedRagerRoom.roomName;
      instance2._freeFool = RedRagerRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) RedRagerRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) RedRagerRoom.ID
      };
      RedRagerRoom.Free = instance2;
      RedRagerRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = RedRagerRoom.Audio,
        portrait = RedRagerRoom.Talk,
        bundleTextColor = (UnityEngine.Color) RedRagerRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = RedRagerRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = RedRagerRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = RedRagerRoom.bundle;
      instance3.portraitLooksLeft = RedRagerRoom.Left;
      instance3.portraitLooksCenter = RedRagerRoom.Center;
      RedRagerRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + RedRagerRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + RedRagerRoom.roomName, (BaseRoomHandler) RedRagerRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + RedRagerRoom.roomName] = (BaseRoomHandler) RedRagerRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(RedRagerRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(RedRagerRoom.convoName, RedRagerRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[RedRagerRoom.convoName] = RedRagerRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(RedRagerRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(RedRagerRoom.encounterName, RedRagerRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[RedRagerRoom.encounterName] = RedRagerRoom.Free;
      Backrooms.AddPool(RedRagerRoom.encounterName, RedRagerRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(RedRagerRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(RedRagerRoom.speaker.speakerName, RedRagerRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[RedRagerRoom.speaker.speakerName] = RedRagerRoom.speaker;
    }
  }
}
