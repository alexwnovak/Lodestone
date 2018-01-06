using System;
using Xunit;
using FluentAssertions;
using Lodestone.PowerShell.Internal;
using Lodestone.PowerShell.UnitTests.Stubs;

namespace Lodestone.PowerShell.UnitTests.Internal
{
   public class PropertyExpressionReaderTests
   {
      [Fact]
      public void GetName_ExpressionRefersToProperty_GetPropertyName()
      {
         string name = PropertyExpressionReader.GetName<PropertyStub, int>( ps => ps.ValidProperty );

         name.Should().Be( nameof( PropertyStub.ValidProperty ) );
      }

      [Fact]
      public void GetName_ExpressionRefersToLiteralValue_ThrowsInvalidSetExpressionException()
      {
         Action getName = () => PropertyExpressionReader.GetName<DateTime, int>( dt => 5 );

         getName.ShouldThrow<InvalidSetExpressionException>();
      }

      [Fact]
      public void GetName_ExpressionRefersToMethod_ThrowsInvalidSetExpressionException()
      {
         Action getName = () => PropertyExpressionReader.GetName<DateTime, int>( dt => dt.GetHashCode() );

         getName.ShouldThrow<InvalidSetExpressionException>();
      }

      [Fact]
      public void GetName_ExpressionRefersToPublicField_ThrowsInvalidSetExpressionException()
      {
         Action getName = () => PropertyExpressionReader.GetName<PropertyStub, int>( ps => ps.PublicField );

         getName.ShouldThrow<InvalidSetExpressionException>();
      }

      [Fact]
      public void GetName_ExpressionRefersToNonPublicProperty_ThrowsInvalidSetExpressionException()
      {
         Action getName = () => PropertyExpressionReader.GetName<PropertyStub, int>( ps => ps.InternalProperty );

         getName.ShouldThrow<InvalidSetExpressionException>();
      }

      [Fact]
      public void GetName_ExpressionRefersToStaticProperty_ThrowsInvalidSetExpressionException()
      {
         Action getName = () => PropertyExpressionReader.GetName<PropertyStub, string>( ps => PropertyStub.StaticProperty );

         getName.ShouldThrow<InvalidSetExpressionException>();
      }

      [Fact]
      public void GetName_ExpressionRefersToPropertyWithGetterOnly_ThrowsInvalidSetExpressionException()
      {
         Action getName = () => PropertyExpressionReader.GetName<PropertyStub, int>( ps => ps.GetterOnlyProperty );

         getName.ShouldThrow<InvalidSetExpressionException>();
      }

      [Fact]
      public void GetName_ExpressionRefersToAnotherObjectsPropertyWithSameName_ThrowsInvalidSetExpressionException()
      {
         var otherStub = new PropertyStub2();

         Action getName = () => PropertyExpressionReader.GetName<PropertyStub, int>( ps => otherStub.ValidProperty );

         getName.ShouldThrow<InvalidSetExpressionException>();
      }
   }
}
