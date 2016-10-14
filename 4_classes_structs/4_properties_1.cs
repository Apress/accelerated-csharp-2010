public class A
{
   public static void SomeFunction( ref int i )
   {
      i = 4;
   }
   
   static void Main()
   {
      SomeObject obj = new SomeObject();

      obj.X = 1;     // could be a public field or a property
      obj.Y = 2;     // could be a public field or a property

      // This is an error if X is a property
      // SomeFunction( ref obj.X );
   }
}
