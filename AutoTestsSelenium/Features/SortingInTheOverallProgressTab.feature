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
	And Create new task
	| Name  | Description | Links  | IsRequired |
	| Apple | Lemon       | string | true       |
	And Add new homeworks
	| StartDate  | EndDate    |
    | 01.10.2022 | 25.10.2022 |
	Given Students authorize and send their homework
	| Email              | Password | String         |
	| kroko@gmail.com    | password | link@razdva.ru |
	| bukin@student.com  | password | link@razdva.ru |
	| golub@student.com  | password | link@razdva.ru |
	| yula@student.com   | password | link@razdva.ru |
	| kraska@student.com | password | link@razdva.ru |
	Given Accept three homeworks and decline two
	Given Open DevEdu web site https://piter-education.ru:7074/
	Given Authorize user in service as teacher
	| Email             | Password |
	| witch@teacher.com | password |
	Given Teacher go to common progress
	When Teacher sort students by sername
	Then Students should sort by sername
