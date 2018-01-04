using System;
using Xunit;
using FluentAssertions;
using Lodestone.PowerShell.Internal;
using Lodestone.PowerShell.UnitTests.CmdletStubs;

namespace Lodestone.PowerShell.UnitTests.Internal
{
   public class CmdletNameReaderTests
   {
      [Fact]
      public void ReadName_PassesNullType_ThrowsArgumentException()
      {
         Action readName = () => CmdletNameReader.ReadName( null );

         readName.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void ReadName_PassesWellFormedCmdletType_ReturnsCmdletName()
      {
         string name = CmdletNameReader.ReadName( typeof( GetResourceStub ) );

         name.Should().Be( "Get-Resource" );
      }
   }
}
