using System;
using System.IO;
using System.Text;

public class EntryPoint
{
    public static void DoSomeStuff() {
        // Open a file.
        FileStream fs = null;
        try {
            fs = File.Open( "log.txt",
                            FileMode.Append,
                            FileAccess.Write,
                            FileShare.None );
            Byte[] msg =
                new UTF8Encoding(true).GetBytes("Doing Some"+
                                                " Stuff\n");
            fs.Write( msg, 0, msg.Length );
        }
        finally {
            if( fs != null ) {
                fs.Close();
            }
        }
    }

    public static void DoSomeMoreStuff() {
        // Open a file.
        FileStream fs = null;
        try {
            fs = File.Open( "log.txt",
                            FileMode.Append,
                            FileAccess.Write,
                            FileShare.None );
            Byte[] msg =
                new UTF8Encoding(true).GetBytes("Doing Some"+
                                                " More Stuff\n");
            fs.Write( msg, 0, msg.Length );
        }
        finally {
            if( fs != null ) {
                fs.Close();
            }
        }
    }

    static void Main() {
        DoSomeStuff();

        DoSomeMoreStuff();
    }
}
