using System;

public class A
{
    public virtual void SomeMethod() {
        Console.WriteLine( "A::SomeMethod" );
    }
}

public class B : A
{
    public override void SomeMethod() {
        Console.WriteLine( "B::SomeMethod" );
        base.SomeMethod();
    }
}


public class EntryPoint
{
    static void Main() {
        B b = new B();
        A a = b;

        a.SomeMethod();
    }
}
