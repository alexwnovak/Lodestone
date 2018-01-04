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
         return $"{cmdletAttribute.VerbName}-{cmdletAttribute.NounName}";
      }
   }
}
