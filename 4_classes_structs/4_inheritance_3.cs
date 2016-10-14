public class A
{
   public void DoSomething()
   {
      System.Console.WriteLine( "A.DoSomething" );
   }
}

public class B : A
{
   public void DoSomethingElse()
   {
      System.Console.WriteLine( "B.DoSomethingElse" );
   }
}

public class EntryPoint
{
   static void Main()
   {
      B b = new B();

      b.DoSomething();
      b.DoSomethingElse();
   }
}
