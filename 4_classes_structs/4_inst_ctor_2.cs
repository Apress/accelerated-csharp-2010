using System;

public class A
{
   public virtual void DoSomething()
   {
      Console.WriteLine( "A.DoSomething()" );
   }

   public A()
   {
      DoSomething();
   }
}

public class B : A
{
   public override void DoSomething()
   {
      Console.WriteLine( "B.DoSomething()" );
      Console.WriteLine( "x = {0}", x );
   }

   public B()
      :base()
   {
   }

   private int x = 123;
}

public class EntryPoint
{
   static void Main()
   {
      B b = new B();
   }
}
