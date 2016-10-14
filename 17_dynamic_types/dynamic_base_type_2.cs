using System;

class B<T>
{
    public T Value { get; set; }
}

class C : B<dynamic>
{
}

static class EntryPoint
{
    static void Main() {
        C c = new C();

        c.Value = "C# Rocks!";
        Console.WriteLine( 42 + c.Value );
    }
}
