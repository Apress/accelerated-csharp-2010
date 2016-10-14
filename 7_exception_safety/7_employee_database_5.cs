using System;
using System.Runtime.Serialization;

[Serializable()]
public class EmployeeVerificationException : Exception
{
    public enum Cause {
        InvalidSSN,
        InvalidBirthDate
    }

    public EmployeeVerificationException( Cause reason )
        :base() {
        this.Reason = reason;
    }

    public EmployeeVerificationException( Cause reason,
                                          String msg )
        :base( msg ) {
        this.Reason = reason;
    }

    public EmployeeVerificationException( Cause reason,
                                          String msg,
                                          Exception inner )
        :base( msg, inner ) {
        this.Reason = reason;
    }

    protected EmployeeVerificationException(
                   SerializationInfo info,
                   StreamingContext  context )
                :base( info, context ) { }

    public Cause Reason { get; private set; }
}
