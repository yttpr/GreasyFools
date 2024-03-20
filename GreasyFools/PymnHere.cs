// Decompiled with JetBrains decompiler
// Type: GreasyFools.PymnHere
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using UnityEngine;

#nullable disable
namespace GreasyFools
{
  public static class PymnHere
  {
    private static AssetBundle _assets;

    public static AssetBundle Assets
    {
      get
      {
        if ((Object) PymnHere._assets == (Object) null)
          PymnHere._assets = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("geese"));
        return PymnHere._assets;
      }
    }
  }
}
