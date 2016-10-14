using System;
using System.Text.RegularExpressions;

public class EntryPoint
{
    static void Main( string[] args ) {
        if( args.Length < 1 ) {
            Console.WriteLine( "You must provide a string." );
            return;
        }

        // Create regex to search for IP address pattern.
        string pattern = @"
# First part match
([01]?\d\d?         # At least one digit,
                    # possibly prepended by 0 or 1
                    # and possibly followed by another digit
# OR
 |2[0-4]\d          # Starts with a 2, after a number from 0-4
                    # and then any digit
# OR
 |25[0-5])          # 25 followed by a number from 0-5

\.                  # The whole group is followed by a period.

# REPEAT
([01]?\d\d?|2[0-4]\d|25[0-5])\.

# REPEAT
([01]?\d\d?|2[0-4]\d|25[0-5])\.

# REPEAT
([01]?\d\d?|2[0-4]\d|25[0-5])
";
        Regex regex = new Regex( pattern,
                       RegexOptions.IgnorePatternWhitespace );
        Match match = regex.Match( args[0] );
        while( match.Success ) {
            Console.WriteLine( "IP Address found at {0} with " +
                               "value of {1}",
                               match.Index,
                               match.Value );

            match = match.NextMatch();
        }
        
    }
}
