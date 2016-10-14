public class ComplexNumber : System.IComparable
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

   public double Magnitude
   {
      get
      {
         return System.Math.Sqrt( System.Math.Pow(this.real, 2) +
                                  System.Math.Pow(this.imaginary, 2) );
      }
   }

   public int CompareTo( object obj )
   {
      if( obj is ComplexNumber )
      {
         ComplexNumber other = (ComplexNumber) obj;

         if( (this.real == other.real) &&
             (this.imaginary == other.imaginary) )
         {
            return 0;
         }
         else if( this.Magnitude < other.Magnitude )
         {
            return -1;
         }
         else
         {
            return 1;
         }
      }
      else 
      {
         throw new System.ArgumentException( "Wrong type" );
      }
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
      ComplexNumber referenceC = new ComplexNumber( 1, 3 );

      System.Console.WriteLine( "Result of referenceA.CompareTo(referenceB) is {0}",
                                referenceA.CompareTo(referenceB) );
      System.Console.WriteLine( "Result of referenceA.CompareTo(referenceC) is {0}",
                                referenceA.CompareTo(referenceC) );

   }
}
