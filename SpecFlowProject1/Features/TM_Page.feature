Feature: This feature file contains test cases for Time and material apge
1.Create new Time and material page
2. Edit exixting time and material page
3. Delete time and materail page



Scenario Outline: This test verify use is able to create new Time and material record
Given User is able to login into the turn up portal <username> <password>
When User navigates to TM page
And User create new Time record <code> <description> <price>
Then The new Time record get saved successfully.
Examples: 
| username | password | code  | description | price |
| 'hari'   | '123123' | 'ABC' | 'Specflow 1'  | 20   |
| 'hari'   | '123123' | 'PQR' | 'Specflow 2'  | 30   |
| 'hari'   | '123123' | 'XYZ' | 'Specflow 3'  | 40   |






Scenario: B. This test verify user is able to edit the Time and material record
Given User is able to login into the turn up portal
When User navigates to TM page
And User edits new Time record
Then The edited Time record get saved successfully.

Scenario: C. This test verify user is able to delete the Time and material record
Given User is able to login into the turn up portal
When User navigates to TM page
And User delete the Time record
Then The Time record gets deleted successfully.