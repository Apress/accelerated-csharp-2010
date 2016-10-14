interface IKnowsIcelandic
{
}

class Dog : IKnowsIcelandic
{
}

class Human : IKnowsIcelandic
{
}

class LanguagesAreFun
{
   static void ListenToMe( IKnowsIcelandic listener )
   {
   }
   
   static void Main()
   {
      Dog dog = new Dog();
      Human human = new Human();

      ListenToMe( dog );
      ListenToMe( human );
   }
}

