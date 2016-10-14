using System;

class C
{
    void ProcessInput( int x ) {
        Console.WriteLine( "int: " + x.ToString() );
    }

    public void ProcessInput( string msg ) {
        Console.WriteLine( "string: " + msg );
    }

    public void ProcessInput( double d ) {
        Console.WriteLine( "double: " + d.ToString() );
    }
}

static class EntryPoint
{
    static void Main() {
        dynamic obj1 = 123;
        dynamic obj2 = "C# Rocks!";
        dynamic obj3 = 3.1415;

        C c = new C();
        c.ProcessInput( obj1 );         // #1
        c.ProcessInput( obj2 );         // #2

        dynamic cObj = c;
        cObj.ProcessInput( obj3 );      // #3
    }
}
