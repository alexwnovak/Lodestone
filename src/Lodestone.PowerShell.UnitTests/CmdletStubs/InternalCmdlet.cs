using System.Management.Automation;

namespace Lodestone.PowerShell.UnitTests.CmdletStubs
{
   [Cmdlet( VerbsCommon.Get, "WellFormedButInternalCmdlet" )]
   internal class InternalCmdlet : Cmdlet
   {
   }
}
