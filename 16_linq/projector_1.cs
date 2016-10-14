using System;
using System.Linq;

public class Result
{
    public Result( int input, int output ) {
        Input = input;
        Output = output;
    }
    public int Input { get; set; }
    public int Output { get; set; }
}

public class Projector
{
    static void Main() {
        int[] numbers = { 1, 2, 3, 4 };

        var query = from x in numbers
                    select new Result( x, x*2 );

        foreach( var item in query ) {
            Console.WriteLine( "Input = {0}, Output = {1}",
                               item.Input,
                               item.Output );
        }
    }
}
