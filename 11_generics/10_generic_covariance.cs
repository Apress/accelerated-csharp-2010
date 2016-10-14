using System;
using System.Collections.Generic;

interface IMyCollection<T>
{
    void AddItem( T item );
    T GetItem( int index );
}

class MyCollection<T> : IMyCollection<T>
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

        IMyCollection<string> collStrings = strings;
        PrintCollection( collStrings, 2 );
    }

    static void PrintCollection( IMyCollection<string> coll,
                                 int count ) {
        for( int i = 0; i < count; ++i ) {
            Console.WriteLine( coll.GetItem(i) );
        }
    }
}

