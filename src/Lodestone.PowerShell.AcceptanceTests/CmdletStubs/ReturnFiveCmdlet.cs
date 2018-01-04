using System.Management.Automation;

namespace Lodestone.PowerShell.AcceptanceTests.CmdletStubs
{
   [Cmdlet( VerbsCommon.Get, "Five" )]
   internal class ReturnFiveCmdlet : Cmdlet
   {
      protected override void ProcessRecord()
      {
         WriteObject( 5 );
      }
   }
}
