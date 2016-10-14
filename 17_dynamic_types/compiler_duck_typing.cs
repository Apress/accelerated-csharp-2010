using System;
using System.Collections;

class C
{
    public IEnumerator GetEnumerator() {
        long l = 0;
        while( l < 10 ) {
            yield return ++l;
        }
    }
}

static class EntryPoint
{
    static void Main() {
        C c = new C();

        foreach( var item in c ) {
            Console.Write( item + ", " );
        }
    }
}
