using System;
using System.IO;
using System.Threading;

public class EntryPoint
{
    static private Random rnd = new Random();
    private static SpinLock logLock = new SpinLock( false );
    private static StreamWriter fsLog =
        new StreamWriter( File.Open("log.txt",
                                    FileMode.Append,
                                    FileAccess.Write,
                                    FileShare.None) );

    private static void RndThreadFunc() {
        bool lockTaken = false;
        logLock.Enter( ref lockTaken );
        if( lockTaken ) {
            try {
                fsLog.WriteLine( "Thread Starting" );
                fsLog.Flush();
            }
            finally {
                logLock.Exit();
            }
        }

        int time = rnd.Next( 10, 200 );
        Thread.Sleep( time );

        lockTaken = false;
        logLock.Enter( ref lockTaken );
        if( lockTaken ) {
            try {
                fsLog.WriteLine( "Thread Exiting" );
                fsLog.Flush();
            }
            finally {
                logLock.Exit();
            }
        }
    }

    static void Main() {
        // Start the threads that wait random time.
        Thread[] rndthreads = new Thread[ 50 ];
        for( uint i = 0; i < 50; ++i ) {
            rndthreads[i] =
                new Thread( new ThreadStart(
                                  EntryPoint.RndThreadFunc) );
            rndthreads[i].Start();
        }
    }
}
