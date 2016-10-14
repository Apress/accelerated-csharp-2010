using System;

public struct Complex
{
    public Complex( double real, double imaginary ) {
        this.real = real;
        this.imaginary = imaginary;
    }

    static public Complex Add( Complex lhs,
                               Complex rhs ) {
        return new Complex( lhs.real + rhs.real,
                            lhs.imaginary  + rhs.imaginary );
    }

    static public Complex Add( Complex lhs,
                               double rhs ) {

        return new Complex( rhs + lhs.real,
                            lhs.imaginary );
    }

    public override string ToString() {
        return String.Format( "({0}, {1})",
                              real,
                              imaginary );
    }

    static public Complex operator+( Complex lhs,
                                     Complex rhs ) {
        return Add( lhs, rhs );
    }

    static public Complex operator+( double lhs,
                                     Complex rhs ) {
        return Add( rhs, lhs );
    }

    static public Complex operator+( Complex lhs,
                                     double rhs ) {
        return Add( lhs, rhs );
    }

    private double real;
    private double imaginary;
}

public class EntryPoint
{
    static void Main() {
        Complex cpx1 = new Complex( 1.0, 3.0 );
        Complex cpx2 = new Complex( 1.0, 2.0 );

        Complex cpx3 = cpx1 + cpx2;
        Complex cpx4 = 20.0 + cpx1;
        Complex cpx5 = cpx1 + 25.0;

        Console.WriteLine( "cpx1 == {0}", cpx1 );
        Console.WriteLine( "cpx2 == {0}", cpx2 );
        Console.WriteLine( "cpx3 == {0}", cpx3 );
        Console.WriteLine( "cpx4 == {0}", cpx4 );
        Console.WriteLine( "cpx5 == {0}", cpx5 );
    }
}
