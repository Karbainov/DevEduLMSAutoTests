﻿Feature: SortingInTheOverallProgressTab

A short summary of the feature

@teacher
Scenario: Sort by surname
	Given Administrator registers new users with roles
	| FirstName | LastName   | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Gennadiy  | Krokodilov | string     | kroko@gmail.com    | Gena     | password | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Gennadiy  | Bukin      | string     | bukin@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Golub      | string     | golub@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Yula       | string     | yula@student.com   | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Akril      | string     | kraska@student.com | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Serafima  | Pekova     | string     | witch@teacher.com  | Sera     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Teacher |
	And Admin create new groups
	| Name   | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| BlaBla | 2371     | Forming       | 08.09.2022 | 15.04.2023 | Morning   | 900             | 20            |
	And Admin add users to group "BlaBla"
	| FirstName | LastName   | Role    |
	| Gennadiy  | Krokodilov | Student |
	| Gennadiy  | Bukin      | Student |
	| Gennadiy  | Golub      | Student |
	| Gennadiy  | Yula       | Student |
	| Gennadiy  | Akril      | Student |
	| Serafima  | Pekova     | Teacher |
	And Admin create new task
	| Name  | Description | Links  | IsRequired |
	| Apple | Lemon       | string | true       |

@teacher
Scenario: Teacher sorts students by status
	Given Administrator registers new users with roles
	| FirstName | LastName   | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Isabella  | Abramson   | string     | isi@gmail.com      | Bella    | password | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Lilya     | Baikov     | string     | lil@student.com    | Lil      | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Diana     | Noname     | string     | ilya2@student.com  | ilya2    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Valya     | Baikova    | string     | ilya3@student.com  | ilya3    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Fakunto   | Arano      | string     | ilya4@student.com  | ilya4    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Lolo      | Nabokova   | string     | ilya5@student.com  | ilya5    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Maksim    | Karbainov  | string     | maks@teacher.com   | Maksim   | password | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Admin create new groups
	| Name            | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| Паровозик любви | 1370     | Forming       | 25.09.2022 | 30.01.2023 | string    | 5000            | 10            |
	And Admin add users to group "Паровозик любви"
	| FirstName | LastName   | Role    |
	| Isabella  | Abramson   | Student |
	| Lilya     | Baikov     | Student |
	| Diana     | Noname     | Student |
	| Valya     | Baikova    | Student |
	| Fakunto   | Arano      | Student |
	| Lolo      | Nabokova   | Student |
	| Maksim    | Karbainov  | Teacher |
	When Open DevEdu site https://piter-education.ru:7074/login
	And Authorize user
	| Email            | Password |
	| maks@teacher.com | password |
	When Teacher create new homework for new group "Паровозик любви"
	| Name  | Description  | Link                     | StartDate  | EndDate    |
	| QeQe | LubluDushit  | https://hd.kinopoisk.ru/ | 26.09.2022 | 28.09.2022 |
	And User exit
	And Students did their homework "QeQe"
	| Email             | Password |
	| isi@gmail.com     | password |
	| lil@student.com   | password |
	| ilya2@student.com | password |
	| ilya3@student.com | password |
	| ilya4@student.com | password |
	| ilya5@student.com | password |
	And Authorize user
	| Email            | Password |
	| maks@teacher.com | password |
	And Teacher rate homeworks
	|  Email            | Result	|
	| Isabella Abramson | Сдано		|
	| Lilya Baikov      | Сдано     |
	| Diana Noname      | не сдано  |
	| Valya  Baikova    | Сдано		|
	| Fakunto Arano     | Сдано		|
	| Lolo Nabokova     | не сдано	|
	And Teacher should see students results to homework in tab General Progress	
	When Teacher click ascending sorting in a column "Покрыть"
	#не длинное ли описание
	Then Teacher see list after sort
	And Teacher click descending sorting in a column "Покрыть"
	Then Teacher see list after sort
