class C
{
}

static class EntryPoint
{
    static void Main() {
        dynamic d = new C();

        // explicit cast back to C reference
        C cObj = (C) d;

        // What happens here???
        string str = d;
    }
}
