using System;
using System.Linq;
using System.Dynamic;
using System.Collections.Generic;

static class EntryPoint
{
    static void Main() {
        // Create the kennel
        dynamic dogKennel = new ExpandoObject();
        
        // Set some useful properties
        dogKennel.Address = "1234 DogBone Way";
        dogKennel.City = "Fairbanks";
        dogKennel.State = "Alaska";

        dogKennel.Owner = new ExpandoObject();
        dogKennel.Owner.Name = "Ginger";

        // Setup a collection of dynamic dogs
        dogKennel.Dogs = new List<dynamic>();

        // Create some dogs
        dynamic thor = new ExpandoObject();
        thor.Name = "Thor";
        thor.Breed = "Siberian Husky";

        dynamic apollo = new ExpandoObject();
        apollo.Name = "Apollo";
        apollo.Breed = "Siberian Husky";

        // Put the dogs in the kennel
        dogKennel.Dogs.Add( thor );
        dogKennel.Dogs.Add( apollo );

        PrintExpandoObject( dogKennel, "Ginger's Kennel" );
    }

    static void PrintExpandoObject( dynamic obj,
                                    string name,
                                    int indent = 0 ) {
        Func<int, string> createPad = (n) => {
            return string.Join("", Enumerable.Repeat("   ", n) );
        };

        Console.WriteLine( createPad(indent) + name + ":" );
        ++indent;

        var dict = (IDictionary<string, object>) obj;
        foreach( var property in dict ) {
            if( property.Value is ExpandoObject ) {
                // Recurse to print the contained ExpandoObject
                PrintExpandoObject( property.Value,
                                    property.Key,
                                    indent );
            } else {
                if( property.Value is IEnumerable<dynamic> ) {
                    string collName = property.Key;
                    Console.WriteLine( "{0}{1} collection:",
                                       createPad(indent),
                                       collName );
                    int index = 0;
                    foreach( var item in
                             (IEnumerable<dynamic>)property.Value ) {
                        string itemName =
                            string.Format( "{0}[{1}]",
                                           collName,
                                           index++ );

                        // Recurse for this instance
                        PrintExpandoObject( item,
                                            itemName,
                                            indent+1 );
                    }
                } else {
                    Console.WriteLine( "{0}{1} = {2}",
                                       createPad(indent),
                                       property.Key,
                                       property.Value );
                }
            }
        }
    }
}
