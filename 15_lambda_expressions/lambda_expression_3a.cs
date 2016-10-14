using System;

unsafe public class MyClosure
{
    public MyClosure( int* counter )
    {
        this.counter = counter;
    }

    public delegate int IncDelegate();
    public IncDelegate GetDelegate() {
        return new IncDelegate( IncrementFunction );
    }

    private int IncrementFunction() {
        return (*counter)++;
    }

    private int* counter;
}

public class LambdaTest
{
    unsafe static void Main() {
        int counter = 0;
        
        MyClosure closure = new MyClosure( &counter );

        WriteStream( closure.GetDelegate() );

        Console.WriteLine( "Final value of counter: {0}",
                           counter );
    }

    static void WriteStream( MyClosure.IncDelegate incrementor ) {
        for( int i = 0; i < 10; ++i ) {
            Console.Write( "{0}, ", incrementor() );
        }
        Console.WriteLine();
    }
}
