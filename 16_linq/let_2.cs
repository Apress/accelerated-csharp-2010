using System;
using System.Linq;

public class MultTable
{
    static void Main() {
        var query = from x in Enumerable.Range(0,10)
                    let innerRange = Enumerable.Range(0, 10)
                        from y in innerRange
                        select new {
                            X = x,
                            Y = y,
                            Product = x * y
                        };

        foreach( var item in query ) {
            Console.WriteLine( "{0} * {1} = {2}",
                               item.X,
                               item.Y,
                               item.Product );
        }
    }
}
