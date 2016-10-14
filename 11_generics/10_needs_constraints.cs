using System;

public class ContainedClass
{
    public long GetSomeValue() {
        return 42;
    }
}

public class MyClass<T>
{
    public void DoSomething() {
        Console.WriteLine( field1.GetHashCode() );
        Console.WriteLine( field1.GetSomeValue() );
    }

    private T field1;
}

public class EntryPoint
{
    static void Main() {
        MyClass<int> obj1 = new MyClass<int>();
        MyClass<ContainedClass> obj2 = new MyClass<ContainedClass>();
    }
}
