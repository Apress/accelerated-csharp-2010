using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

class EntryPoint
{
    const int FactorialsToCompute = 100;

    static void Main() {
        var numbers = new ConcurrentDictionary<BigInteger, BigInteger>();

        // Create a factorial delegate.
        Func<BigInteger, BigInteger> factorial = null;
        factorial = (n) => ( n == 0 ) ? 1 : n * factorial(n-1);

        // Build the array of actions
        var actions = new Action[FactorialsToCompute];
        for( int i = 0; i < FactorialsToCompute; ++i ) {
            int x = i;
            actions[i] = () => {
                numbers[x] = factorial(x);
            };
        }

        // Now compute the values.
        Parallel.Invoke( actions );

        // Print out the results.
        for( int i = 0; i < FactorialsToCompute; ++i ) {
            Console.WriteLine( numbers[i] );
        }
    }
}
