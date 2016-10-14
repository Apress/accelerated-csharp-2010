public class Employee
{
    public string name;
}

public class EntryPoint
{
    private static void InspectEmployee( Employee someEmployee ) {
        someEmployee.name = "Jane";
    }
    
    static void Main() {
        Employee joe = new Employee();
        joe.name = "Joe";
        InspectEmployee( joe );

        System.Console.WriteLine( "Employee name: {0}", joe.name );
    }
}
