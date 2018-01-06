using System;
using System.Runtime.Serialization;

namespace Lodestone.PowerShell
{
   [Serializable]
   public class InvalidSetExpressionException : Exception
   {
      /// <summary>
      /// Initializes a new instance of the InvalidSetExpressionException class.
      /// </summary>
      public InvalidSetExpressionException()
      {
      }

      /// <summary>
      /// Initializes a new instance of the InvalidSetExpressionException class.
      /// </summary>
      /// <param name="message">The error message that explains the reason for the exception.</param>
      public InvalidSetExpressionException( string message ) : base( message )
      {
      }

      /// <summary>
      /// Initializes a new instance of the InvalidSetExpressionException class.
      /// </summary>
      /// <param name="message">The error message that explains the reason for the exception.</param>
      /// <param name="innerException">
      /// The exception that is the cause of the current exception, or a null reference
      /// (Nothing in Visual Basic) if no inner exception is specified.
      /// </param>
      public InvalidSetExpressionException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      protected InvalidSetExpressionException( SerializationInfo info, StreamingContext context )
         : base( info, context )
      {
      }
   }
}
