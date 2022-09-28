Feature: Payment

A short summary of the feature

@manager
Scenario: Add payments by manager
Given register as user
    | FirstName | LastName  | Patronymic | Email                          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
    | Alex      | Smith     | string     | mister5@student.com            | mister   | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 |
    And authorize as manager
    | Email                 | Password     |
    | marina@example.com    | marinamarina |
    And manager add payment to student user 
    | Date           | Sum     | IsPaid |
    | 01.02.2001     |  2000   |  true  |
    And manager can see this payment 
    And manager updates this payment 
    | Date           | Sum     | IsPaid |
    | 03.02.2021     |  3000   |  true  |
    And manager can see the updated payment
    And manager delete this payment 
    And manager can see that the payment deleted 