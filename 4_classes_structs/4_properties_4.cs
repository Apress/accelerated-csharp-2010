using System;

public class Employee
{
    public Employee( string fullName, string id ) {
        FullName = fullName;
        Id = id;
    }

    public string FullName { get; private set; }
    public string Id { get; set; }
}

public class AutoProps
{
    static void Main() {
        Employee emp = new Employee(
            "John Doe",
            "111-11-1111" );
    }
}
