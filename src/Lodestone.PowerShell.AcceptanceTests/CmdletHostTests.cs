using Lodestone.PowerShell.AcceptanceTests.CmdletStubs;
using Xunit;
using FluentAssertions;

namespace Lodestone.PowerShell.AcceptanceTests
{
   public class CmdletHostTests
   {
      [Fact]
      public void CmdletCanWriteSimpleValueToPipeline()
      {
         CmdletHost.For<GetFive>().Run().Should().Be( 5 );
      }

      [Fact]
      public void CmdletReceivesAnArgumentAndWritesItToPipeline()
      {
         CmdletHost.For<ConcatString>()
            .With( cs => cs.Value, "Argument" )
            .Run()
            .Should()
            .Be( "Received Argument" );

      }
   }
}
