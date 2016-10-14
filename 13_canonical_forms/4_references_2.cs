public class ComplexNumber
{
   public ComplexNumber( int real, int imaginary )
   {
      this.real = real;
      this.imaginary = imaginary;
   }
   
   private int real;
   private int imaginary;
}

public class EntryPoint
{
   static void Main()
   {
      ComplexNumber referenceA = new ComplexNumber( 1, 2 );
      ComplexNumber referenceB = new ComplexNumber( 1, 2 );

      System.Console.WriteLine( "Result of Equality is {0}",
                                referenceA == referenceB );
   }
}
