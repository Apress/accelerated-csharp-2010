using System;
using System.IO;
using System.Text;

public class EntryPoint
{
    public static void DoSomeStuff() {
        // Open a file.
        using( FileStream fs = File.Open( "log.txt",
                                          FileMode.Append,
                                          FileAccess.Write,
                                          FileShare.None ) ) {
            Byte[] msg =
                new UTF8Encoding(true).GetBytes("Doing Some" +
                                                " Stuff\n");
            fs.Write( msg, 0, msg.Length );
        }
    }

    public static void DoSomeMoreStuff() {
        // Open a file.
        using( FileStream fs = File.Open( "log.txt",
                                          FileMode.Append,
                                          FileAccess.Write,
                                          FileShare.None ) ) {
            Byte[] msg =
                new UTF8Encoding(true).GetBytes("Doing Some" +
                                                " More Stuff\n");
            fs.Write( msg, 0, msg.Length );
        }
    }

    static void Main() {
        DoSomeStuff();

        DoSomeMoreStuff();
    }
}
