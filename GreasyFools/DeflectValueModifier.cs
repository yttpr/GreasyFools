// Decompiled with JetBrains decompiler
// Type: GreasyFools.DeflectValueModifier
// Assembly: GreasyFools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1508033A-ADD4-441E-A19F-898320C8C40C
// Assembly location: C:\Users\windows\Downloads\GreasyFools.dll

#nullable disable
namespace GreasyFools
{
  public class DeflectValueModifier : IntValueModifier
  {
    public readonly int toNumb;

    public DeflectValueModifier(int toNumb)
      : base(70)
    {
      this.toNumb = toNumb;
    }

    public override int Modify(int value) => value <= 0 ? value : value - this.toNumb;
  }
}
