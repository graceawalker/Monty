Feature: Configuring Pay Period
A a user, in order to manage my accounts,
when I edit a pay period then the changes should be saved to the database

Scenario: Creating a pay period
Given I have a new system with pay periods
| Name     | StartDate  | EndDate    |
| JuneTest | 1/1/2012 | 2/2/2012 |
When I retrieve JuneTest from the database
Then It should have details
| Name     | StartDate  | EndDate    |
| JuneTest | 1/1/2012 | 2/2/2012 |

Scenario: Creating multiple pay periods
Given I have a new system with pay periods
| Name     | StartDate  | EndDate    |
| JuneTest | 1/1/2012 | 2/2/2012 |
| JulyTest | 3/3/2012 | 4/4/2012 |
When I retrieve all pay periods
Then They should have details
| Name     | StartDate  | EndDate    |
| JuneTest | 1/1/2012 | 2/2/2012 |
| JulyTest | 3/3/2012 | 4/4/2012 |

Scenario: Editing a pay period
Given I have a new system with pay periods
| Name     | StartDate  | EndDate    |
| JuneTest | 1/1/2012 | 2/2/2012 |
When I edit and save JuneTest with details
| Name          | StartDate  | EndDate    |
| JuneTestChange | 1/2/2012 | 2/3/2012 |
And I retrieve JuneTestChange from the database
Then It should have details
| Name           | StartDate | EndDate  |
| JuneTestChange | 1/2/2012  | 2/3/2012 |

Scenario: Deleting a pay period
Given I have a new system with pay periods
| Name     | StartDate  | EndDate    |
| JuneTest | 1/1/2012 | 2/2/2012 |
When I delete JuneTest
Then The pay period database should be empty