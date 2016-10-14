using System;

public class EntryPoint
{
    static void Main() {
        int[] array1 = new int[ 10 ];
        for( int i = 0; i < array1.Length; ++i ) {
            array1[i] = i*2;
        }

        int[] array2 = new int[] { 2, 4, 6, 8 };

        int[] array3 = { 1, 3, 5, 7 };
    }
}
