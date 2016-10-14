using System;
using System.Collections.Generic;

interface IMyCollection<T>
{
    void AddItem( T item );
}

interface IMyEnumerator<out T>
{
    T GetItem( int index );
}

class MyCollection<T> : IMyCollection<T>,
                        IMyEnumerator<T>
{
    public void AddItem( T item ) {
        collection.Add( item );
    }

    public T GetItem( int index ) {
        return collection[index];
    }

    private List<T> collection = new List<T>();
}

static class EntryPoint
{
    static void Main() {
        var strings = new MyCollection<string>();
        strings.AddItem( "One" );
        strings.AddItem( "Two" );

        IMyEnumerator<string> collStrings = strings;

        // Covariance in action!
        IMyEnumerator<object> collObjects = collStrings;

        PrintCollection( collObjects, 2 );
    }

    static void PrintCollection( IMyEnumerator<object> coll,
                                 int count ) {
        for( int i = 0; i < count; ++i ) {
            Console.WriteLine( coll.GetItem(i) );
        }
    }
}

