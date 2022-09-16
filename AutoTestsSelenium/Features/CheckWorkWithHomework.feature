
Feature: CheckWorkWithHomework

A short summary of the feature

@teacher @student @manager
Scenario: Assigned homework by teacher, turned in by student
	When Register users with and assigned roles
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate   | GitHubAccount | PhoneNumber | Role      |
	| Ilya1     | Baikov   | string     | ilya21@student.com    | ilya     | password | SaintPetersburg | 02.07.2000  | string        | 89817051890 | Student   |
	| Lera      | Puzikova | string     | lera21@methodist.com  | lera     | password | SaintPetersburg | 31.01.2000  | string        | 89817051892 | Methodist |
	| Vitya     | Strashko | string     | vitya21@teacher.com   | vitya    | password | SaintPetersburg | 01.08.1995  | string        | 89817051893 | Teacher   |
	And Manager create new group
	| Name          | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest01 | 1370     | Forming       | 11.09.2022 | 31.12.2022 | string    | 1000            | 10            |
	When Manager add users to group
	Then Methodist create homework
	| Name           | Description | LinkToRecord     | 
	| ЗаданиеЗадание | string      | http://fjfjf.com |
	And Authorization user as teacher
	| Email             | Password |
	| vitya21@teacher.com | password |
	Then Teacher changes role
	And Teacher click button issuing homework
	When Teacher create issuing homework
	|Name            | Description      | LinkToRecord     |StartDate  | EndDate   |
	| ЗаданиеЗадание | сделай то то     |http://fjfjf.com  |20.09.2022 | 31.12.2022|
	Then Teacher click button publish 
	When Teacher see all task
	And Teacher click button exit
	And Student authorization 
	| Email               | Password |
	| ilya21@student.com   | password |
	And Student click button homework
	And Studen click button to the task
	When Studen attaches a link to the completed task
	| LinkToGitHub              |
	| https://hd.kinopoisk.ru/  |
	And Studen click airplane icon
	And Studen click button exit
	And Teacher checks homework 
	| Email                 | Password   |
	| vitya21@teacher.com   | password   |
	#дальше никак потому что проверять нечего, ничего не получает препод
	Then Teacher returned homework
	And Student attached link of corrected homework
	Then Teacher accepted homework







