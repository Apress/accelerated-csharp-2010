class C
{
    public void Foo() {
    }
}

static class EntryPoint
{
    static void Main() {
        dynamic dynobj = new C();

        dynobj.Bar();
    }
}
