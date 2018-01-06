using System.Management.Automation;

namespace Lodestone.PowerShell.UnitTests.Stubs.Cmdlets
{
   [Cmdlet( VerbsCommon.Get, "WellFormedButInternalCmdlet" )]
   internal class InternalCmdlet : Cmdlet
   {
   }
}
