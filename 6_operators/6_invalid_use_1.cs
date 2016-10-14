public class Apple
{
    public static Apple operator+( Apple rhs, Apple lhs ) {
        // Method does nothing and exists only for example.
        return rhs;
    }
}

public class GreenApple : Apple
{
    // INVALID!! -- Won't compile.
    public static Apple operator+( Apple rhs, Apple lhs ) {
        // Method does nothing and exists only for example.
        return rhs;
    }
}

