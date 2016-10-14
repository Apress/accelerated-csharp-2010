//This will not compile!!!
using System;

class SpecialAttribute : Attribute
{
}

interface IWork<T>
{
    void DoWork( T item );
}

class C : IWork< [Special] object >
{
    public void DoWork( [Special] object item ) {
    }
}
