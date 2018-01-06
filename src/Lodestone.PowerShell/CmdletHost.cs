using System.Management.Automation;

namespace Lodestone.PowerShell
{
   /// <summary>
   /// Provides a host for executing PowerShell cmdlets.
   /// </summary>
   public static class CmdletHost
   {
      /// <summary>
      /// Specifies the type of cmdlet to host.
      /// </summary>
      /// <typeparam name="TCmdletType">The Cmdlet-derived type to host.</typeparam>
      /// <returns>
      /// A <seealso cref="HostFlow{TCmdletType}" /> for the specified Cmdlet type. This is
      /// the fluent API and can configure the cmdlet parameters and run it.
      /// </returns>
      public static HostFlow<TCmdletType> For<TCmdletType>() where TCmdletType : Cmdlet =>
         new HostFlow<TCmdletType>();
   }
}
