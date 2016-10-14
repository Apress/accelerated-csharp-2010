using System;
using System.Linq;
using System.Collections.Generic;

public static class MyExtensions
{
    public static IEnumerable<R> Transform<T, R>(
                     this IEnumerable<T> input,
                     Func<T, R> op ) {
        foreach( var item in input ) {
            yield return op( item );
        }
    }
}

public class TransformExample
{
    static IEnumerable<int> CreateInfiniteList() {
        int n = 0;
        while( true ) yield return n++;
    }

    static double DivideByThree( int n ) {
        return (double)n / 3;
    }

    static double Square( double r ) {
        return r * r;
    }

    static void Main() {
        var divideByThree =
            new Func<int, double>( DivideByThree );
        var squareNumber = 
            new Func<double, double>( Square );

        var result = CreateInfiniteList().
                        Transform( divideByThree ).
                        Transform( squareNumber );

        var iter = result.GetEnumerator();
        for( int i = 0; i < 25; ++i ) {
            iter.MoveNext();
            Console.WriteLine( iter.Current );
        }
    }
}
