using System;
using TechTalk.SpecFlow;

namespace Lodestone.PowerShell.AcceptanceTests.Steps
{
   [Binding]
   public class CmdletHostFeatureSteps
   {
      [When( @"I run host the ReturnFive cmdlet" )]
      public void WhenIRunHostTheReturnFiveCmdlet()
      {
         
         ScenarioContext.Current.Pending();
      }

      [Then( @"the it should return (.*)" )]
      public void ThenTheItShouldReturn( int expectedReturnValue )
      {
         ScenarioContext.Current.Pending();
      }
   }
}
