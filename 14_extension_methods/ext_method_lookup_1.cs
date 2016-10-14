using System;

public static class ExtensionMethods
{
    static public void WriteLine( this String str ) {
        Console.WriteLine( "Global Namespace: " + str );
    }
}

namespace A
{
    public static class ExtensionMethods
    {
        static public void WriteLine( this String str ) {
            Console.WriteLine( "Namespace A: " + str );
        }
    }
}

namespace B
{
    public static class ExtensionMethods
    {
        static public void WriteLine( this String str ) {
            Console.WriteLine( "Namespace B: " + str );
        }
    }
}

namespace C
{
    using A;

    public class Employee
    {
        public Employee( String name ) {
            this.name = name;
        }

        public void PrintName() {
            name.WriteLine();
        }

        private String name;
    }
}

namespace D
{
    using B;

    public class Dog
    {
        public Dog( String name ) {
            this.name = name;
        }

        public void PrintName() {
            name.WriteLine();
        }

        private String name;
    }
}

namespace E
{
    public class Cat
    {
        public Cat( String name ) {
            this.name = name;
        }

        public void PrintName() {
            name.WriteLine();
        }

        private String name;
    }
}

namespace Demo
{
    using A;
    using B;

    public class EntryPoint
    {
        static void Main() {
            C.Employee fred = new C.Employee( "Fred" );
            D.Dog thor = new D.Dog( "Thor" );
            E.Cat sylvester = new E.Cat( "Sylvester" );

            fred.PrintName();
            thor.PrintName();
            sylvester.PrintName();

            // String str = "Etouffe";
            // str.WriteLine();
        }
    }
}
