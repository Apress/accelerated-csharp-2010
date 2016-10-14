using System;
using System.Linq;
using System.Collections.Generic;

public class InfiniteList
{
    static IEnumerable<int> AllIntegers() {
        int count = 0;
        while( true ) {
            yield return count++;
        }
    }

    static void Main() {
        var query = from number in AllIntegers()
                    orderby number descending
                    select number * 2 + 1;

        IEnumerator<int> results = query.GetEnumerator();
        for( int i = 0; i < 10; ++i ) {
            results.MoveNext();
            Console.WriteLine( results.Current );
        }
    }
}
