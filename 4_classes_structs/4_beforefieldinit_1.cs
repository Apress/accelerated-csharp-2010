using System;

public class A
{
   public A()
   {
      Console.WriteLine( "A.A()" );
   }
   
   static int InitX()
   {
      Console.WriteLine( "A.InitX()" );
      return 1;
   }
   
   public int x = InitX();
}

public class EntryPoint
{
   static void Main()
   {
      // No guarantee A.InitX() is called before this!
      A a = new A();
   }
}
