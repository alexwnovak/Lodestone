using System.ComponentModel;
using TechTalk.SpecFlow;
using FluentAssertions;
using Lodestone.PowerShell.AcceptanceTests.CmdletStubs;

namespace Lodestone.PowerShell.AcceptanceTests.Steps
{
   [Binding]
   public class CmdletHostFeatureSteps
   {
      private HostFlow<ConcatStringCmdlet> _concatStringFlow;
      private object _returnValue;

      [StepArgumentTransformation]
      public object GenericTransform( object value )
      {
         if ( int.TryParse( value.ToString(), out int result ) )
         {
            return result;
         }

         return value;
      }

      [When( @"I host and run the ReturnFive cmdlet" )]
      public void WhenIRunHostTheReturnFiveCmdlet()
      {
         _returnValue = CmdletHost.For<ReturnFiveCmdlet>().Run();
      }

      [Given( @"I host the ConcatString cmdlet" )]
      public void GivenIHostTheConcatStringCmdlet()
      {
         _concatStringFlow = CmdletHost.For<ConcatStringCmdlet>();
      }

      [Given( @"I pass (.*) for the value" )]
      public void GivenIPassTestForTheValue( string value )
      {
         _concatStringFlow = _concatStringFlow.With( c => c.Value, value );
      }

      [When( @"I run the cmdlet" )]
      public void WhenIRunTheCmdlet()
      {
         _returnValue = _concatStringFlow.Run();
      }

      [Then( @"it should return (.*)" )]
      public void ThenTheItShouldReturn( object expectedReturnValue )
      {
         _returnValue.Should().Be( expectedReturnValue );
      }
   }
}
