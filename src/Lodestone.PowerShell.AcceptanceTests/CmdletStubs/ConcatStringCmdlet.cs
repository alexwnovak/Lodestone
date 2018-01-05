using System.Management.Automation;

namespace Lodestone.PowerShell.AcceptanceTests.CmdletStubs
{
   [Cmdlet( "Concat", "String" )]
   public class ConcatStringCmdlet : Cmdlet
   {
      public string Value
      {
         get;
         set;
      }

      protected override void ProcessRecord()
      {
         WriteObject( $"Received {Value}" );
      }
   }
}
