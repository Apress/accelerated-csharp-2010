using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;

static class EntryPoint
{
    static void Main() {
        dynamic dynamicExpression = new ExpandoObject();

        // Add the coefficients
        dynamicExpression.Coefficients = new List<dynamic>();
        dynamicExpression.Coefficients.Add( 2 );
        dynamicExpression.Coefficients.Add( 5 );
        dynamicExpression.Coefficients.Add( 3 );

        // Create dynamic method
        dynamicExpression.Compute =
            new Func<double, double>( (x) => {
                double result = 0;

                for( int i = 0;
                     i < dynamicExpression.Coefficients.Count;
                     ++i ) {
                    result +=
                        (double)dynamicExpression.Coefficients[i] *
                        Math.Pow( x, (double) i );
                }

                return result;
            } );
        
        // Let's compute a value now
        Console.WriteLine( dynamicExpression.Compute(2) );
    }
}
