using System.Management.Automation;

namespace Lodestone.PowerShell
{
   public static class CmdletHost
   {
      public static HostFlow<TCmdletType> For<TCmdletType>() where TCmdletType : Cmdlet =>
         new HostFlow<TCmdletType>();
   }
}
