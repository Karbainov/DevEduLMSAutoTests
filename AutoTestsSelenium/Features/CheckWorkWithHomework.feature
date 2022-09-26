
Feature: CheckWorkWithHomework

A short summary of the feature

@teacher @student @manager
Scenario: Assigned homework by teacher, turned in by student
	Given Register new users with roles
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate   | GitHubAccount | PhoneNumber | Role      |
	| Ilya1     | Baikov   | string     | ilya21@student.com    | ilya     | password | SaintPetersburg | 02.07.2000  | string        | 89817051890 | Student   |
	| Lera      | Puzikova | string     | lera21@methodist.com  | lera     | password | SaintPetersburg | 31.01.2000  | string        | 89817051892 | Methodist |
	| Vitya     | Strashko | string     | vitya21@teacher.com   | vitya    | password | SaintPetersburg | 01.08.1995  | string        | 89817051893 | Teacher   |
	And Create new groups
	| Name          | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest   | Базовый C# | Forming       | 26.08.2022 | 26.08.2023 | string    | 5000            | 10            |
	And Add users to group "GropForTest"
	| FirstName | LastName | Role    |
	| Vitya     | Strashko | Teacher |
	| Ilya1     | Baikov   | Student |
	When Open DevEdu site https://piter-education.ru:7074/login
	And Authorize user in service as methodist
	| Email                | Password |
	|lera21@methodist.com  | password |
	When Methodist click button homework
	And Methodist click button add homework
	And Methodist create homework course name "QA Automation"
	| Name           | Description | Link             |
	| ЗаданиеЗадание | string      | http://fjfjf.com |
	And Exit account as methodist
	When Authorize user in service as teacher
	| Email               | Password | 
	| vitya21@teacher.com | password |
	And Teacher lays out the task "ЗаданиеЗадание" created by the methodologist 
	And Teacher create issuing homework course name "QA Automation"
	| Name           | Description  | Link             | StartDate  | EndDate    |
	| ЗаданиеЗадание | сделай то то | http://fjfjf.com | 30.09.2022 | 31.12.2022 |
	Then Teacher click button publish 
	When Teacher see all task
	And Exit account as teacher
	And Authorize user in service as student 
	| Email               | Password |
	| ilya21@student.com  | password |
	And Student click button homework
	And Studen click button to the task
	When Studen attaches a link "https://hd.kinopoisk.ru/" to the completed task
	And Studen click airplane icon
	And Exit account as student
	And Authorize user in service as teacher
	| Email                 | Password   |
	| vitya21@teacher.com   | password   |
	And Teacher checks homework 
	When Teacher returned homework
	And Exit account as teacher
	And Authorize user in service as student
	| Email              | Password | 
	| ilya21@student.com | password | 
	When Student attached link "https://hd.kinopoisk.ru/" of corrected homework
	And Exit account as student
	And Authorize user in service as teacher
	| Email                 | Password   |
	| vitya21@teacher.com   | password   |
	Then Teacher accepted homework







