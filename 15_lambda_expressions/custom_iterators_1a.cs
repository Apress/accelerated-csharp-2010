using System;
using System.Linq;
using System.Collections.Generic;

public static class IteratorExtensions
{
    public static IEnumerable<TItem>
        MakeCustomIterator<TCollection, TCursor, TItem>(
                     this TCollection collection,
                     TCursor cursor,
                     Func<TCollection, TCursor, TItem> getCurrent,
                     Func<TCursor, bool> isFinished,
                     Func<TCursor, TCursor> advanceCursor) {
        while( !isFinished(cursor) ) {
            yield return getCurrent( collection, cursor );
            cursor = advanceCursor( cursor );
        }
    }
}

public class IteratorExample
{
    static void Main() {
        var matrix = new List<List<double>> {
            new List<double> { 1.0, 1.1, 1.2 },
            new List<double> { 2.0, 2.1, 2.2 },
            new List<double> { 3.0, 3.1, 3.2 }
        };

        var iter = matrix.MakeCustomIterator(
                     new int[] { 0, 0 },
                     (coll, cur) => coll[cur[0]][cur[1]],
                     (cur) => cur[0] > 2 || cur[1] > 2,
                     (cur) => new int[] { cur[0] + 1,
                                          cur[1] + 1 } );

        foreach( var item in iter ) {
            Console.WriteLine( item );
        }
    }
}
