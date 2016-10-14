public class A
{
   private int temperature;

   public int Temperature
   {
      get
      {
         System.Console.WriteLine( "Getting value for temperature" );
         return temperature;
      }

      set
      {
         System.Console.WriteLine( "Setting value for temperature" );
         temperature = value;
      }
   }
}

public class MainClass
{
   static void Main()
   {
      A obj = new A();

      obj.Temperature = 1;
      System.Console.WriteLine( "obj.Temperature = {0}",
                                obj.Temperature );
   }
}
