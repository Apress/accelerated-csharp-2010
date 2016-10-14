using System;
using System.Collections.Generic;

class A { }
class B : A { }

interface IMyCollection<T>
{
    void AddItem( T item );
}

interface IMyTrimmableCollection<in T>
{
    void RemoveItem( T item );
}

class MyCollection<T> : IMyCollection<T>,
                        IMyTrimmableCollection<T>
{
    public void AddItem( T item ) {
        collection.Add( item );
    }

    public void RemoveItem( T item ) {
        collection.Remove( item );
    }

    private List<T> collection = new List<T>();
}

static class EntryPoint
{
    static void Main() {
        var items = new MyCollection<A>();
        items.AddItem( new A() );

        B b = new B();
        items.AddItem( b );

        IMyTrimmableCollection<A> collItems = items;

        // Contravariance in action!
        IMyTrimmableCollection<B> trimColl = collItems;
        trimColl.RemoveItem( b );
    }
}

