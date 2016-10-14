using System;

class Animal
{
    public virtual void ShowAffection() {
        Console.WriteLine( "Response unknown" );
    }
}

class Dog : Animal
{
    public override void ShowAffection() {
        Console.WriteLine( "Wag Tail..." );
    }
}

static class EntryPoint
{
    static void Main() {
        Action<Animal> petAnimal = (Animal a) => {
            Console.Write( "Petting animal and response is: " );
            a.ShowAffection();
        };

        // Contravariance rule in action!
        //
        // Since Dog -> Animal and
        // Action<Animal> -> Action<Dog>
        // then the following assignment is contravariant
        Action<Dog> petDog = petAnimal;

        petDog( new Dog() );
    }
}
