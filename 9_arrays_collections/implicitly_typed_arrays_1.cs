using System;

public class EntryPoint
{
    static void Main() {
        // A conventional array
        int[] conventionalArray = new int[] { 1, 2, 3 };

        // An implicitly typed array
        var implicitlyTypedArray = new [] { 4, 5, 6 };
        Console.WriteLine( implicitlyTypedArray.GetType() );

        // An array of doubles
        var someNumbers = new [] { 3.1415, 1, 6 };
        Console.WriteLine( someNumbers.GetType() );

        // Won't compile!
        // var someStrings = new [] { "int",
        //                            someNumbers.GetType() };
    }
}
