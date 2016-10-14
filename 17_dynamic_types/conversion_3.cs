class C
{
    static public void Foo( int i ) {}
    static public void Foo( string str ) {}
}

class D { }

static class EntryPoint
{
    static void Main() {
        dynamic d = new D();

        C.Foo( d );
    }
}
