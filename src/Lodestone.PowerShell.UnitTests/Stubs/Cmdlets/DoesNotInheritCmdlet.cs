using System.Management.Automation;

namespace Lodestone.PowerShell.UnitTests.Stubs.Cmdlets
{
   [Cmdlet( VerbsCommon.Get, "IntentionallyDoesNotInheritCmdlet") ]
   public class DoesNotInheritCmdlet
   {
   }
}
