Feature: SortingInTheOverallProgressTab

Teacher sort students progress by surname

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
	And Admin add new homework
	| StartDate  | EndDate    |
    | 01.10.2022 | 25.10.2022 |
	Given Students authorize
	| Email              | Password |
	| kroko@gmail.com    | password |
	| bukin@student.com  | password |
	| golub@student.com  | password |
	| yula@student.com   | password |
	| kraska@student.com | password |
	And Students send their homework
	| string         |
	| link@razdva.ru |
	| link@razdva.ru |
	| link@razdva.ru |
	| link@razdva.ru |
	| link@razdva.ru |
	Given Admin accept three homeworks and decline two
	Given Open a browser and open login page
	Given Teacher authorize
	| Email             | Password |
	| witch@teacher.com | password |
	Given Teacher go to common progress
	When Teacher sort students by sername
	Then Students should sort by sername
