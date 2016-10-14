public class EntryPoint
{
    static void Main() {
        string[] names = new string[4];
        object[] objects = names;

        string[] originalNames = (string[]) objects;
    }
}
