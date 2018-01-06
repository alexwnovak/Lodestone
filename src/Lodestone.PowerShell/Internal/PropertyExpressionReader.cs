using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Lodestone.PowerShell.Internal
{
   internal static class PropertyExpressionReader
   {
      public static string GetName<T, TParameterType>( Expression<Func<T, TParameterType>> property )
      {
         if ( !( property.Body is MemberExpression ) )
         {
            throw new InvalidSetExpressionException( Resources.InvalidSetExpression );
         }
         
         var memberExpression = (MemberExpression) property.Body;

         if ( memberExpression.Member.MemberType != MemberTypes.Property )
         {
            throw new InvalidSetExpressionException( Resources.InvalidSetExpression );
         }

         var propertyInfo = memberExpression.Member.ReflectedType.GetProperty( memberExpression.Member.Name, BindingFlags.Public | BindingFlags.Instance );

         if ( propertyInfo == null )
         {
            throw new InvalidSetExpressionException( Resources.InvalidSetExpression );
         }

         return memberExpression.Member.Name;
      }
   }
}
