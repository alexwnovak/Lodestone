using System.Management.Automation;

namespace Lodestone.PowerShell.AcceptanceTests.CmdletStubs
{
   [Cmdlet( VerbsCommon.Get, "Five" )]
   public class GetFive : Cmdlet
   {
      protected override void ProcessRecord()
      {
         WriteObject( 5 );
      }
   }
}
