using System;

public class ConventionalEmployeeInfo
{
    public ConventionalEmployeeInfo( string Name, int Id ) {
        this.name = Name;
        this.id = Id;
    }

    public string Name {
        get {
            return name;
        }

        set {
            name = value;
        }
    }

    public int Id {
        get {
            return id;
        }

        set {
            id = value;
        }
    }

    private string name;
    private int id;
}

public class EntryPoint
{
    static void Main() {
        ConventionalEmployeeInfo oldEmployee =
            new ConventionalEmployeeInfo( "Joe", 42 );
        
        var employeeInfo = new { oldEmployee.Name,
                                 oldEmployee.Id };

        string Name = "Jane";
        int Id = 1234;

        var customerInfo = new { Name, Id };

        Console.WriteLine( "employeeInfo Name: {0}, Id: {1}",
                           employeeInfo.Name,
                           employeeInfo.Id );
        Console.WriteLine( "customerInfo Name: {0}, Id: {1}",
                           customerInfo.Name,
                           customerInfo.Id );

        Console.WriteLine( "Anonymous Type is actually: {0}",
                           employeeInfo.GetType() );
    }
}
