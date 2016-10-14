using System;
using System.Diagnostics;

public class Database
{
    public void Commit() {
        Console.WriteLine( "Changes Committed" );
    }

    public void Rollback() {
        Console.WriteLine( "Changes Abandoned" );
    }
}

public class RollbackHelper : IDisposable
{
    public RollbackHelper( Database db ) {
        this.db = db;
    }

    ~RollbackHelper() {
        Dispose( false );
    }

    public void Dispose() {
        Dispose( true );
    }

    public void Commit() {
        db.Commit();
        committed = true;
    }

    private void Dispose( bool disposing ) {
        // Don't do anything if already disposed.  Remember, it is
        // valid to call Dispose() multiple times on a disposable
        // object.
        if( !disposed ) {
            disposed = true;

            // Remember, we don't want to do anything to the db if
            // we got here from the finalizer because the database
            // field could already be finalized!
            if( disposing ) {
                if( !committed ) {
                    db.Rollback();
                }
            } else {
                Debug.Assert( false, "Failed to call Dispose()" +
                                     " on RollbackHelper" );
            }
        }
    }

    private Database db;
    private bool     disposed = false;
    private bool     committed = false;
}

public class EntryPoint
{
    static private void DoSomeWork() {
        using( RollbackHelper guard = new RollbackHelper(db) ) {
            // Here we do some work that could throw an exception.
            
            // Comment out the following line to cause an
            // exception.  nullPtr.GetType();
            
            // If we get here, we commit.
            guard.Commit();
        }
        
    }

    static void Main() {
        db = new Database();
        DoSomeWork();
    }

    static private Database db;
    static private Object   nullPtr = null;
}
