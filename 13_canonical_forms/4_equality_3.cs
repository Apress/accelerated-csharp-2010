public class EntryPoint
{
   static bool TestForEquality( object obj1, object obj2 )
   {
      if( obj1 == null && obj2 == null ) {
         return true;
      }

      if( obj1 == null )
      {
         return false;
      }

      return obj1.Equals( obj2 );
   }

   static void Main()
   {
      object obj1 = new System.Object();
      object obj2 = null;

      System.Console.WriteLine( "obj1 == obj2 is {0}",
                                TestForEquality(obj2, obj1) );
      System.Console.WriteLine( "null == null is {0}",
                                TestForEquality(null, null) );
   }
}
