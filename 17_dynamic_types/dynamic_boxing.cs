using System;

static class EntryPoint
{
    static void Main() {
        dynamic d = 42;
        ++d;

        object o = 42;
        o = (int)o + 1;

        Console.WriteLine( "d = " + d + "\no = " + o );
    }
}
