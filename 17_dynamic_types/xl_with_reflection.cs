using System;
using System.Reflection;

static class EntryPoint
{
    static void Main() {
        // Create an instance of Excel
        Type xlAppType = Type.GetTypeFromProgID( "Excel.Application" );
        
        object xl = Activator.CreateInstance( xlAppType );

        // Set Excel to be visible
        xl.GetType().InvokeMember( "Visible",
                                   BindingFlags.SetProperty,
                                   null,
                                   xl,
                                   new object[] { true } );

        // Create a new workbook
        object workbooks = xl.GetType().InvokeMember( "Workbooks",
                                                      BindingFlags.GetProperty,
                                                      null,
                                                      xl,
                                                      null );

        workbooks.GetType().InvokeMember( "Add",
                                          BindingFlags.InvokeMethod,
                                          null,
                                          workbooks,
                                          new object[] { -4167 } );
        
        // Set the value of the first cell
        object cell = xl.GetType().InvokeMember( "Cells",
                                                 BindingFlags.GetProperty,
                                                 null,
                                                 xl,
                                                 new object[] { 1, 1 } );
        cell.GetType().InvokeMember( "Value2",
                                     BindingFlags.SetProperty,
                                     null,
                                     cell,
                                     new object[] { "C# Rocks!" } );

        Console.WriteLine( "Press Enter to Continue..." );
        Console.ReadLine();
    }
}
