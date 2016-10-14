using System;
using System.Linq;
using System.Linq.Expressions;

public class EntryPoint
{
    static void Main() {
        Expression<Func<int,int>> expr = n => n+1;

        // Now, reassign the expr by multiplying the original
        // expression by 2.
        expr = Expression<Func<int,int>>.Lambda<Func<int,int>>(
                  Expression.Multiply( expr.Body,
                                       Expression.Constant(2) ),
                  expr.Parameters );

        Func<int, int> func = expr.Compile();

        for( int i = 0; i < 10; ++i ) {
            Console.WriteLine( func(i) );
        }

    }
}
