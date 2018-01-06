using System;
using System.Linq.Expressions;

namespace Lodestone.PowerShell.Internal
{
   internal static class PropertyExpressionReader
   {
      public static string Validate<T, TParameterType>( Expression<Func<T, TParameterType>> property )
      {
         var member = (MemberExpression) property.Body;
         return member.Member.Name;
      }
   }
}
