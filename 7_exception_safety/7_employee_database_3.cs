using System.Collections;

class Employee
{
}

class EmployeeDatabase
{
    public void TerminateEmployee( int index ) {
        object employee = null;
        try {
            employee = activeEmployees[index];
        }
        catch {
            // oops!  We must be out of range here.
        }

        if( employee != null ) {
            activeEmployees.RemoveAt( index );

            try {
                terminatedEmployees.Add( employee );
            }
            catch {
                // oops! Allocation may have failed.
                activeEmployees.Add( employee );
            }
        }
    }

    private ArrayList activeEmployees;
    private ArrayList terminatedEmployees;
}
