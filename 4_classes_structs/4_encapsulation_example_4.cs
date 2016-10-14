class MyRectangle
{
   public uint width;
   public uint height;

   private uint area;

   public uint GetArea()
   {
      if( area == 0 ) {
         area = width * height;
      }

      return area;
   }
}
