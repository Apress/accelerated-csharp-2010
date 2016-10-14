using System;

static class EntryPoint
{
    static void Main() {
        string[] strings = new string[] {
            "One",
            "Two",
            "Three"
        };

        DisplayStrings( strings );

        // Array covariance rules allow the following
        // assignment
        object[] objects = strings;

        // But what happens now?
        objects[1] = new object();
        DisplayStrings( strings );
    }

    static void DisplayStrings( string[] strings ) {
        Console.WriteLine( "----- Printing strings -----" );
        foreach( var s in strings ) {
            Console.WriteLine( s );
        }
    }
}
