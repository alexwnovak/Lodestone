using System;
using Xunit;
using FluentAssertions;
using Lodestone.PowerShell.Internal;

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
   }
}
