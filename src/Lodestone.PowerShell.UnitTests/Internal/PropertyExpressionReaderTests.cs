using System;
using Xunit;
using FluentAssertions;
using Lodestone.PowerShell.Internal;

namespace Lodestone.PowerShell.UnitTests.Internal
{
   public class PropertyExpressionReaderTests
   {
      [Fact]
      public void GetName_ExpressionRefersToProperty_GetPropertyName()
      {
         string name = PropertyExpressionReader.GetName<DateTime, int>( dt => dt.Hour );

         name.Should().Be( nameof( DateTime.Hour ) );
      }

      [Fact]
      public void GetName_ExpressionRefersToLiteralValue_ThrowsInvalidSetExpressionException()
      {
         Action getName = () => PropertyExpressionReader.GetName<DateTime, int>( dt => 5 );

         getName.ShouldThrow<InvalidSetExpressionException>();
      }
   }
}
