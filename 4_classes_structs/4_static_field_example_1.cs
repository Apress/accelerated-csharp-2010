public class Employee
{
   public Employee()
   {
      // Set the static field to something.
      totalHeadCount = 123;

      // The following is a compiler error !!
      // this.totalHeadCount = 123;
      
      // Set the static field to something else.
      Employee.totalHeadCount = 456;
   }

   public static int totalHeadCount;
}

public class EntryPoint
{
   static void Main()
   {
      Employee bob = new Employee();
      
      System.Console.WriteLine(
                "Static Field Employee.totalHeadCount is {0}",
                Employee.totalHeadCount );

      // The following is a compile error !!
      // System.Console.WriteLine(
      //        "Static Field Employee.totalHeadCount is {0}",
      //        bob.totalHeadCount );
   }
}
