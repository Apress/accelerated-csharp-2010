public class EntryPoint
{
    static void Main() {
        int employeeID = 303;
        object boxedID = employeeID;
        
        employeeID = 404;
        int unboxedID = (int) boxedID;

        System.Console.WriteLine( employeeID.ToString() );
        System.Console.WriteLine( unboxedID.ToString() );
    }
}
