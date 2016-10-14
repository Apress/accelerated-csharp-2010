using System;

public static class StaticClass
{
    public static void DoWork() {
        ++callCount;
        Console.WriteLine( "StaticClass.DoWork()" );
    }

    public class NestedClass {
        public NestedClass() {
            Console.WriteLine( "NestedClass.NestedClass()" );
        }
    }

    private static long callCount = 0;
    public static long CallCount {
        get {
            return callCount;
        }
    }
}

public static class EntryPoint
{
    static void Main() {
        StaticClass.DoWork();

        // OOPS! Cannot do this!
        // StaticClass obj = new StaticClass();

        StaticClass.NestedClass nested =
            new StaticClass.NestedClass();

        Console.WriteLine( "CallCount = {0}",
                           StaticClass.CallCount );
    }
}
