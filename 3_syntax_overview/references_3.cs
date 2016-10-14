public class Employee
{
    public string name;
}

public class EntryPoint
{
    private static void CreateEmployee( ref Employee someEmployee ) {
        someEmployee = new Employee();
        someEmployee.name = "Joe";
    }
    
    static void Main() {
        Employee joe = null;
        CreateEmployee( ref joe );

        System.Console.WriteLine( "Employee name: {0}", joe.name );
    }
}
