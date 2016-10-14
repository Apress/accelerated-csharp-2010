using System;
using System.Globalization;

public sealed class ComplexNumber : IFormattable
{
    public ComplexNumber( double real, double imaginary ) {
        this.real = real;
        this.imaginary = imaginary;
    }

    public override string ToString() {
        return ToString( "G", null );
    }

    // IFormattable implementation
    public string ToString( string format,
                            IFormatProvider formatProvider ) {
        string result = "(" +
            real.ToString(format, formatProvider) +
            " " +
            real.ToString(format, formatProvider) +
            ")";
        return result;
    }

    // Other methods removed for clarity
    
    private readonly double real;
    private readonly double imaginary;
}

public sealed class EntryPoint
{
    static void Main() {
        ComplexNumber num1 = new ComplexNumber( 1.12345678,
                                                2.12345678 );
        
        Console.WriteLine( "US format: {0}",
                           num1.ToString( "F5",
                                  new CultureInfo("en-US") ) );
        Console.WriteLine( "DE format: {0}",
                           num1.ToString( "F5",
                                  new CultureInfo("de-DE") ) );
        Console.WriteLine( "Object.ToString(): {0}",
                           num1.ToString() );
    }
}
