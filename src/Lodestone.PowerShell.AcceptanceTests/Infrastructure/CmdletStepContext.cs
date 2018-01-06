using System;
using System.Linq.Expressions;
using System.Management.Automation;

namespace Lodestone.PowerShell.AcceptanceTests.Infrastructure
{
   internal class CmdletStepContext
   {
      private object _hostFlow;
      private Func<object> _runAction;

      public void For<TCmdletType>() where TCmdletType : Cmdlet
      {
         _hostFlow = CmdletHost.For<TCmdletType>();
         _runAction = () => ( (HostFlow<TCmdletType>) _hostFlow ).Run();
      }

      public void With<TCmdletType, TParameterType>( Expression<Func<TCmdletType, TParameterType>> property, TParameterType value )
         where TCmdletType : Cmdlet
      {
         ( (HostFlow<TCmdletType>) _hostFlow ).With( property, value );
      }

      public object Run()
      {
         return _runAction();
      }
   }
}
