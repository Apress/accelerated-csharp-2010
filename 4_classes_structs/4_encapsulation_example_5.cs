class MyRectangle
{
   private uint width;
   private uint height;
   private uint area;

   public uint Width
   {
      get
      {
         return width;
      }

      set
      {
         width = value;
         ComputeArea();
      }
   }

   public uint Height
   {
      get
      {
         return height;
      }

      set
      {
         height = value;
         ComputeArea();
      }
   }

   public uint Area
   {
      get
      {
         return area;
      }
   }

   private void ComputeArea()
   {
      area = width * height;
   }
}
