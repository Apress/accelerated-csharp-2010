using System;
using System.Dynamic;
using System.Collections.Generic;

class MyDynamicType : DynamicObject
{
    public override bool TryInvokeMember( InvokeMemberBinder binder,
                                          object[] args,
                                          out object result ) {
        result = null;
        Console.WriteLine( "Dynamic invoke of " + GetType() +
                           "." + binder.Name + "()" );
        return true;
    }

    public override bool TrySetMember( SetMemberBinder binder,
                                       object Value ) {
        Console.WriteLine( "Dynamic set of property " + GetType() +
                           "." + binder.Name + " to " +
                           Value );

        return true;
    }

    public void DoDefaultWork() {
        Console.WriteLine( "Performing default work" );
    }
}

static class EntryPoint
{
    static void Main() {
        dynamic d = new MyDynamicType();

        d.DoDefaultWork();
        d.DoWork();
        d.Value = 42;
        d.Count = 123;
    }
}
