using System;
using System.IO;
using System.Threading;

public class MySpinLock
{
    public MySpinLock( int spinWait ) {
        this.spinWait = spinWait;
    }

    public void Enter() {
        while( Interlocked.CompareExchange(ref theLock,
                                           1,
                                           0) == 1 ) {
            // The lock is taken, spin.
            Thread.Sleep( spinWait );
        }
    }

    public void Exit() {
        // Reset the lock.
        Interlocked.Exchange( ref theLock,
                              0 );
    }

    private volatile int theLock = 0;
    private int          spinWait;
}

public class MySpinLockManager : IDisposable
{
    public MySpinLockManager( MySpinLock spinLock ) {
        this.spinLock = spinLock;
        spinLock.Enter();
    }

    public void Dispose() {
        spinLock.Exit();
    }

    private MySpinLock spinLock;
}

public class EntryPoint
{
    static private Random rnd = new Random();
    private static MySpinLock logLock = new MySpinLock( 10 );
    private static StreamWriter fsLog =
        new StreamWriter( File.Open("log.txt",
                                    FileMode.Append,
                                    FileAccess.Write,
                                    FileShare.None) );

    private static void RndThreadFunc() {
        using( new MySpinLockManager(logLock) ) {
            fsLog.WriteLine( "Thread Starting" );
            fsLog.Flush();
        }

        int time = rnd.Next( 10, 200 );
        Thread.Sleep( time );

        using( new MySpinLockManager(logLock) ) {
            fsLog.WriteLine( "Thread Exiting" );
            fsLog.Flush();
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
