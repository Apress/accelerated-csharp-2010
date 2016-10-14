public class A
{
   public A()
   {
      this.y = 123;
   }

   private static int InitZ()
   {
      return 987;
   }

   private int x = 789;
   private int y;
   private int z = A.InitZ();

   static void Main()
   {
      A obj = new A();

      System.Console.WriteLine( "x = {0}, y = {1}, z = {2}",
                                obj.x, obj.y, obj.z );
   }
}
