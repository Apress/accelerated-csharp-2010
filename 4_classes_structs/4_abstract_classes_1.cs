public abstract class GeometricShape
{
   public abstract void Draw();
}

public class Circle : GeometricShape
{
   public override void Draw()
   {
      // Do some drawing.
   }
}

public class EntryPoint
{
   static void Main()
   {
      Circle shape = new Circle();

      // This won't work!
      // GeometricShape shape2 = new GeometricShape();

      shape.Draw();
   }
}
