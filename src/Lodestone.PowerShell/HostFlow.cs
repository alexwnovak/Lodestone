using System.Management.Automation;
using Lodestone.PowerShell.Internal;

namespace Lodestone.PowerShell
{
   public class HostFlow<TCmdletType> where TCmdletType : Cmdlet
   {
      internal HostFlow()
      {
      }

      public object Run()
      {
         using ( var powerShell = System.Management.Automation.PowerShell.Create() )
         {
            powerShell.AddCommand( "Import-Module" ).AddParameter( "Assembly", typeof( TCmdletType ).Assembly );
            powerShell.Invoke();
            powerShell.Commands.Clear();

            string cmdletName = CmdletNameReader.ReadName( typeof( TCmdletType ) );
            powerShell.AddCommand( cmdletName );

            var output = powerShell.Invoke();
            return output[0].BaseObject;
         }
      }
   }
}
