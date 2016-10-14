using System;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Permissions;
using System.Text;
using Microsoft.Win32.SafeHandles;


//
// Matches Win32 BLUETOOTH_FIND_RADIO_PARAMS
//
[StructLayout( LayoutKind.Sequential )]
class BluetoothFindRadioParams
{
    public BluetoothFindRadioParams() {
        dwSize = 4;
    }
    public UInt32 dwSize;
}

//
// Matches Win32 BLUETOOTH_RADIO_INFO
//
[StructLayout( LayoutKind.Sequential,
               CharSet = CharSet.Unicode )]
struct BluetoothRadioInfo
{
    public const int BLUETOOTH_MAX_NAME_SIZE = 248;

    public UInt32 dwSize;
    public UInt64 address;
    [MarshalAs( UnmanagedType.ByValTStr,
                SizeConst = BLUETOOTH_MAX_NAME_SIZE )]
    public string szName;
    public UInt32 ulClassOfDevice;
    public UInt16 lmpSubversion;
    public UInt16 manufacturer;
}

//
// Safe Bluetooth Enumeration Handle
//
[SecurityPermission( SecurityAction.Demand,
                     UnmanagedCode = true )]
sealed public class SafeBluetoothRadioFindHandle
    : SafeHandleZeroOrMinusOneIsInvalid
{
    private SafeBluetoothRadioFindHandle() : base( true ) { }

    override protected bool ReleaseHandle() {
        return BluetoothFindRadioClose( handle );
    }

    [DllImport( "Irprops.cpl" )]
    [ReliabilityContract( Consistency.WillNotCorruptState,
                          Cer.Success )]
    [SuppressUnmanagedCodeSecurity]
    private static extern bool BluetoothFindRadioClose(
                                              IntPtr hFind );
}

public class EntryPoint
{
    private const int ERROR_SUCCESS = 0;

    static void Main() {
        SafeFileHandle radioHandle;
        using( SafeBluetoothRadioFindHandle radioFindHandle
            = BluetoothFindFirstRadio(new BluetoothFindRadioParams(),
                                      out radioHandle) ) {
            if( !radioFindHandle.IsInvalid ) {
                BluetoothRadioInfo radioInfo = new BluetoothRadioInfo();
                radioInfo.dwSize = 520;
                UInt32 result = BluetoothGetRadioInfo( radioHandle,
                                                       ref radioInfo );

                if( result == ERROR_SUCCESS ) {
                    // Let's send the contents of the radio info to the
                    // console.
                    Console.WriteLine( "address = {0:X}",
                                       radioInfo.address );
                    Console.WriteLine( "szName = {0}",
                                       radioInfo.szName );
                    Console.WriteLine( "ulClassOfDevice = {0}",
                                       radioInfo.ulClassOfDevice );
                    Console.WriteLine( "lmpSubversion = {0}",
                                       radioInfo.lmpSubversion );
                    Console.WriteLine( "manufacturer = {0}",
                                       radioInfo.manufacturer );
                }

                radioHandle.Dispose();
            }
        }
    }

    [DllImport( "Irprops.cpl" )]
    private static extern SafeBluetoothRadioFindHandle
        BluetoothFindFirstRadio( [MarshalAs(UnmanagedType.LPStruct)]
                                 BluetoothFindRadioParams pbtfrp,
                                 out SafeFileHandle phRadio );

    [DllImport( "Irprops.cpl" )]
    private static extern UInt32
        BluetoothGetRadioInfo( SafeFileHandle hRadio,
                               ref BluetoothRadioInfo pRadioInfo );
}
