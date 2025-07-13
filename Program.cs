using System;

namespace JanOrda.CSharp
{
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