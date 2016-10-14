public class A
{
   public A(int x) {
      this.x = x;
   }

   private int x;
}

public class B : A
{
}

public class EntryPoint
{
   static void Main()
   {
      B b = new B();
   }
}
