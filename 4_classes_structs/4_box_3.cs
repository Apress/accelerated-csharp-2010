public interface IModifyMyValue
{
   int X
   {
      get;
      set;
   }
}

public struct MyValue : IModifyMyValue
{
   public int x;

   public int X
   {
      get
      {
         return x;
      }

      set
      {
         x = value;
      }
   }

   public override string ToString()
   {
      System.Text.StringBuilder output =
          new System.Text.StringBuilder();
      output.AppendFormat( "{0}", x );
      return output.ToString();
   }
}

public class EntryPoint
{
   static void Main()
   {
      // Create value
      MyValue myval = new MyValue();
      myval.x = 123;

      // box it
      object obj = myval;
      System.Console.WriteLine( "{0}", obj.ToString() );

      // modify the contents in the box.
      IModifyMyValue iface = (IModifyMyValue) obj;
      iface.X = 456;
      System.Console.WriteLine( "{0}", obj.ToString() );

      // unbox it and see what it is.
      MyValue newval = (MyValue) obj;
      System.Console.WriteLine( "{0}", newval.ToString() );
   }
}
