using System;

public class Base
{
   ~Base()
   {
      Console.WriteLine( "Base.~Base()" );
   }
}

public class Derived : Base
{
   ~Derived()
   {
      Console.WriteLine( "Derived.~Derived()" );
   }
}

public class EntryPoint
{
   static void Main()
   {
      Derived derived = new Derived();
   }
}
