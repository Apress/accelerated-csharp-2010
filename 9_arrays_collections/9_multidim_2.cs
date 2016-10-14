using System;

public class EntryPoint
{
    static void Main() {
        int[,] twoDim = { {1, 2, 3},
                          {4, 5, 6},
                          {7, 8, 9} };

        for( int i = 0; i != twoDim.GetLength(0); ++i ) {
            for( int j = 0; j != twoDim.GetLength(1); ++j ) {
                Console.WriteLine( twoDim[i,j] );
            }
        }

        for( int i = twoDim.GetLowerBound(0);
             i <= twoDim.GetUpperBound(0);
             ++i ) {
            for( int j = twoDim.GetLowerBound(1);
                 j <= twoDim.GetUpperBound(1);
                 ++j ) {
                Console.WriteLine( twoDim[i,j] );
            }
        }
    }
}
