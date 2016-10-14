interface IWork<T>
{
    void DoWork( T item );
}

class C : IWork<object>
{
    public void DoWork( object item ) {
        dynamic d = item;

        // Now complete the work with the
        // dynamic thing.
    }
}

static class EntryPoint
{
    static void Main() {
        C c = new C();
        dynamic d = new object();

        c.DoWork( d );
    }
}
