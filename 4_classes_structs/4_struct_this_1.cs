public struct ComplexNumber
{
   public ComplexNumber( double real, double imaginary )
   {
      this.real = real;
      this.imaginary = imaginary;
   }

   public ComplexNumber( ComplexNumber other )
   {
      this = other;
   }

   private double real;
   private double imaginary;
}

public class EntryPoint
{
   static void Main()
   {
      ComplexNumber valA = new ComplexNumber( 1, 2 );
      ComplexNumber copyA = new ComplexNumber( valA );
   }
}
