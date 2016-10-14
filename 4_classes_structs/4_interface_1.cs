public interface IMusician
{
   void PlayMusic();
}

public class TalentedPerson : IMusician
{
   void PlayMusic();
   void DoALittleDance();
}

public class EntryPoint
{
   static void Main()
   {
      TalentedPerson dude = new TalentedPerson();
      IMusician musician = dude;

      musician.PlayMusic();
      dude.PlayMusic();
      dude.DoALittleDance();
   }
}
