using System;
using System.Threading;
using System.Collections;

public class EntryPoint
{
    static void Main() {
        Queue queue1 = new Queue();
        Queue queue2 = new Queue();

        // ... operations to fill the queues with data.

        // Process each queue in a separate threda.
        Thread proc1 = new Thread( EntryPoint.ThreadFunc );
        proc1.Start( queue1 );

        Thread proc2 = new Thread( EntryPoint.ThreadFunc );
        proc2.Start( queue2 );

        // ... do some other work in the meantime.

        // Wait for the work to finish.
        proc1.Join();
        proc2.Join();
    }

    static private void ThreadFunc( object obj ) {
        // We must cast the incoming object into a Queue.
        Queue theQueue = (Queue) obj;

        // ... drain the queue
    }
}
