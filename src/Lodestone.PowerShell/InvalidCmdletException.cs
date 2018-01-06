using System;
using System.Runtime.Serialization;

namespace Lodestone.PowerShell
{
   /// <summary>
   /// Represents an error that occurs when running a misconfigured cmdlet type.
   /// </summary>
   [Serializable]
   public class InvalidCmdletException : Exception
   {
      /// <summary>
      /// Initializes a new instance of the InvalidCmdletException class.
      /// </summary>
      public InvalidCmdletException()
      {
      }

      /// <summary>
      /// Initializes a new instance of the InvalidCmdletException class.
      /// </summary>
      /// <param name="message">The error message that explains the reason for the exception.</param>
      public InvalidCmdletException( string message ) : base( message )
      {
      }

      /// <summary>
      /// Initializes a new instance of the InvalidCmdletException class.
      /// </summary>
      /// <param name="message">The error message that explains the reason for the exception.</param>
      /// <param name="innerException">
      /// The exception that is the cause of the current exception, or a null reference
      /// (Nothing in Visual Basic) if no inner exception is specified.
      /// </param>
      public InvalidCmdletException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      protected InvalidCmdletException( SerializationInfo info, StreamingContext context )
         : base( info, context )
      {
      }
   }
}
