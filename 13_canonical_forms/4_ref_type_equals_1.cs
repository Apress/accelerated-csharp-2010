public class ComplexNumber
{
   public ComplexNumber( int real, int imaginary )
   {
      this.real = real;
      this.imaginary = imaginary;
   }

   public override bool Equals( object obj )
   {
      ComplexNumber other = obj as ComplexNumber;

      if( other == null )
      {
         return false;
      }

      return (this.real == other.real) &&
             (this.imaginary == other.imaginary);
   }

   public override int GetHashCode()
   {
      return (int) real ^ (int) imaginary;
   }

   public static bool operator==( ComplexNumber me, ComplexNumber other )
   {
      return Equals( me, other );
   }

   public static bool operator!=( ComplexNumber me, ComplexNumber other )
   {
      return Equals( me, other );
   }
   
   private double real;
   private double imaginary;
}

public class EntryPoint
{
   static void Main()
   {
      ComplexNumber referenceA = new ComplexNumber( 1, 2 );
      ComplexNumber referenceB = new ComplexNumber( 1, 2 );

      System.Console.WriteLine( "Result of Equality is {0}",
                                referenceA == referenceB );

      // If we really want referential equality.
      System.Console.WriteLine( "Identity of references is {0}",
                                (object) referenceA == (object) referenceB );
      System.Console.WriteLine( "Identity of references is {0}",
                                ReferenceEquals(referenceA, referenceB) );
   }
}
