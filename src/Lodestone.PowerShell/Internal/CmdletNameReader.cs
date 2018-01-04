using System;

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

         throw new NotImplementedException();
      }
   }
}
