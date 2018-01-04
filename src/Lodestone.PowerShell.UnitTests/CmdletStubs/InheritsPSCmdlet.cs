using System.Management.Automation;

namespace Lodestone.PowerShell.UnitTests.CmdletStubs
{
   [Cmdlet( VerbsCommon.Get, "InheritsPSCmdlet" )]
   internal class InheritsPSCmdlet : PSCmdlet
   {
   }
}
