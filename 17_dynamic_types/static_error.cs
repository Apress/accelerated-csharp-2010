class C
{
    public void Foo() {
    }
}

static class EntryPoint
{
    static void Main() {
        C obj = new C();

        obj.Bar();
    }
}
