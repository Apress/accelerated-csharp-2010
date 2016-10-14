public class A
{
   public A()
   {
      this.y = 456;

      // We can even set y again.
      this.y = 654;

      // We can use y as a ref param.
      SetField( ref this.y );
   }

   private void SetField( ref int val )
   {
      val = 888;
   }

   private readonly int x = 123;
   private readonly int y;
   public const     int z = 555;

   static void Main()
   {
      A obj = new A();

      System.Console.WriteLine( "x = {0}, y = {1}, z = {2}",
                                obj.x, obj.y, A.z );
   }
}
