using System;
using System.Management.Automation;
using System.Reflection;

namespace Lodestone.PowerShell.Internal
{
   internal static class CmdletNameReader
   {
      public static string ReadName( Type type )
      {
         if ( type == null )
         {
            throw new ArgumentException( nameof( type ) );
         }

         var cmdletAttribute = (CmdletAttribute) type.GetCustomAttribute( typeof( CmdletAttribute ) );

         if ( cmdletAttribute == null )
         {
            string message = string.Format( Resources.MissingCmdletAttribute, type.FullName );
            throw new InvalidCmdletException( message );
         }

         if ( type.IsNotPublic )
         {
            string message = string.Format( Resources.NonPublicCmdlet, type.FullName );
            throw new InvalidCmdletException( message );
         }

         if ( type.BaseType != typeof( Cmdlet ) && type.BaseType != typeof( PSCmdlet ) )
         {
            string message = string.Format( Resources.MessageCmdletBaseType, type.FullName );
            throw new InvalidCmdletException( message );
         }

         return $"{cmdletAttribute.VerbName}-{cmdletAttribute.NounName}";
      }
   }
}
