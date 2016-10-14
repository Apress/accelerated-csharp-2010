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

// Higher order function delegate definition
delegate void Task<out T>( Action<T> action );

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

        Task<Dog> doStuffToADog = BuildTask<Dog>();
        doStuffToADog( petDog );

        // But a task that accepts an action to a dog can also
        // accept an action to an animal
        doStuffToADog( petAnimal );

        // Therefore, it is logical for Task<Dog> to be implicitly
        // convertible to Task<Animal>
        //
        // Covariance in action!
        //
        // Since Dog -> Animal and
        // Task<Dog> -> Task<Animal>
        // then the following assignment is covariant
        Task<Animal> doStuffToAnAnimal = doStuffToADog;
        doStuffToAnAnimal( petAnimal );
        doStuffToADog( petAnimal );
    }

    static Task<T> BuildTask<T>() where T : new() {
        return (Action<T> action) => action( new T() );
    }
}
