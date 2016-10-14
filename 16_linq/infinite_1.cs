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
                    select number * 2 + 1;

        foreach( var item in query.Take(10) ) {
            Console.WriteLine( item );
        }
    }
}
