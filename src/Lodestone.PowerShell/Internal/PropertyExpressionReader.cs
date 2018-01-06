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
            string message = string.Format( Resources.InvalidSetExpression, typeof( T ).FullName );
            throw new InvalidSetExpressionException( message );
         }
         
         var memberExpression = (MemberExpression) property.Body;

         if ( memberExpression.Member.MemberType != MemberTypes.Property )
         {
            string message = string.Format( Resources.InvalidSetExpression, typeof( T ).FullName );
            throw new InvalidSetExpressionException( message );
         }

         if ( memberExpression.Member.DeclaringType != typeof( T ) )
         {
            string message = string.Format( Resources.InvalidSetExpression, typeof( T ).FullName );
            throw new InvalidSetExpressionException( message );
         }

         var propertyInfo = memberExpression.Member.ReflectedType.GetProperty( memberExpression.Member.Name, BindingFlags.Public | BindingFlags.Instance );

         if ( propertyInfo == null )
         {
            string message = string.Format( Resources.InvalidSetExpression, typeof( T ).FullName );
            throw new InvalidSetExpressionException( message );
         }

         if ( propertyInfo.GetSetMethod() == null )
         {
            string message = string.Format( Resources.InvalidSetExpression, typeof( T ).FullName );
            throw new InvalidSetExpressionException( message );
         }

         return memberExpression.Member.Name;
      }
   }
}
