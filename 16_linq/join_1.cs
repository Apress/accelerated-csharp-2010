using System;
using System.Linq;
using System.Collections.Generic;

public class EmployeeId
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class EmployeeNationality
{
    public string Id { get; set; }
    public string Nationality { get; set; }
}

public class JoinExample
{
    static void Main() {
        // Build employee collection
        var employees = new List<EmployeeId>() {
            new EmployeeId{ Id = "111-11-1111",
                            Name = "Ed Glasser" },
            new EmployeeId{ Id = "222-22-2222",
                            Name = "Spaulding Smails" },
            new EmployeeId{ Id = "333-33-3333",
                            Name = "Ivan Ivanov" },
            new EmployeeId{ Id = "444-44-4444",
                            Name = "Vasya Pupkin" }
        };

        // Build nationality collection.
        var empNationalities = new List<EmployeeNationality>() {
            new EmployeeNationality{ Id = "111-11-1111",
                                     Nationality = "American" },
            new EmployeeNationality{ Id = "333-33-3333",
                                     Nationality = "Russian" },
            new EmployeeNationality{ Id = "222-22-2222",
                                     Nationality = "Irish" },
            new EmployeeNationality{ Id = "444-44-4444",
                                     Nationality = "Russian" }
        };

        // Build query.
        var query = from emp in employees
                    join n in empNationalities
                        on emp.Id equals n.Id
                    orderby n.Nationality descending
                    select new {
                        Id = emp.Id,
                        Name = emp.Name,
                        Nationality = n.Nationality
                    };

        foreach( var person in query ) {
            Console.WriteLine( "{0}, {1}, \t{2}",
                               person.Id,
                               person.Name,
                               person.Nationality );
        }
    }
}
