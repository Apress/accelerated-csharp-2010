public class EntryPoint
{
   static void PrintAndModify( object obj )
   {
      System.Console.WriteLine( "{0}", obj.ToString() );
      int x = (int) obj;
      x = 21;
   }
   static void Main()
   {
      int x = 42;
      PrintAndModify( x );
      PrintAndModify( x );
   }
}
