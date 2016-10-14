using System;

class C
{
    static public void Foo( double dbl, dynamic dyn ) {
        Console.WriteLine( "void Foo( double dbl, dynamic dyn )" );
    }
    static public void Foo( int i, string str ) {
        Console.WriteLine( "void Foo( int i, string str )" );
    }
}

static class EntryPoint
{
    static void Main() {
        dynamic  d = "I'm dynamic";
        dynamic d1 = new object();

        C.Foo( 3.1415, d );            // is it a compile-time overload?
        C.Foo( 42, d );                // run-time overload
        C.Foo( 42, d1 );               // run-time overload

        // The following will not compile!
        // C.Foo( "Hello!", d );
    }
}
