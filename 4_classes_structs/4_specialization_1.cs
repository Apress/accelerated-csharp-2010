public class GeometricShape
{
   public virtual void Draw()
   {
      // Do some default drawing stuff.
   }
}

public class Rectangle : GeometricShape
{
   public override void Draw()
   {
      // Draw a rectangle
   }
}

public class Circle : GeometricShape
{
   public override void Draw()
   {
      // Draw a circle
   }
}

public class EntryPoint
{
   private static void DrawShape( GeometricShape shape )
   {
      shape.Draw();
   }
   
   static void Main()
   {
      Circle circle = new Circle();
      GeometricShape shape = circle;

      DrawShape( shape );
      DrawShape( circle );
   }
}
