public class A
{
   public A( int var )
   {
      this.x = var;
   }

   public virtual void DoSomething()
   {
      System.Console.WriteLine( "A.DoSomething" );
   }

   private int x;
}

public class B : A
{
   public B()
      : base( 123 )
   {
   }

   public override void DoSomething()
   {
      System.Console.WriteLine( "B.DoSomething" );
      base.DoSomething();
   }
   
}

public class EntryPoint
{
   static void Main()
   {
      B b = new B();

      b.DoSomething();
   }
}
