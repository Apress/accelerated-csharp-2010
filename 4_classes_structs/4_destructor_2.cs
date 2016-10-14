using System;

public class A
{
   ~A()
   {
      Console.WriteLine( "A.~A()" );
      
      // Store away a reference to ourselves.
      EntryPoint.obj = this;
   }

   private object objA;
   private object ojbB;
}

public class EntryPoint
{
   internal static A obj;

   static void Main()
   {
      {
         A a = new A();
      }

      // Force a collect.
      GC.Collect();
      GC.WaitForPendingFinalizers();

      Console.WriteLine( "Done" );
   }
}
