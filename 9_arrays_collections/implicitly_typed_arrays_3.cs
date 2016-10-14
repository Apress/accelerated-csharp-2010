using System;

public class EntryPoint {
    static void Main() {
        var threeByThree = new [] {
            new [] { 1, 2, 3 },
            new [] { 4, 5, 6 },
            new [] { 7, 8, 9 }
        };

        foreach( var i in threeByThree ) {
            foreach( var j in i ) {
                Console.Write( "{0}, ", j );
            }
            Console.Write( "\n" );
        }
    }
}
