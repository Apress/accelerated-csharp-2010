using System;
using System.Collections.Generic;

static class EntryPoint
{
    static void Main() {
        List<string> strings = new List<string> {
            "One",
            "Two",
            "Three"
        };

        // THIS WILL NOT COMPILE!!!
        List<object> objects = strings;
    }
}
