public class A
{
   private void SomeOperation()
   {
      x = 1;
      this.y = 2;
      z = 3;

      // assigning this in objects is an error.
      // A newinstance = new A();
      // this = newinstance;
   }

   private int x;
   private int y;
   private static int z;

   static void Main()
   {
      A obj = new A();

      obj.SomeOperation();

      System.Console.WriteLine( "x = {0}, y = {1}, z= {2}",
                                obj.x, obj.y, A.z );
   }
}
