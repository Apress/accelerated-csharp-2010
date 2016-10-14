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
        Func<IList<T>> tailGenerator = null;
        tailGenerator = () => {
            if( !iter.MoveNext() ) {
                return new MyList<T>( default(T), null );
            }

            return new MyList<T>( iter.Current, tailGenerator );
        };

        return tailGenerator();
    }

    public MyList( T head, Func<IList<T>> tailGenerator ) {
        this.head = head;
        this.tailGenerator = tailGenerator;
    }

    public T Head {
        get {
            return head;
        }
    }

    public IList<T> Tail {
        get {
            if( tailGenerator == null ) {
                return null;
            } else if( tail == null ) {
                tail = tailGenerator();
            }
            return tail;
        }
    }

    private T              head;
    private Func<IList<T>> tailGenerator;
    private IList<T>       tail = null;
}

public static class MyListExtensions
{
    public static IEnumerable<T>
        GeneralIterator<T>( this IList<T> theList,
                            Func<IList<T>,bool> finalState,
                            Func<IList<T>,IList<T>> incrementer ) {
        while( !finalState(theList) ) {
            yield return theList.Head;
            theList = incrementer( theList );
        }
    }

    public static IList<T> Where<T>( this IList<T> theList,
                                     Func<T, bool> predicate ) {
        Func<IList<T>> whereTailFunc = null;

        whereTailFunc = () => {
            IList<T> result = null;

            if( theList.Tail == null ) {
                result = new MyList<T>( default(T), null );
            }

            if( predicate(theList.Head) ) {
                result = new MyList<T>( theList.Head,
                                        whereTailFunc );
            } 
            
            theList = theList.Tail;
            if( result == null ) {
                result = whereTailFunc();
            }

            return result;
        };

        return whereTailFunc();
    }

    public static IList<R> Select<T,R>( this IList<T> theList,
                                        Func<T,R> selector ) {
        Func<IList<R>> selectorTailFunc = null;

        selectorTailFunc = () => {
            IList<R> result = null;

            if( theList.Tail == null ) {
                result = new MyList<R>( default(R), null );
            } else {
                result = new MyList<R>( selector(theList.Head),
                                        selectorTailFunc );
            }
            
            theList = theList.Tail;
            return result;
        };

        return selectorTailFunc();
    }

    public static IList<T> Take<T>( this IList<T> theList,
                                    int count ) {
        Func<IList<T>> takeTailFunc = null;

        takeTailFunc = () => {
            IList<T> result = null;

            if( theList.Tail == null || count-- == 0 ) {
                result = new MyList<T>( default(T), null );
            } else {
                result = new MyList<T>( theList.Head,
                                        takeTailFunc );
            }
            
            theList = theList.Tail;
            return result;
        };

        return takeTailFunc();
    }
}

public class SqoExample
{
    static IList<T> CreateInfiniteList<T>( T item ) {
        Func<IList<T>> tailGenerator = null;

        tailGenerator = () => {
            return new MyList<T>( item, tailGenerator );
        };

        return tailGenerator();
    }

    static void Main() {
        var infiniteList = CreateInfiniteList<int>( 21 );

        var linkList = infiniteList.Where( x => x > 3 )
                                   .Select( x => x * 2 )
                                   .Take( 10 );
        var iterator = linkList.GeneralIterator(
                                    list => list.Tail == null,
                                    list => list.Tail );
        foreach( var item in iterator ) {
            Console.Write( "{0}, ", item );
        }

        Console.WriteLine();
    }
}
