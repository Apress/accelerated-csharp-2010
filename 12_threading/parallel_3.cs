using System;
using System.Threading;
using System.Threading.Tasks;

class EntryPoint
{
    const int Iterations = 100;

    static volatile bool shouldStop = false;

    static void DoWork() {
        Parallel.For( 
            0,
            Iterations,

            (i, loopState) => {
                  // Check to see if we should stop the loop.
                  if( shouldStop ) {
                      Console.WriteLine( "Asked to stop..." );
                      loopState.Stop();
                  }

                  // Check to make sure another loop didn't
                  // ask to stop after this iteration started.
                  if( !loopState.ShouldExitCurrentIteration ) {
                      Console.WriteLine( "{0} Starting work...", i );
                      // Simulate some long amount of work.
                      Thread.Sleep( 3000 );
                      Console.WriteLine( "{0} Ending work...", i );
                  }
            } );
    }

    static void Main() {
        Console.WriteLine( "Working..." );
        Console.WriteLine( "Press <enter> to terminate..." );
        Console.WriteLine( "*****************************\n\n" );

        var task = Task.Factory.StartNew( () => EntryPoint.DoWork() );

        Console.ReadLine();
        shouldStop = true;

        task.Wait();
        Console.WriteLine( "Done!" );
    }
}
