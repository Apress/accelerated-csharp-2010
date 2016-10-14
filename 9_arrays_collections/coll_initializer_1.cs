using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
}

public class CollInitializerExample
{
    static void Main() {
        var developmentTeam = new List<Employee> {
            new Employee { Name = "Michael Bolton" },
            new Employee { Name = "Samir Nagheenanajar" },
            new Employee { Name = "Peter Gibbons" }
        };

        Console.WriteLine( "Development Team:" );
        foreach( var employee in developmentTeam ) {
            Console.WriteLine( "\t" + employee.Name );
        }
    }
}
