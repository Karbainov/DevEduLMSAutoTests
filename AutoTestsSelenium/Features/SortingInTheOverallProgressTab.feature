Feature: SortingInTheOverallProgressTab

Teacher sort students progress by surname

@teacher
Scenario: Sort by surname
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Gennadiy  | Krokodilov | string     | kroko@gmail.com    | Gena     | password | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Gennadiy  | Bukin      | string     | bukin@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Golub      | string     | golub@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Yula       | string     | yula@student.com   | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Akril      | string     | kraska@student.com | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Serafima  | Pekova     | string     | witch@teacher.com  | Sera     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Teacher |
	And Create new groups
	| Name   | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| BlaBla | 2371     | Forming       | 08.09.2022 | 15.04.2023 | Morning   | 900             | 20            |
	And Add users to group "BlaBla"
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
	And Admin add new homework
	| StartDate  | EndDate    |
    | 01.10.2022 | 25.10.2022 |
	Given Students authorize and send their homework
	| Email              | Password | String         |
	| kroko@gmail.com    | password | link@razdva.ru |
	| bukin@student.com  | password | link@razdva.ru |
	| golub@student.com  | password | link@razdva.ru |
	| yula@student.com   | password | link@razdva.ru |
	| kraska@student.com | password | link@razdva.ru |
	Given Admin accept three homeworks and decline two
	Given Open a browser and open login page
	Given Teacher authorize
	| Email             | Password |
	| witch@teacher.com | password |
	Given Teacher go to common progress
	When Teacher sort students by sername
	Then Students should sort by sername

@teacher
Scenario: Teacher sorts students by status
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Isabella  | Abramson   | string     | isi@gmail.com      | Bella    | password | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Lilya     | Baikov     | string     | lil@student.com    | Lil      | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Diana     | Noname     | string     | ilya2@student.com  | ilya2    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Valya     | Baikova    | string     | ilya3@student.com  | ilya3    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Fakunto   | Arano      | string     | ilya4@student.com  | ilya4    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Lolo      | Nabokova   | string     | ilya5@student.com  | ilya5    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Maksim    | Karbainov  | string     | maks@teacher.com   | Maksim   | password | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Create new groups
	| Name            | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| Паровозик любви | 1370     | Forming       | 25.09.2022 | 30.01.2023 | string    | 5000            | 10            |
	And Add users to group "Паровозик любви"
	| FirstName | LastName   | Role    |
	| Isabella  | Abramson   | Student |
	| Lilya     | Baikov     | Student |
	| Diana     | Noname     | Student |
	| Valya     | Baikova    | Student |
	| Fakunto   | Arano      | Student |
	| Lolo      | Nabokova   | Student |
	| Maksim    | Karbainov  | Teacher |
	When Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as teacher
	| Email            | Password |
	| maks@teacher.com | password |
	And Teacher create new homework for group "Паровозик любви"
	| Name  | Description  | Link                     | StartDate  | EndDate    |
	| QeQe | LubluDushit  | https://hd.kinopoisk.ru/  | 29.09.2022 | 01.10.2022 |
	And Teacher logged out
	And Students did their homework "QeQe"
	| Email             | Password |
	| isi@gmail.com     | password |
	| lil@student.com   | password |
	| ilya2@student.com | password |
	| ilya3@student.com | password |
	| ilya4@student.com | password |
	| ilya5@student.com | password |
	And Authorize user in service as teacher
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
	And Teacher open tab General Progress	
	When Teacher click ascending sorting in a column "Покрыть"
	Then Teacher should see list after sort on ABC
	| FukkName       | Result             |
	| Барабан Second | Не сдано           |
	| Ворона Амеба   | Проверить          |
	| Абрикос Филя   | Сдано с опозданием |
	And Teacher click descending sorting in a column "Покрыть"
	Then Teacher should see list after sort on CBA
	| FukkName       | Result             |
	| Абрикос Филя   | Сдано с опозданием |
	| Ворона Амеба   | Проверить          |
	| Барабан Second | Не сдано           |