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
            ThrowInvalidSetExpression( typeof( T ).FullName );
         }
         
         var memberExpression = (MemberExpression) property.Body;

         if ( memberExpression.Member.MemberType != MemberTypes.Property )
         {
            ThrowInvalidSetExpression( typeof( T ).FullName );
         }

         if ( memberExpression.Member.DeclaringType != typeof( T ) )
         {
            ThrowInvalidSetExpression( typeof( T ).FullName );
         }

         var propertyInfo = memberExpression.Member.ReflectedType.GetProperty( memberExpression.Member.Name, BindingFlags.Public | BindingFlags.Instance );

         if ( propertyInfo == null )
         {
            ThrowInvalidSetExpression( typeof( T ).FullName );
         }

         if ( propertyInfo.GetSetMethod() == null )
         {
            ThrowInvalidSetExpression( typeof( T ).FullName );
         }

         return memberExpression.Member.Name;
      }

      private static void ThrowInvalidSetExpression( string typeName )
      {
         string message = string.Format( Resources.InvalidSetExpression, typeName );
         throw new InvalidSetExpressionException( message );
      }
   }
}
