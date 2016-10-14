using System;
using System.Runtime.InteropServices;

class C
{
    public void DoWork() {
        Console.Write( "Doing work...  " );
    }
}

static class EntryPoint
{
    [DllImport("kernel32.dll")]
    private static extern int QueryPerformanceCounter( out Int64 count );

    static void Main() {
        // Let's call DoWork once statically to get it jitted.
        C c = new C();
        c.DoWork();
        Console.WriteLine();

        dynamic d = c;

        for( int i = 0; i < 10; ++i ) {
            Int64 start, end;

            QueryPerformanceCounter( out start );
            d.DoWork();
            QueryPerformanceCounter( out end );
            Console.WriteLine( "Ticks: {0}",
                               end - start );
        }
    }
}
