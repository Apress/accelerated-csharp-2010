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

public class Drawing : IEnumerable
{
   private ArrayList shapes;

   private class Iterator : IEnumerator
   {
      public Iterator( Drawing drawing )
      {
         this.drawing = drawing;
         this.current = -1;
      }

      public void Reset()
      {
         current = -1;
      }

      public bool MoveNext()
      {
         ++current;
         if( current < drawing.shapes.Count ) {
            return true;
         } else {
            return false;
         }
      }

      public object Current
      {
         get
         {
            return drawing.shapes[ current ];
         }
      }

      private Drawing   drawing;
      private int       current;
   }

   public Drawing()
   {
      shapes = new ArrayList();
   }

   public IEnumerator GetEnumerator()
   {
      return new Iterator( this );
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
      
      foreach( GeometricShape shape in drawing ) {
         shape.Draw();
      }
   }
}
