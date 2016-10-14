using System;

public class Bind2nd<Arg1Type, Arg2Type, ReturnType>
{
    public Bind2nd( Func<Arg1Type, Arg2Type, ReturnType> del,
                    Arg2Type arg2 ) {
        this.del = del;
        this.arg2 = arg2;
    }

    public Func<Arg1Type, ReturnType> Binder {
        get {
            return delegate( Arg1Type arg1 ) {
                return del( arg1, arg2 );
            };
        }
    }

    private Func<Arg1Type, Arg2Type, ReturnType> del;
    private Arg2Type arg2;
}

public class EntryPoint
{
    static int Add( int x, int y ) {
        return x + y;
    }

    static void Main() {
        Bind2nd<int,int,int> binder = new Bind2nd<int,int,int>(
                EntryPoint.Add,
                4 );

        Console.WriteLine( binder.Binder(2) );
    }
}
