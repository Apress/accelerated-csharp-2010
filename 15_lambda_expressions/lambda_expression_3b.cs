using System;

public class LambdaTest
{
    static void Main() {
        int counter = 0;

        WriteStream( delegate () {
                        return counter++;
                     } );

        Console.WriteLine( "Final value of counter: {0}",
                           counter );
    }

    static void WriteStream( Func<int> counter ) {
        for( int i = 0; i < 10; ++i ) {
            Console.Write( "{0}, ", counter() );
        }
        Console.WriteLine();
    }
}
