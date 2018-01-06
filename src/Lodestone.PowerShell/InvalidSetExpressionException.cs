using System;
using System.Runtime.Serialization;

namespace Lodestone.PowerShell
{
   /// <summary>
   /// Represents an error that occurs when configuring a cmdlet property, when the expression
   /// does not indicate a public, getter/setter property that belongs to the specified cmdlet type.
   /// </summary>
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


      /// <summary>
      /// Initializes a new instance of the InvalidCmdletException class.
      /// </summary>
      /// <param name="info">
      /// The <seealso cref="SerializationInfo"></seealso> that holds the serialized object
      /// data about the exception being thrown.
      /// </param>
      /// <param name="context">
      /// The <seealso cref="StreamingContext"/> that contains contextual information
      /// about the source or destination.
      /// </param>
      protected InvalidSetExpressionException( SerializationInfo info, StreamingContext context )
         : base( info, context )
      {
      }
   }
}
