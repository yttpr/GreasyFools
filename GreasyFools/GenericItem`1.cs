// Decompiled with JetBrains decompiler
// Type: GreasyFools.GenericItem`1
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public class GenericItem<T> : BrutalAPI.Item where T : BaseWearableSO
  {
    public T Item;

    public override BaseWearableSO Wearable()
    {
      T instance = ScriptableObject.CreateInstance<T>();
      instance.BaseWearable((BrutalAPI.Item) this);
      this.Item = instance;
      return (BaseWearableSO) instance;
    }
  }
}
