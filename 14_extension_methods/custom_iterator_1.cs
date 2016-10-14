using System;
using System.Collections.Generic;

public class IteratorExample
{
    static void Main() {
        var matrix = new List<List<int>> {
            new List<int> { 1, 2, 3 },
            new List<int> { 4, 5, 6 },
            new List<int> { 7, 8, 9 }
        };

        // One way of iterating the matrix.
        foreach( var list in matrix ) {
            foreach( var item in list ) {
                Console.Write( "{0}, ", item );
            }
        }

        Console.WriteLine();
    }
}
