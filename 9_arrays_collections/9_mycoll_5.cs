using System;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

public class EnumWrapper<T> : IEnumerator<T>
{
    public EnumWrapper( IEnumerator<T> inner ) {
        this.inner = inner;
    }

    public void Dispose() { inner.Dispose(); }

    public bool MoveNext() { return inner.MoveNext(); }

    public void Reset() { inner.Reset(); }

    public T Current {
        get { return inner.Current; }
    }

    object IEnumerator.Current {
        get { return inner.Current; }
    }

    private IEnumerator<T> inner;
}

public class MyColl<T> : IEnumerable<T>
{
    public MyColl( T[] items ) {
        this.items = items;
    }

    public IEnumerator<T> GetEnumerator( bool synchronized ) {
        return( new EnumWrapper<T>(GetPrivateEnumerator(synchronized)) );
    }

    private IEnumerator<T> GetPrivateEnumerator( bool synchronized ) {
        if( synchronized ) {
            Monitor.Enter( items.SyncRoot );
        }
        try {
            foreach( T item in items ) {
                yield return item;
            }
        }
        finally {
            if( synchronized ) {
                Monitor.Exit( items.SyncRoot );
            }
        }
    }

    public IEnumerator<T> GetEnumerator() {
        return GetEnumerator( false );
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    private T[] items;
}

public class EntryPoint
{
    static void Main() {
        MyColl<int> integers =
            new MyColl<int>( new int[] {1, 2, 3, 4} );

        IEnumerator<int> enumerator =
            integers.GetEnumerator( true );

        // Try to get a reference to synchronized field.
        // 
        // Throws an exception!!!
        object field = enumerator.GetType().
            GetField("synchronized").GetValue( enumerator );
    }
}
