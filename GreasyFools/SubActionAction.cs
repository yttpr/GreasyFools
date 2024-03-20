// Decompiled with JetBrains decompiler
// Type: GreasyFools.SubActionAction
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

using System.Collections;

#nullable disable
namespace GreasyFools
{
  public class SubActionAction : CombatAction
  {
    public CombatAction ex;

    public SubActionAction(CombatAction a) => this.ex = a;

    public override IEnumerator Execute(CombatStats stats)
    {
      CombatManager.Instance.AddSubAction(this.ex);
      yield return (object) null;
    }
  }
}
