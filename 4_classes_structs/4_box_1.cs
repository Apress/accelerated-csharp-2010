public class EntryPoint
{
   static void Print( object obj )
   {
      System.Console.WriteLine( "{0}", obj.ToString() );
   }
   static void Main()
   {
      int x = 42;
      Print( x );
   }
}
