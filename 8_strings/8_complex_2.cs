using System;
using System.Text;
using System.Globalization;

public class ComplexDbgFormatter : ICustomFormatter, IFormatProvider
{
    // IFormatProvider implementation
    public object GetFormat( Type formatType ) {
        if( formatType == typeof(ICustomFormatter) ) {
            return this;
        } else {
            return CultureInfo.CurrentCulture.
                GetFormat( formatType );
        }
    }

    // ICustomFormatter implementation
    public string Format( string format,
                          object arg,
                          IFormatProvider formatProvider ) {
        if( arg.GetType() == typeof(Complex) && 
            format == "DBG" ) {
            Complex cpx = (Complex) arg;

            // Generate debugging output for this object.
            StringBuilder sb = new StringBuilder();
            sb.Append( arg.GetType().ToString() + "\n" );
            sb.AppendFormat( "\treal:\t{0}\n", cpx.Real );
            sb.AppendFormat( "\timaginary:\t{0}\n", cpx.Imaginary );
            return sb.ToString();
        } else {
            IFormattable formatable = arg as IFormattable;
            if( formatable != null ) {
                return formatable.ToString( format, formatProvider );
            } else {
                return arg.ToString();
            }
        }
    }
}

public struct Complex : IFormattable
{
    public Complex( double real, double imaginary ) {
        this.real = real;
        this.imaginary = imaginary;
    }

    public double Real {
        get { return real; }
    }

    public double Imaginary {
        get { return imaginary; }
    }

    // IFormattable implementation
    public string ToString( string format,
                     IFormatProvider formatProvider ) {
        StringBuilder sb = new StringBuilder();
        sb.Append( "( " );
        sb.Append( real.ToString(format, formatProvider) );
        sb.Append( " : " );
        sb.Append( imaginary.ToString(format, formatProvider) );
        sb.Append( " )" );

        return sb.ToString();
    }

    private double real;
    private double imaginary;
}

public class EntryPoint
{
    static void Main() {
        CultureInfo local = CultureInfo.CurrentCulture;
        CultureInfo germany = new CultureInfo( "de-DE" );

        Complex cpx = new Complex( 12.3456, 1234.56 );

        string strCpx = cpx.ToString( "F", local );
        Console.WriteLine( strCpx );

        strCpx = cpx.ToString( "F", germany );
        Console.WriteLine( strCpx );

        ComplexDbgFormatter dbgFormatter =
            new ComplexDbgFormatter();
        strCpx = String.Format( dbgFormatter,
                                "{0:DBG}",
                                cpx );
        Console.WriteLine( "\nDebugging output:\n{0}",
                           strCpx );
    }
}
