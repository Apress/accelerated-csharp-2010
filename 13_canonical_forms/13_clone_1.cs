using System;

public sealed class Dimensions : ICloneable
{
    public Dimensions( long width, long height ) {
        this.width = width;
        this.height = height;
    }

    // IClonable implementation
    public object Clone() {
        return this.MemberwiseClone();
    }
    
    private long width;
    private long height;
}
