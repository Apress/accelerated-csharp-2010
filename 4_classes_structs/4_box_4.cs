public interface IPrint
{
   void Print();
}

public struct MyValue : IPrint
{
   public int x;

   public void Print()
   {
      System.Console.WriteLine( "{0}", x );
   }
}

public class EntryPoint
{
   static void Main()
   {
      MyValue myval = new MyValue();
      myval.x = 123;

      // no boxing
      myval.Print();

      // must box the value
      IPrint printer = myval;
      printer.Print();
   }
}
