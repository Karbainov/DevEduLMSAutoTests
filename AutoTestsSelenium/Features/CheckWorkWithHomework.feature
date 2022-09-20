
Feature: CheckWorkWithHomework

A short summary of the feature

@teacher @student @manager
Scenario: Assigned homework by teacher, turned in by student
	When Register users
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate   | GitHubAccount | PhoneNumber | Role      |
	| Ilya1     | Baikov   | string     | ilya21@student.com    | ilya     | password | SaintPetersburg | 02.07.2000  | string        | 89817051890 | Student   |
	| Lera      | Puzikova | string     | lera21@methodist.com  | lera     | password | SaintPetersburg | 31.01.2000  | string        | 89817051892 | Methodist |
	| Vitya     | Strashko | string     | vitya21@teacher.com   | vitya    | password | SaintPetersburg | 01.08.1995  | string        | 89817051893 | Teacher   |
	And Manager create new group
	| Name          | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest01 | 1370     | Forming       | 11.09.2022 | 31.12.2022 | string    | 1000            | 10            |
	When Manager add users to group
	And Methodist authorization on the site
	| Email                | Password |
	|lera21@methodist.com  | password |
	When Methodist click button homework
	And Methodist click button add homework
	Then Methodist create homework
	| CourseName    | Name           | Description | Link             |
	| QA Automation | ЗаданиеЗадание | string      | http://fjfjf.com |
	And Authorization user as teacher
	| Email               | Password | Role    |
	| vitya21@teacher.com | password | Teacher |
	Then Teacher lays out the task "ЗаданиеЗадание" created by the methodologist 
	When Teacher create issuing homework
	| CourseName    | Name           | Description  | Link             | StartDate  | EndDate    |
	| QA Automation | ЗаданиеЗадание | сделай то то | http://fjfjf.com | 20.09.2022 | 31.12.2022 |
	Then Teacher click button publish 
	When Teacher see all task
	And Student authorization 
	| Email               | Password |
	| ilya21@student.com   | password |
	And Student click button homework
	And Studen click button to the task
	When Studen attaches a link "https://hd.kinopoisk.ru/" to the completed task
	And Studen click airplane icon
	And Teacher checks homework 
	| Email                 | Password   |Role     |
	| vitya21@teacher.com   | password   | Teacher |
	Then Teacher returned homework
	When Student attached link "https://hd.kinopoisk.ru/" of corrected homework
	| Email              | Password | 
	| ilya21@student.com | password | 
	Then Teacher accepted homework
	| Email                 | Password   |Role     |
	| vitya21@teacher.com   | password   | Teacher |







