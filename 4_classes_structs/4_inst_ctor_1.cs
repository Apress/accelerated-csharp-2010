using System;

class Base
{
   public Base( int x )
   {
      Console.WriteLine( "Base.Base(int)" );
      this.x = x;
   }
   
   private static int InitX()
   {
      Console.WriteLine( "Base.InitX()" );
      return 1;
   }
   
   public int x = InitX();
}

class Derived : Base
{
   public Derived( int a )
      :base( a )
   {
      Console.WriteLine( "Derived.Derived(int)" );
      this.a = a;
   }

   public Derived( int a, int b )
      :this( a )
   {
      Console.WriteLine( "Derived.Derived(int, int)" );
      this.a = a;
      this.b = b;
   }

   private static int InitA()
   {
      Console.WriteLine( "Derived.InitA()" );
      return 3;
   }

   private static int InitB()
   {
      Console.WriteLine( "Derived.InitB()" );
      return 4;
   }

   public int a = InitA();
   public int b = InitB();
}

public class EntryPoint
{
   static void Main()
   {
      Derived b = new Derived( 1, 2 );
   }
}
