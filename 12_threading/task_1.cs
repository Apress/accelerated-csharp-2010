using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

public class EntryPoint {
    private const int ConnectQueueLength = 4;
    private const int ListenPort = 1234;

    static void Main() {
        var doneEvent = new ManualResetEventSlim();

        // Create task to listen on a socket.
        Socket listenSock = new Socket( AddressFamily.InterNetwork,
                                        SocketType.Stream,
                                        ProtocolType.Tcp );
        Socket connection = null;

        try {
            Task listenTask = null;
            listenTask = Task.Factory.StartNew( () => {
                listenSock.Bind( new IPEndPoint(IPAddress.Any,
                                                ListenPort) );
                listenSock.Listen( ConnectQueueLength );
                connection = listenSock.Accept();

                listenTask.ContinueWith( (previousTask) => {
                    byte[] msg = Encoding.UTF8.GetBytes( "Hello World!" );
                    connection.Send( msg, SocketFlags.None );
                    connection.Close();
                    doneEvent.Set();
                } );
            } );

            Console.WriteLine( "Waiting for task to complete..." );
            doneEvent.Wait();
        }
        catch( AggregateException e ) {
            Console.WriteLine( e );
        }

        listenSock.Close();
    }
}
