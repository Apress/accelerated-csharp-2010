// This will not compile!!!
class C<T>
{
    static public void DoWork( T item ) {
        item.DoWork();
    }
}
