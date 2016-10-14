using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

public sealed class Win32Heap : IDisposable
{
    [DllImport("kernel32.dll")]
    static extern IntPtr HeapCreate(uint flOptions,
                                    UIntPtr dwInitialSize,
                                    UIntPtr dwMaximumSize);

    [DllImport("kernel32.dll")]
    static extern bool HeapDestroy(IntPtr hHeap);

    public Win32Heap() {
        creationStackTrace = new StackTrace(1, true);
        
        theHeap = HeapCreate( 0, (UIntPtr) 4096, UIntPtr.Zero );
    }

    // IDisposable implementation
    private void Dispose( bool disposing ) {
      if( !disposed ) {
         if( disposing ) {
            // It's ok to use any internal objects here.  This
            // class happens to not have any though.
         } else {
            // OOPS!  We're finalizing this object and it has not
            // been disposed.  Let's let the user know about it if
            // the app domain is not shutting down.
            AppDomain currentDomain = AppDomain.CurrentDomain;
            if( !currentDomain.IsFinalizingForUnload() &&
               !Environment.HasShutdownStarted ) {
               Console.WriteLine(
                            "Failed to dispose of object!!!" );
               Console.WriteLine( "Object allocated at:" );
               for( int i = 0;
                    i < creationStackTrace.FrameCount;
                    ++i ) {
                  StackFrame frame =
                      creationStackTrace.GetFrame(i);
                  Console.WriteLine( "   {0}",
                                     frame.ToString() );
               }
            }
         }

         // If using objects that you know do still exist, such
         // as objects that implement the singleton pattern, it
         // is important to make sure those objects are thread
         // safe.

         HeapDestroy( theHeap );
         theHeap = IntPtr.Zero;
         disposed = true;
      }
    }

    public void Dispose() {
        Dispose( true );
        GC.SuppressFinalize( this );
    }

    ~Win32Heap() {
        Dispose( false );
    }

    private IntPtr theHeap;
    private bool disposed = false;
    private StackTrace creationStackTrace;
}

public sealed class EntryPoint
{
    static void Main()
    {
        Win32Heap heap = new Win32Heap();
        heap = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
