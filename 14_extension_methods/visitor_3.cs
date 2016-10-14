using System;
using ValidatorExtensions;

namespace ValidatorExtensions
{
    public static class Validators
    {
        public static void Validate( this String str ) {
            // Do something to validate the String instance.
            
            Console.WriteLine( "String with \"" +
                               str +
                               "\" Validated." );
        }

        public static void Validate( this SupplyCabinet cab ) {
            // Do something to validate the SupplyCabinet instance.

            Console.WriteLine( "Supply Cabinet Validated." );
        }

        public static void Validate( this Employee emp ) {
            // Do something to validate the Employee instance.

            Console.WriteLine( "** Employee Failed Validation! **" );
        }

        public static void Validate<T>( this T obj )
                            where T: IValidator {
            obj.DoValidation();
            Console.WriteLine( "Instance of following type" +
                               " validated: " +
                               obj.GetType() );
        }
    }
}

public interface IValidator
{
    void DoValidation();
}

public class SupplyCabinet : IValidator
{
    public void DoValidation() {
        Console.WriteLine( "\tValidating SupplyCabinet" );
    }
}

public class Employee
{
}

public class MyApplication
{
    static void Main() {
        String data = "some important data";

        SupplyCabinet supplies = new SupplyCabinet();

        Employee hrLady = new Employee();

        data.Validate();

        // Force generic version
        supplies.Validate<SupplyCabinet>();

        hrLady.Validate();
    }
}
