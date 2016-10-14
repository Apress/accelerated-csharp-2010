using System;
using System.Reflection;
using System.Collections.Generic;

delegate void ApplyRaiseDelegate<T>( T instance,
                                     Decimal percent );

public class Employee
{
    private Decimal salary;

    public Employee( Decimal salary ) {
        this.salary = salary;
    }

    public Decimal Salary {
        get {
            return salary;
        }
    }

    public void ApplyRaiseOf( Decimal percent ) {
        salary *= (1 + percent);
    }
}

public class EntryPoint
{
    static void Main() {
        List<Employee> employees = new List<Employee>();

        employees.Add( new Employee(40000) );
        employees.Add( new Employee(65000) );
        employees.Add( new Employee(95000) );

        // Create open instance delegate
        MethodInfo mi =
            typeof(Employee).GetMethod( "ApplyRaiseOf",
                                        BindingFlags.Public |
                                        BindingFlags.Instance );
        ApplyRaiseDelegate<Employee> applyRaise =
            (ApplyRaiseDelegate<Employee> )
            Delegate.CreateDelegate(
                         typeof(ApplyRaiseDelegate<Employee>),
                         mi );

        // Apply raise.
        foreach( Employee e in employees ) {
            applyRaise( e, (Decimal) 0.10 );

            // Send new salary to console.
            Console.WriteLine( e.Salary );
        }
    }
}
