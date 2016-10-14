using System;
using System.Linq;
using System.Collections.Generic;

public class LambdaTest
{
    static void Main() {
        var teamMembers = new List<string> {
            "Lou Loomis",
            "Smoke Porterhouse",
            "Danny Noonan",
            "Ty Webb"
        };

        FindByFirstName( teamMembers,
                         "Danny",
                         (x, y) => x.Contains(y) );
    }

    static void FindByFirstName(
                        List<string> members,
                        string firstName, 
                        Func<string, string, bool> predicate ) {
        foreach( var member in members ) {
            if( predicate(member, firstName) ) {
                Console.WriteLine( member );
            }
        }
    }
}
