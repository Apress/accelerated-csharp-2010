using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Microsoft.Win32.SafeHandles;

public class NamedEventCreator
{
    [DllImport( "KERNEL32.DLL", EntryPoint="CreateEventW",
                SetLastError=true )]
    private static extern SafeWaitHandle CreateEvent(
                                   IntPtr lpEventAttributes,
                                   bool   bManualReset,
                                   bool   bInitialState,
                                   string lpName );

    public static AutoResetEvent CreateAutoResetEvent(
                                         bool initialState,
                                         string name ) {
        // Create named event.
        SafeWaitHandle rawEvent = CreateEvent( IntPtr.Zero,
                                       false,
                                       initialState,
                                       name );
        if( rawEvent.IsInvalid ) {
            throw new Win32Exception(
                            Marshal.GetLastWin32Error() );
        }

        // Create a managed event type based on this handle.
        AutoResetEvent autoEvent = new AutoResetEvent( false );

        // Must clean up handle currently in autoEvent
        // before swapping it with the named one.
        autoEvent.SafeWaitHandle = rawEvent;

        return autoEvent;
    }
}

