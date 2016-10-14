public class EncryptedNetworkCommunicator
{
   public EncryptedNetworkCommunicator()
   {
      contained = new NetworkCommunicator();
   }
   
   public void SendData( DataObject obj )
   {
      // Encrypt the data.
      contained.SendData( obj );
   }

   public DataObject ReceiveData()
   {
      DataObject obj = contained.ReceiveData();

      // Decrypt data

      return obj;
   }

   private NetworkCommunicator contained;
}
