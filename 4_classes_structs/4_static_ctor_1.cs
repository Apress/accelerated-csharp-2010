using System;

public class A
{
   static A()
   {
      Console.WriteLine( "static A::A()" );
   }

   private static int InitX()
   {
      Console.WriteLine( "A.InitX()" );
      return 1;
   }
   private static int InitY()
   {
      Console.WriteLine( "A.InitY()" );
      return 2;
   }
   private static int InitA()
   {
      Console.WriteLine( "A.InitA()" );
      return 3;
   }
   private static int InitB()
   {
      Console.WriteLine( "A.InitB()" );
      return 4;
   }

   private int y = InitY();
   private int x = InitX();

   private static int a = InitA();
   private static int b = InitB();
}

public class EntryPoint
{
   static void Main()
   {
      A a = new A();
   }
}
