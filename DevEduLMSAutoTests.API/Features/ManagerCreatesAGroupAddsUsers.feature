Feature: ManagerCreatesAGroupAddsUsers

A short summary of the feature

@manager @teacher @tutor @student
Scenario: Manager creates a group adds students and appoints a teacher and tutor
Given register new users in service
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Gabriel   | Wilson     | string     | wl@gmail.com     | Gabi     | 11345678 | SaintPetersburg | 15.04.1999 | string        | 89514781247 | Student |
| Isabella  | Abramson   | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
| Sophie    | Anderson   | string     | sophie@gmail.com | Sophi    | 11344678 | SaintPetersburg | 18.01.1998 | string        | 89511781247 | Student |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Anton     | Efremenkov | string     | anton@gmail.com  | Anton    | 22345698 | SaintPetersburg | 22.08.1988 | string        | 89521477531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
And authorize manager in service
| Email              | Password     |
| marina@example.com | marinamarina |
And manager add roles to users in service
When manager create new group in service
| Name    | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
| BaseSPb | 1370     | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
And manager add users to group in service
Then authorize users in service
| Email            | Password |
| wl@gmail.com     | 11345678 |
| isi@gmail.com    | 11345578 |
| sophie@gmail.com | 11344678 |
| maks@gmail.com   | 22345678 |
| anton@gmail.com  | 22345698 |
| elisey@gmail.com | 13345678 |
And check the user's group in service