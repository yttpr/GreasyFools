// Decompiled with JetBrains decompiler
// Type: GreasyFools.ExtraMungItem
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;
using Tools;
#nullable disable
namespace GreasyFools
{
  public class ExtraMungItem : BasicRoomItem
  {
    public override void PerformClick()
    {
      foreach (GameInformationHolder informationHolder in Resources.FindObjectsOfTypeAll(typeof (GameInformationHolder)))
      {
        if (informationHolder.HasRunData)
        {
          RunDataSO run = informationHolder.Run;
          if (run.playerData.HasCharacterSpace)
          {
            this.Die();
            run.TryHireCharacter(new string[1]{ "Mung_CH" });
          }
        }
      }
    }

    public void Die()
    {
      ((BaseRoomItem) this).DisableItem();
      ((BaseRoomItem) this).HideItem();
    }

    public void Setup() => ((BaseRoomItem) this).Notification = "mungugugugug";
  }

    public class ExtraMungRoomHandler : NPCRoomHandler
    {
        public override void PopulateRoom(IGameCheckData gameData, IMinimalRunInfoData runData, IMinimalZoneInfoData zoneData, int dataID)
        {
            base.PopulateRoom(gameData, runData, zoneData, dataID);
            if (_extraSelectable != null)
            {
                DialogueDataReference args = new DialogueDataReference(dataID, _dialogueMusic);
                _extraSelectable.SetClickData(Utils.startDialogNtf, args);
            }
        }
    }
}
