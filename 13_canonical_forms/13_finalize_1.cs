using System;
using System.Runtime.InteropServices;

public class Win32Heap : IDisposable
{
    [DllImport("kernel32.dll")]
    static extern IntPtr HeapCreate(uint flOptions, UIntPtr dwInitialSize,
                                    UIntPtr dwMaximumSize);

    [DllImport("kernel32.dll")]
    static extern bool HeapDestroy(IntPtr hHeap);

    public Win32Heap() {
        theHeap = HeapCreate( 0, (UIntPtr) 4096, UIntPtr.Zero );
    }

    // IDisposable implementation
    protected virtual void Dispose( bool disposing ) {
        if( !disposed ) {
            if( disposing ) {
                // It's ok to use any internal objects here.  This class happens
                // to not have any though.
            }

            // If using objects that you know do still exist, such as objects
            // that implement the singleton pattern, it is important to make
            // sure those objects are thread safe.

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
}
