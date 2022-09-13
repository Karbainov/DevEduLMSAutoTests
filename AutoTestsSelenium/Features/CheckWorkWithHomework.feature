
Feature: CheckWorkWithHomework

A short summary of the feature

@teacher @student @manager
Scenario: Assigned homework by teacher, turned in by student
	When register users with and assigned roles
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate   | GitHubAccount | PhoneNumber | Role      |
	| Ilya1     | Baikov   | string     | ilya21@student.com    | ilya     | password | SaintPetersburg | 02.07.2000  | string        | 89817051890 | Student   |
	| Lera      | Puzikova | string     | lera21@methodist.com  | lera     | password | SaintPetersburg | 31.01.2000  | string        | 89817051892 | Methodist |
	| Vitya     | Strashko | string     | vitya21@teacher.com   | vitya    | password | SaintPetersburg | 01.08.1995  | string        | 89817051893 | Teacher   |
	And manager create new group
	| Name          | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest01 | 1370     | Forming       | 11.09.2022 | 31.12.2022 | string    | 1000            | 10            |
	When manager add users to group
	Then methodist create homework
	| Name           | Description | LinkToRecord     | 
	| ЗаданиеЗадание | string      | http://fjfjf.com |
	And authorization user as teacher
	| Email             | Password |
	| vitya21@teacher.com | password |
	And teacher click button issuing homework
	Then teacher changes role
	When teacher create issuing homework
	|Name            | Description      | LinkToRecord     |StartDate  | EndDate   |
	| ЗаданиеЗадание | сделай то то     |http://fjfjf.com  |20.09.2022 | 31.12.2022|
	Then teacher click button publish 
	When teacher see all task
	And teacher click button exit
	And student authorization 
	| Email               | Password |
	| ilya21@student.com   | password |
	And student click button homework
	And studen click button to the task
	When studen attaches a link to the completed task
	| LinkToGitHub              |
	| https://hd.kinopoisk.ru/  |
	And studen click airplane icon
	And studen click button exit
	And teacher checks homework 
	| Email                 | Password   |
	| vitya21@teacher.com   | password   |
	#дальше никак потому что проверять нечего, ничего не получает препод







