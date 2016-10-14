using System;
using System.Collections.Generic;

public static class MySqoSet
{
    public static IEnumerable<T> Where<T> (
              this IEnumerable<T> source,
              System.Func<T,bool> predicate ) {
        Console.WriteLine( "My Where implementation called." );
        return System.Linq.Enumerable.Where( source,
                                             predicate );
    }

    public static IEnumerable<R> Select<T,R> (
              this IEnumerable<T> source,
              System.Func<T,R> selector ) {
        Console.WriteLine( "My Select implementation called." );
        return System.Linq.Enumerable.Select( source,
                                              selector );
    }
}

public class CustomSqo
{
    static void Main() {
        int[] numbers = { 1, 2, 3, 4 };

        var query = from x in numbers
                    where x % 2 == 0
                    select x * 2;

        foreach( var item in query ) {
            Console.WriteLine( item );
        }
    }
}
