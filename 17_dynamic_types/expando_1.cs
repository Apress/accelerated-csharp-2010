using System;
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
    }
}
