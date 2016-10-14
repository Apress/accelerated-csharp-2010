using System;

public class Employee
{
    public Employee( string firstName,
                     string lastName ) {
        this.firstName = firstName;
        this.lastName = lastName;

        this.terminationDate = null;
        this.ssn = default(Nullable<long>);
    }

    public string firstName;
    public string lastName;

    public Nullable<DateTime> terminationDate;
    public long? ssn;   // Shorthand notation
}

public class EntryPoint
{
    static void Main() {
        Employee emp = new Employee( "Vasya",
                                     "Pupkin" );
        emp.ssn = 1234567890;

        Console.WriteLine( "{0} {1}",
                           emp.firstName,
                           emp.lastName );
        if( emp.terminationDate.HasValue ) {
            Console.WriteLine( "Start Date: {0}",
                               emp.terminationDate );
        }

        long tempSSN = emp.ssn ?? -1;
        Console.WriteLine( "SSN: {0}",
                           tempSSN );
    }
}
