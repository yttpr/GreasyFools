// Decompiled with JetBrains decompiler
// Type: GreasyFools.BiersalRoom
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
  public static class BiersalRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Biersal";

    private static string Files => "Biersal_CH";

    private static Character chara => Biersal.bagger;

    private static int Zone => 0;

    private static bool Left => false;

    private static bool Center => true;

    public static Color32 Color => new Color32((byte) 143, (byte) 86, (byte) 59, byte.MaxValue);

    private static string roomName => BiersalRoom.Name + "Room";

    private static string convoName => BiersalRoom.Name + "Convo";

    private static string encounterName => BiersalRoom.Name + "Encounter";

    private static Sprite Talk => BiersalRoom.chara.frontSprite;

    private static Sprite Portal => BiersalRoom.chara.unlockedSprite;

    private static string Audio => BiersalRoom.chara.dialogueSound;

    private static int ID => (int) BiersalRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) BiersalRoom.ID, BiersalRoom.Portal);
      BiersalRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Raams/" + BiersalRoom.Name + "Room.prefab");
      BiersalRoom.Room = BiersalRoom.Base.AddComponent<NPCRoomHandler>();
      BiersalRoom.Room._npcSelectable = (BaseRoomItem) ((Component) BiersalRoom.Room).transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      BiersalRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) BiersalRoom.Room._npcSelectable).transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      BiersalRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = BiersalRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Greasy." + BiersalRoom.Name + ".TryHire";
      BiersalRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = BiersalRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = BiersalRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = BiersalRoom.roomName;
      instance2._freeFool = BiersalRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) BiersalRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) BiersalRoom.ID
      };
      BiersalRoom.Free = instance2;
      BiersalRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = BiersalRoom.Audio,
        portrait = BiersalRoom.Talk,
        bundleTextColor = (UnityEngine.Color) BiersalRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = BiersalRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = BiersalRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = BiersalRoom.bundle;
      instance3.portraitLooksLeft = BiersalRoom.Left;
      instance3.portraitLooksCenter = BiersalRoom.Center;
      BiersalRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + BiersalRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + BiersalRoom.roomName, (BaseRoomHandler) BiersalRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + BiersalRoom.roomName] = (BaseRoomHandler) BiersalRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(BiersalRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(BiersalRoom.convoName, BiersalRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[BiersalRoom.convoName] = BiersalRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(BiersalRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(BiersalRoom.encounterName, BiersalRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[BiersalRoom.encounterName] = BiersalRoom.Free;
      Backrooms.AddPool(BiersalRoom.encounterName, BiersalRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(BiersalRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(BiersalRoom.speaker.speakerName, BiersalRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[BiersalRoom.speaker.speakerName] = BiersalRoom.speaker;
    }
  }
}
