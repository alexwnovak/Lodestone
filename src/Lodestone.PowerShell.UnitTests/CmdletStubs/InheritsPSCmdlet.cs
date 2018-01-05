using System.Management.Automation;

namespace Lodestone.PowerShell.UnitTests.CmdletStubs
{
   [Cmdlet( VerbsCommon.Get, "InheritsPSCmdlet" )]
   public class InheritsPSCmdlet : PSCmdlet
   {
   }
}
