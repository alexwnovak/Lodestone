using System;
using System.Runtime.Serialization;

namespace Lodestone.PowerShell
{
   [Serializable]
   public class InvalidCmdletException : Exception
   {
      public InvalidCmdletException()
      {
      }

      public InvalidCmdletException( string message ) : base( message )
      {
      }

      public InvalidCmdletException( string message, Exception inner )
         : base( message, inner )
      {
      }

      protected InvalidCmdletException( SerializationInfo info, StreamingContext context )
         : base( info, context )
      {
      }
   }
}
