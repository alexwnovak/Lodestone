using System.Management.Automation;

namespace Lodestone.PowerShell
{
   public class HostFlow<TCmdletType> where TCmdletType : Cmdlet
   {
      internal HostFlow()
      {
      }
   }
}
