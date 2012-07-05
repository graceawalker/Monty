Feature: Creating a new pay period
As a user, when I start up the application, I should be able to create a new pay period

Scenario: Create a new pay period
Given I have a new system with no pay periods
And I launch Monty
And I click Pay Periods
When I click Create New
And I create pay periods
| Name     | StartDate | EndDate  |
| JuneTest | 1/1/2012  | 2/2/2012 |
Then I should see JuneTest in the existing pay periods

Scenario: Create multiple pay periods
Given I have a new system with no pay periods
And I launch Monty
And I click Pay Periods
When I click Create New
And I create pay periods
| Name     | StartDate | EndDate  |
| JuneTest | 1/1/2012  | 2/2/2012 |
| July     | 2/2/2012  | 4/4/2012 |
Then I should see JuneTest in the existing pay periods
And I should see July in the existing pay periods