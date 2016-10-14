using System;

public class Employee
{
    public string FullName { get; set; }
    public string Id { get; set; }
}

public class AutoProps
{
    static void Main() {
        Employee emp = new Employee();
    }
}
