using System;

public struct Square
{
   // Not a good idea to have public fields, but I use them
   // here only for the sake of example.  Prefer to expose
   // these with properties instead.
   public int width;
   public int height;
}

public class EntryPoint
{
   static void Main()
   {
      Square sq;
      sq.width = 1;
      
      // Can't do this yet.
      // Console.WriteLine( "{0} x {1}", sq.width, sq.height );

      sq.height = 2;
      
      Console.WriteLine( "{0} x {1}", sq.width, sq.height );
   }
}
