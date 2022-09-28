Feature: GroupsAPI

A short summary of the feature

@manager @teacher @tutor @student
Scenario: Manager creates a group adds students and appoints a teacher and tutor
    Given register new users with roles in service
    | FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
    | Isabella  | Abramson   | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
    | Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
    | Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
    When manager create new group in service
    | Name    | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
    | BaseSPb | 1370     | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
    And manager add users to group in service
    Then authorize users in service and check group