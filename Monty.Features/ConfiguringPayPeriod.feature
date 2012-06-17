Feature: Configuring Pay Period
A a user, in order to manage my accounts,
when I edit a pay period then the changes should be saved to the database


Scenario: Creating a pay period
Given I have a new system with pay periods
| Name     | StartDate  | EndDate    |
| JuneTest | 01/01/2012 | 02/02/2012 |
When I retrieve JuneTest from the database
Then It should have details
| Name     | StartDate  | EndDate    |
| JuneTest | 01/01/2012 | 02/02/2012 |

Scenario: Creating multiple pay periods
Given I have a new system with pay periods
| Name     | StartDate  | EndDate    |
| JuneTest | 01/01/2012 | 02/02/2012 |
| JulyTest | 03/03/2012 | 04/04/2012 |
When I retrieve all pay periods
Then They should have details
| Name     | StartDate  | EndDate    |
| JuneTest | 01/01/2012 | 02/02/2012 |
| JulyTest | 03/03/2012 | 04/04/2012 |

Scenario: Editing a pay period
Given I have a new system with pay periods
| Name     | StartDate  | EndDate    |
| JuneTest | 01/01/2012 | 02/02/2012 |
When I edit and save JuneTest with details
| Name          | StartDate  | EndDate    |
| JuneTestCange | 01/02/2012 | 02/03/2012 |
Then I should be able to retrieve JuneTest from the database with details
| Name          | StartDate  | EndDate    |
| JuneTestCange | 01/02/2012 | 02/03/2012 |

Scenario: Deleting a pay period
Given I have a new system with pay periods
| Name     | StartDate  | EndDate    |
| JuneTest | 01/01/2012 | 02/02/2012 |
When I delete JuneTest
Then The pay period database should be empty