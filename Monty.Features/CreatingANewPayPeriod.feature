Feature: Creating a new pay period
As a user, when I start up the application, I should be able to create a new pay period

Scenario: Create a new pay period
Given I have a new system with no pay periods
And I launch Monty
And I click Pay Periods
When I click New Pay Period
And I create pay period
| Name     | StartDate | EndDate  |
| JuneTest | 1/1/2012  | 2/2/2012 |
Then I should see JuneTest in the existing pay periods