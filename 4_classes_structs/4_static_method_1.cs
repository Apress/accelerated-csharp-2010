public class A
{
   public static void SomeFunction()
   {
      System.Console.WriteLine( "SomeFunction() called" );
   }

   static void Main()
   {
      A.SomeFunction();
      SomeFunction();
   }
}
