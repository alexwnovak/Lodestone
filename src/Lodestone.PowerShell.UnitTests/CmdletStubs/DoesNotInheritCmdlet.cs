using System.Management.Automation;

namespace Lodestone.PowerShell.UnitTests.CmdletStubs
{
   [Cmdlet( VerbsCommon.Get, "IntentionallyDoesNotInheritCmdlet") ]
   public class DoesNotInheritCmdlet
   {
   }
}
