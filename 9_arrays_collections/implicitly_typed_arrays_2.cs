using System;

public struct A
{
    public A( int i ) {
        this.i = i;
    }

    public static implicit operator B( A a ) {
        return new B( a.i );
    }

    private int i;
}

public struct B
{
    public B( int j ) {
        this.j = j;
    }

    public static implicit operator A( B b ) {
        return new A( b.j );
    }

    private int j;
}

public class EntryPoint
{
    static void Main() {
        A a = new A( 42 );
        B b = a;

        // Won't compile!
        // var newArray = new [] { a, b };
    }
}
