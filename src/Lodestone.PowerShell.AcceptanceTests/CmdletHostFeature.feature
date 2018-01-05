Feature: CmdletHost Feature
   As a PowerShell cmdlet author
   I want to run my cmdlet in isolation
   So I can ensure that all the components integrate correctly

@Acceptance
Scenario: Running a cmdlet with a simple return value
   When I host and run the ReturnFive cmdlet
   Then it should return 5
