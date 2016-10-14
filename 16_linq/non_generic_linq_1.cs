using System;
using System.Linq;
using System.Collections;

public class NonGenericLinq
{
    static void Main() {
        ArrayList numbers = new ArrayList();
        numbers.Add( 1 );
        numbers.Add( 2 );

        var query = from int n in numbers
                    select n * 2;

        foreach( var item in query ) {
            Console.WriteLine( item );
        }
    }
}
