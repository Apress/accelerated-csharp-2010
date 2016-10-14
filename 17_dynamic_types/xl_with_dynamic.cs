using System;

static class EntryPoint
{
    static void Main() {
        Type xlAppType = Type.GetTypeFromProgID( "Excel.Application" );
        dynamic xl = Activator.CreateInstance( xlAppType );

        xl.Visible = true;

        dynamic workbooks = xl.Workbooks;
        workbooks.Add( -4167 );

        xl.Cells[1, 1].Value2 = "C# Rocks!";

        Console.WriteLine( "Press Enter to Continue..." );
        Console.ReadLine();
    }
}
