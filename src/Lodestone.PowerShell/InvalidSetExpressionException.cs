using System;
using System.Runtime.Serialization;

namespace Lodestone.PowerShell
{
   [Serializable]
   public class InvalidSetExpressionException : Exception
   {
      public InvalidSetExpressionException()
      {
      }

      public InvalidSetExpressionException( string message ) : base( message )
      {
      }

      public InvalidSetExpressionException( string message, Exception inner )
         : base( message, inner )
      {
      }

      protected InvalidSetExpressionException( SerializationInfo info, StreamingContext context )
         : base( info, context )
      {
      }
   }
}
