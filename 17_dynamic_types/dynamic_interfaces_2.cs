using System;
using System.Collections.Generic;

class C
{
}

static class EntryPoint
{
    static void Main() {
        IList<dynamic> myList = new List<dynamic>();

        myList.Add( new C() );
        myList.Add( new object() );

        foreach( dynamic item in myList ) {
            Console.WriteLine( item.GetType() );
        }
    }
}
