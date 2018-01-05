using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Management.Automation;
using Lodestone.PowerShell.Internal;

namespace Lodestone.PowerShell
{
   public class HostFlow<TCmdletType> where TCmdletType : Cmdlet
   {
      private readonly Dictionary<string, object> _parameterDictionary = new Dictionary<string, object>();

      internal HostFlow()
      {
      }

      public HostFlow<TCmdletType> With<TParameterType>( Expression<Func<TCmdletType, TParameterType>> property, TParameterType value )
      {
         var member = (MemberExpression) property.Body;
         string propertyName = member.Member.Name;

         _parameterDictionary[propertyName] = value;

         return this;
      }

      public object Run()
      {
         using ( var powerShell = System.Management.Automation.PowerShell.Create() )
         {
            powerShell.AddCommand( "Import-Module" ).AddParameter( "Assembly", typeof( TCmdletType ).Assembly );
            powerShell.Invoke();
            powerShell.Commands.Clear();

            string cmdletName = CmdletNameReader.ReadName( typeof( TCmdletType ) );
            var command = powerShell.AddCommand( cmdletName );

            foreach ( var keyValuePair in _parameterDictionary )
            {
               command.AddParameter( keyValuePair.Key, keyValuePair.Value );
            }

            var output = powerShell.Invoke();
            return output[0].BaseObject;
         }
      }
   }
}
