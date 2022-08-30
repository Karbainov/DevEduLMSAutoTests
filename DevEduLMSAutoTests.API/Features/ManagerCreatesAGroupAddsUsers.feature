Feature: ManagerCreatesAGroupAddsUsers

A short summary of the feature

@manager
Scenario: Manager creates a group adds students and appoints a teacher and tutor
Given register new users in the service
| FirstName | LastName  | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
| Gabriel   | Wilson    | string     | wl2@gmail.com     | Gabi     | 11345678 | SaintPetersburg | 15.04.1999 | string        | 89514781247 |
| Isabella  | Abramson  | string     | isi2@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 |
| Sophie    | Anderson  | string     | sophie2@gmail.com | Sophi    | 11344678 | SaintPetersburg | 18.01.1998 | string        | 89511781247 |
| Maksim    | Karbainov | string     | maks2@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 |
| Elisey    | Kakoyto   | string     | elisey2@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 |
And authorize manager in servise
| Email              | Password     |
| marina@example.com | marinamarina |
And manager add roles to users in service
When manager create new group in service
| Name    | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
| BaseSPb | 1370     | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
And manager add users to group in service
Then authorize users in service
| Email            | Password |
| wl2@gmail.com     | 11345678 |
| isi2@gmail.com    | 11345578 |
| sophie2@gmail.com | 11344678 |
| maks2@gmail.com   | 22345678 |
| elisey2@gmail.com | 13345678 |
And check the user's group in service