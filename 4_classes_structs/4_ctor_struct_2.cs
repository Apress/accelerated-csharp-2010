using System;

public struct Square
{
   public int Width
   {
      get
      {
         return width;
      }

      set
      {
         width = value;
      }
   }

   public int Height
   {
      get
      {
         return height;
      }

      set
      {
         height = value;
      }
   }
   
   private int width;
   private int height;
}

public class EntryPoint
{
   static void Main()
   {
      Square sq;
      sq.Width = 1;
      sq.Height = 1;
   }
}
