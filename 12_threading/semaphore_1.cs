using System;
using System.Threading;
using System.Collections;

public class CrudeThreadPool
{
    static readonly int MaxWorkThreads = 4;
    static readonly int WaitTimeout = 2000;

    public delegate void WorkDelegate();

    public CrudeThreadPool() {
        stop = false;
        semaphore = new Semaphore( 0, int.MaxValue );
        workQueue = new Queue();
        threads = new Thread[ MaxWorkThreads ];

        for( int i = 0; i < MaxWorkThreads; ++i ) {
            threads[i] =
                new Thread( new ThreadStart(this.ThreadFunc) );
            threads[i].Start();
        }
    }

    private void ThreadFunc() {
        do {
            if( !stop ) {
                WorkDelegate workItem = null;
                if( semaphore.WaitOne(WaitTimeout) ) {
                    // Process the item on the front of the
                    // queue
                    lock( workQueue ) {
                        workItem =
                            (WorkDelegate) workQueue.Dequeue();
                    }
                    workItem();
                }
            }
        } while( !stop );
    }

    public void SubmitWorkItem( WorkDelegate item ) {
        lock( workQueue ) {
            workQueue.Enqueue( item );
        }

        semaphore.Release();
    }

    public void Shutdown() {
        stop = true;
    }

    private Semaphore     semaphore;
    private Queue         workQueue;
    private Thread[]      threads;
    private volatile bool stop;
}

public class EntryPoint
{
    static void WorkFunction() {
        Console.WriteLine( "WorkFunction() called on Thread {0}",
                           Thread.CurrentThread.ManagedThreadId );
    }

    static void Main() {
        CrudeThreadPool pool = new CrudeThreadPool();
        for( int i = 0; i < 10; ++i ) {
            pool.SubmitWorkItem(
              new CrudeThreadPool.WorkDelegate(
                                     EntryPoint.WorkFunction) );
        }

        // Sleep to simulate this thread doing other work.
        Thread.Sleep( 1000 );

        pool.Shutdown();
    }
}
