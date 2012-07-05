Feature: Editing pay periods
As a user, when I have created a pay period, I should be able to edit it

Scenario: Edit existing pay period
Given I have a new system with pay periods
| Name     | StartDate | EndDate  |
| JuneTest | 1/1/2012  | 2/2/2012 |
When I view existing pay periods
And I click to edit JuneTest
