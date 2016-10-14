using System;
using System.IO;
using Microsoft.CSharp.RuntimeBinder;

class C
{
    public void DumpStateTo( TextWriter tw ) {
        tw.WriteLine( "This is the state for a " +
                      GetType() + " instance" );
        tw.WriteLine( "\tValue == " + Value );
    }

    public long Value { get; set; }
}

class D
{
}

static class EntryPoint
{
    static void Main() {
        C c = new C();
        c.Value = 42;

        D d = new D();

        // Now let's dump some debug info
        DumpDebugInfo( c );
        DumpDebugInfo( d );
    }

    static void DumpDebugInfo( dynamic d ) {
        // We don't want a lack of the DumpStateTo() method to
        // crash the application.
        try {
            Console.WriteLine( "--------------------------------" );
            d.DumpStateTo( Console.Out );
        }
        catch( RuntimeBinderException rbe ) {
            Console.WriteLine( "Failed to dump state for: " +
                               d.GetType() );
            Console.WriteLine( "\t" + rbe.Message );
        }
    }
}
