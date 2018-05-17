Feature: CmdletHost Feature
   As a PowerShell cmdlet author
   I want to run my cmdlet in isolation
   So I can ensure that all the components integrate correctly

@Acceptance
Scenario: Running a cmdlet that does string concatenation
   Given I host the ConcatString cmdlet
   And I pass Test for the value
   When I run the cmdlet
   Then it should return Received Test
