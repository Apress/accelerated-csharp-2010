public struct ComplexNumber
{
   public ComplexNumber( double real, double imaginary )
   {
      this.real = real;
      this.imaginary = imaginary;
   }

   public ComplexNumber( double real )
      :this()
   {
      this.real = real;
   }

   private double real;
   private double imaginary;
}
