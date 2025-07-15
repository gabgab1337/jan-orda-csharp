using System;

namespace JanOrda.CSharp
{
  abstract class Zwierze
  {
    public abstract void dajGlos();

    public void spij()
    {
      Console.WriteLine("Zzzzzzzz...");
    }
  }

  interface IZwierze
  {
    void dajGlos();
    void spij();
  }

  class Pies : IZwierze
  {
    public void dajGlos()
    {
      Console.WriteLine("Hau hau!");
    }
    public void spij()
    {
      Console.WriteLine("Zzzz spie tera");
    }
  }

  class Ptak : Zwierze
  {
    public override void dajGlos()
    {
      Console.WriteLine("*Odglosy spiewu*");
    }
  }

  class Kot : Zwierze
  {
    public override void dajGlos()
    {
      Console.WriteLine("Miauuu");
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      System.Console.WriteLine("Hello, World!");

      Car myCar = new Car();

      myCar.honk();

    }
  }

  class Vehicle
  {
    public string brand = "Ford";

    public virtual void honk()
    {
      Console.WriteLine("Honk Honk!!!");
    }
  }

  class Car : Vehicle
  {
    public string model = "Mustang";

    public override void honk()
    {
      Console.WriteLine("Tuk Tuk!!!");
    }
  }

  class Chopper : Vehicle
  {
    public string model = "F123";

    public override void honk()
    {
      Console.WriteLine("Wroooom!!!");
    }
  }

}