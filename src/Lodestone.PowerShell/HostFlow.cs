using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Management.Automation;
using Lodestone.PowerShell.Internal;

namespace Lodestone.PowerShell
{
   /// <summary>
   /// The basis for the fluent API. This allows configuration calls be to chained together,
   /// as well as running the cmdlet.
   /// </summary>
   /// <typeparam name="TCmdletType">The type of cmdlet being hosted.</typeparam>
   public class HostFlow<TCmdletType> where TCmdletType : Cmdlet
   {
      private readonly Dictionary<string, object> _parameterDictionary = new Dictionary<string, object>();

      internal HostFlow()
      {
      }

      /// <summary>
      /// Configures a cmdlet parameter. Use this to pass values to the cmdlet via its public properties
      /// (those marked with a <seealso cref="ParameterAttribute"/>.
      /// </summary>
      /// <typeparam name="TParameterType">The property's type.</typeparam>
      /// <param name="property">An expression that indicates the property to assign.</param>
      /// <param name="value">The value to assign to the property.</param>
      /// <returns>
      /// The same <seealso cref="HostFlow{TCmdletType}"/> to allow further method chaining.
      /// </returns>
      /// <remarks>
      /// The <seealso cref="property" /> parameter is a compiler-safe way of specifying the property
      /// that should be assigned. The usage is an lambda that points to the property:
      /// 
      /// CmdletHost.For< StartProcessCmdlet >()
      ///           .With< string >( c => c.FilePath, "notepad.exe" )
      ///           .Run();
      /// </remarks>
      public HostFlow<TCmdletType> With<TParameterType>( Expression<Func<TCmdletType, TParameterType>> property, TParameterType value )
      {
         var member = (MemberExpression) property.Body;
         string propertyName = member.Member.Name;

         _parameterDictionary[propertyName] = value;

         return this;
      }

      /// <summary>
      /// Begins a PowerShell session, loads the specified cmdlet type, applies all parameter configurations
      /// (specified by the <seealso cref="With{TParameterType}" /> method), and executes the cmdlet.
      /// </summary>
      /// <returns>Anything that was written to the object pipeline.</returns>
      /// <exception cref="InvalidCmdletException">
      /// Thrown if the cmdlet type can't be run, typically because it doesn't conform to the cmdlet
      /// requirements. This is typically:
      ///    - The class inherits <seealso cref="Cmdlet"/> or <seealso cref="PSCmdlet"/>
      ///    - The class has the <seealso cref="CmdletAttribute"/> attribute
      ///    - The class is public
      /// </exception>
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
