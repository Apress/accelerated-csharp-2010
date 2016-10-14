public class MyClass
{
   public MyClass( int x, int y )
   {
      this.x = x;
      this.y = y;
   }

   public int x;
   public int y;
}

public class EntryPoint
{
   static void Main()
   {
      // We can't do this!
      // MyClass objA = new MyClass();

      MyClass objA = new MyClass( 1, 2 );
      System.Console.WriteLine( "objA.x = {0}, objA.y = {1}",
                                objA.x, objA.y );
   }
}
