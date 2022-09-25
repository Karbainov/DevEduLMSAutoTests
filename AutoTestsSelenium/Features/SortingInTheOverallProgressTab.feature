﻿Feature: SortingInTheOverallProgressTab

A short summary of the feature

@tag1
Scenario: Teacher sorts students by last name or status
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Isabella  | Abramson   | string     | isi@gmail.com      | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Lilya     | Baikov     | string     | lil@student.com    | Lil      | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Diana     | Noname     | string     | ilya2@student.com  | ilya2    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Valya     | Baikova    | string     | ilya3@student.com  | ilya3    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Fakunto   | Arano      | string     | ilya4@student.com  | ilya4    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Lolo      | Nabokova   | string     | ilya5@student.com  | ilya5    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Maksim    | Karbainov  | string     | maks@teacher.com   | Maksim   | password | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Manager create new group
	| Name          | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GroupForTest1 | 1370     | Forming       | 15.10.2022 | 30.01.2023 | string    | 5000            | 10            |
	And Manager add users to group "GroupForTest1"
	| FirstName | LastName   | Role    |
	| Isabella  | Abramson   | Student |
	| Lilya     | Baikov     | Student |
	| Diana     | Noname     | Student |
	| Valya     | Baikova    | Student |
	| Fakunto   | Arano      | Student |
	| Lolo      | Nabokova   | Student |
	| Maksim    | Karbainov  | Teacher |
	And  Open DevEducation site 
	When Teacher authorization on the site DevEdu
	| FirstName        | LastName |
	| maks@teacher.com | password |
	When Teacher create new homework
	| Name  | Description  | Link                     | StartDate  | EndDate    |
	| Lists | LubluDushit  | https://hd.kinopoisk.ru/ | 15.10.2022 | 16.10.2022 |
	Then Teacher click exit
	And Students send links to them 
	| Email             | Password |
	| isi@gmail.com     | password |
	| lil@student.com   | password |
	| ilya2@student.com | password |
	| ilya3@student.com | password |
	| ilya4@student.com | password |
	| ilya5@student.com | password |
	And Teacher authorization
	| FirstName        | LastName |
	| maks@teacher.com | password |
	And Teacher rate homeworks
	| FullName          | Result	|
	| Isabella Abramson | Сдано		|
	| Lilya Baikov      | Сдано     |
	| Diana Noname      | не сдано  |
	| Valya  Baikova    | Сдано		|
	| Fakunto Arano     | Сдано		|
	| Lolo Nabokova     | не сдано	|
	Then Teacher should see students results in homewok tab
	| FullName          | Result	|
	| Isabella Abramson | Сдано		|
	| Lilya Baikov      | Сдано     |
	| Diana Noname      | не сдано  |
	| Valya  Baikova    | Сдано		|
	| Fakunto Arano     | Сдано		|
	| Lolo Nabokova     | не сдано	|
	And Teacher should see students results in tab General Progress
	| FullName          | Result	|
	| Isabella Abramson | Сдано		|
	| Lilya Baikov      | Сдано     |
	| Diana Noname      | не сдано  |
	| Valya  Baikova    | Сдано		|
	| Fakunto Arano     | Сдано		|
	| Lolo Nabokova     | не сдано	|
	Then Teacher click sorting in a column ArrayList
