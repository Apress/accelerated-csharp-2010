// This will not compile!!!

interface IWork<T>
{
    void DoWork( T item );
}

class C : IWork<dynamic>
{
    public void DoWork( dynamic item ) {
    }
}
