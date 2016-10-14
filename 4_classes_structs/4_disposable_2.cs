using System;

public class A : IDisposable
{
   private bool disposed = false;
   private void Dispose( bool disposing )
   {
      if( !disposed ) {
         if( disposing ) {
            // It is safe to access other objects here.
         }
         
         Console.WriteLine( "Cleaning up object" );
         disposed = true;
      }
   }
   public void Dispose()
   {
      Dispose( true );
      GC.SuppressFinalize( this );
   }

   public void DoSomething()
   {
      Console.WriteLine( "A.SoSomething()" );
   }

   ~A()
   {
      Console.WriteLine( "Finalizing" );
      Dispose( false );
   }
}

public class EntryPoint
{
   static void Main()
   {
      using( A a = new A() ) {
         a.DoSomething();
      }

      using( A a = new A(), b = new A() ) {
         a.DoSomething();
         b.DoSomething();
      }
   }
}
