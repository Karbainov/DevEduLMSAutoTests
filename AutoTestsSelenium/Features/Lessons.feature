Feature: Lessons

A short summary of the feature

@tag1
Scenario: Teacher create lesson as draft, save it and publish.
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Gennadiy  | Krokodilov | string     | kroko@gmail.com    | Gena     | password | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Gennadiy  | Bukin      | string     | bukin@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Golub      | string     | golub@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
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
	Given Open DevEdu web site
	Given Authorize user in service as teacher
	| Email             | Password |
	| witch@teacher.com | password |
	And Click on create lesson

