using System;
using System.Threading;
using System.Threading.Tasks;

class EntryPoint
{
    const int Iterations = 100;

    static void Main() {
        Console.WriteLine( "Working..." );

        Parallel.For( 0,
                      Iterations,
                      (i) => {
                        // Simulate some long amount of work.
                        Thread.Sleep( 3000 );
                      } );

        Console.WriteLine( "Done!" );
    }
}
