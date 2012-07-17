Feature: Editing pay periods
As a user, when I have created a pay period, I should be able to edit it

Scenario: Edit existing pay period
Given I have a new system with pay periods
| Name     | StartDate | EndDate  |
| JuneTest | 1/1/2012  | 2/2/2012 |
When I view existing pay periods
And I edit JuneTest to July
Then I should see July in the existing pay periods

Scenario: Delete existing pay period
Given I have a new system with pay periods
| Name     | StartDate | EndDate  |
| JuneTest | 1/1/2012  | 2/2/2012 |
| JulyTest | 1/1/2012  | 2/2/2012 |
And I view existing pay periods
When I click Delete
Then I should not see JuneTest in the existing pay periods 

