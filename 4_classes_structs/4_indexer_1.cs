using System.Collections;

public abstract class GeometricShape
{
   public abstract void Draw();
}

public class Rectangle : GeometricShape
{
   public override void Draw()
   {
      System.Console.WriteLine( "Rectangle.Draw" );
   }
}

public class Circle : GeometricShape
{
   public override void Draw()
   {
      System.Console.WriteLine( "Circle.Draw" );
   }
}

public class Drawing
{
   private ArrayList shapes;

   public Drawing()
   {
      shapes = new ArrayList();
   }

   public int Count
   {
      get
      {
         return shapes.Count;
      }
   }

   public GeometricShape this[ int index ]
   {
      get
      {
         return (GeometricShape) shapes[index];
      }
   }

   public void Add( GeometricShape shape )
   {
      shapes.Add( shape );
   }
}

public class EntryPoint
{
   static void Main()
   {
      Rectangle rectangle = new Rectangle();
      Circle circle = new Circle();
      Drawing drawing = new Drawing();

      drawing.Add( rectangle );
      drawing.Add( circle );
      
      for( int i = 0; i < drawing.Count; ++i ) {
         GeometricShape shape = drawing[i];
         shape.Draw();
      }
   }
}
