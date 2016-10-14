class C
{
}

static class EntryPoint
{
    static void Main() {
        dynamic d1 = 42;            // Impl. boxing conversion
        dynamic d2 = new C();       // Impl. ref. conversion
        dynamic d3 = d2;            // Impl. ident. conversion
        dynamic d4 = new object();  // Impl. ref. conversion
    }
}
