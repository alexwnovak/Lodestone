using FluentAssertions;
using Lodestone.PowerShell.AcceptanceTests.CmdletStubs;
using TechTalk.SpecFlow;

namespace Lodestone.PowerShell.AcceptanceTests.Steps
{
   [Binding]
   public class CmdletHostFeatureSteps
   {
      private int _returnValue;

      [When( @"I host and run the ReturnFive cmdlet" )]
      public void WhenIRunHostTheReturnFiveCmdlet()
      {
         _returnValue = (int) CmdletHost.For<ReturnFiveCmdlet>().Run();
      }

      [Then( @"it should return (.*)" )]
      public void ThenTheItShouldReturn( int expectedReturnValue )
      {
         _returnValue.Should().Be( 5 );
      }
   }
}
