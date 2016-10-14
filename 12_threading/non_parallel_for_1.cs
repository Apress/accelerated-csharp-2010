using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

class EntryPoint
{
    const int FactorialsToCompute = 2000;

    static void Main() {
        var numbers = new ConcurrentDictionary<BigInteger, BigInteger>(4, FactorialsToCompute);

        // Create a factorial delegate.
        Func<BigInteger, BigInteger> factorial = null;
        factorial = (n) => ( n == 0 ) ? 1 : n * factorial(n-1);

        // Now compute the factorial of the list
        for( ulong i = 0; i < FactorialsToCompute; ++i ) {
            numbers[i] = factorial(i);
        }
    }
}
