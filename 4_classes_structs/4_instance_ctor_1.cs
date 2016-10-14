public class A
{
   public A( int x )
   {
      this.x = x;
   }

   public A() : this( 123 )
   {
   }

   internal int x;
}

public class B : A
{
   public B() : base( 456 )
   {
   }

   ~B()
   {
   }
}

public class EntryPoint
{
   static void Main()
   {
      B b = new B();
      System.Console.WriteLine( "A.x = {0}", b.x );
   }
}
