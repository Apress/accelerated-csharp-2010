using System;

public delegate void PrintAndIncrement();

public class EntryPoint
{
    public static PrintAndIncrement[] CreateDelegates() {
        PrintAndIncrement[] delegates = new PrintAndIncrement[3];
        for( int i = 0; i < 3; ++i ) {
            int someVariable = 0;
            delegates[i] = delegate {
                Console.WriteLine( someVariable++ ); 
            };
        }
        return delegates;
    }

    static void Main() {
        PrintAndIncrement[] delegates = CreateDelegates();
        for( int i = 0; i < 3; ++i ) {
            delegates[i]();
        }
    }
}
