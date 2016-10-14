public class Base
{
   public void Base();

   public void DoSomething()
   {
      // Doing something
   }
}

public interface ISomeInterface
{
   void DoSomethingElse();
}

public class Derived : Base, ISomeInterface
{
   public void DoSomethingElse()
   {
      // doing something else
   }

   public void DoSomethingCompletelyDifferent()
   {
      // doing something completely different.
   }
}
