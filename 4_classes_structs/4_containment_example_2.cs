public class EncryptedNetworkCommunicator : NetworkCommunicator
{
   public override void SendData( DataObject obj )
   {
      // Encrypt the data.
      base.SendData( obj );
   }

   public override DataObject ReceiveData()
   {
      DataObject obj = base.ReceiveData();

      // Decrypt data.
      
      return obj;
   }
}
