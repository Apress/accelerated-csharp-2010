using System;
using System.Linq;
using System.Collections.Generic;

public interface IList<T>
{
    T Head { get; }
    IList<T> Tail { get; }
}

public class MyList<T> : IList<T>
{
    public static IList<T> CreateList( IEnumerable<T> items ) {
        IEnumerator<T> iter = items.GetEnumerator();
        return CreateList( iter );
    }

    public static IList<T> CreateList( IEnumerator<T> iter ) {
        if( !iter.MoveNext() ) {
            return new MyList<T>( default(T), null );
        }

        return new MyList<T>( iter.Current, CreateList(iter) );
    }

    public MyList( T head, IList<T> tail ) {
        this.head = head;
        this.tail = tail;
    }

    public T Head {
        get {
            return head;
        }
    }

    public IList<T> Tail {
        get {
            return tail;
        }
    }

    private T        head;
    private IList<T> tail;
}

public static class MyListExtensions
{
    public static IEnumerable<T>
        GeneralIterator<T>( this IList<T> theList,
                            Func<IList<T>, bool> finalState,
                            Func<IList<T>, IList<T>> incrementer ) {
        while( !finalState(theList) ) {
            yield return theList.Head;
            theList = incrementer( theList );
        }
    }

    public static IList<T> Where<T>( this IList<T> theList,
                                     Func<T, bool> predicate ) {
        Func<IList<T>, IList<T>> whereFunc = null;

        whereFunc = list => {
            IList<T> result = new MyList<T>(default(T), null);

            if( list.Tail != null ) {
                if( predicate(list.Head) ) {
                    result = new MyList<T>( list.Head, whereFunc(list.Tail) );
                } else {
                    result = whereFunc( list.Tail );
                }
            } 

            return result;
        };

        return whereFunc( theList );
    }

    public static IList<R> Select<T,R>( this IList<T> theList,
                                        Func<T,R> selector ) {
        Func<IList<T>, IList<R>> selectorFunc = null;

        selectorFunc = list => {
            IList<R> result = new MyList<R>(default(R), null);

            if( list.Tail != null ) {
                result = new MyList<R>( selector(list.Head), selectorFunc(list.Tail) );
            } 

            return result;
        };

        return selectorFunc( theList );
    }
}

public class SqoExample
{
    static void Main() {
        var listInts = new List<int> { 5, 2, 9, 4, 3, 1 };
        var linkList =
            MyList<int>.CreateList( listInts );

        // Now sort.
        var linkList2 = linkList.Where( x => x > 3 ).Select( x => x * 2 );
        var iterator2 = linkList2.GeneralIterator( list => list.Tail == null,
                                              list => list.Tail );
        foreach( var item in iterator2 ) {
            Console.Write( "{0}, ", item );
        }

        Console.WriteLine();
    }
}
