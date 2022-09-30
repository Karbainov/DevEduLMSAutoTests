Feature: CheckWorkWithHomework

A short summary of the feature

@teacher @student @manager
Scenario: Assigned homework by teacher, turned in by student
	Given Register new users with roles
	| FirstName | LastName | Patronymic | Email                | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role      |
	| Andrey1   | Baikov   | string     | Andrey21@student.com | Andrey   | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student   |
	| Lera      | Puzikova | string     | lera21@methodist.com | lera     | password | SaintPetersburg | 31.01.2000 | string        | 89817051892 | Methodist |
	| Vitya     | Strashko | string     | vitya21@teacher.com  | vitya    | password | SaintPetersburg | 01.08.1995 | string        | 89817051893 | Teacher   |
	And Create new groups
	| Name          | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest   | Базовый C# | Forming       | 26.08.2022 | 26.08.2023 | string    | 5000            | 10            |
	And Add users to group "GropForTest"
	| FirstName | LastName | Role    |
	| Vitya     | Strashko | Teacher |
	| Andrey1   | Baikov   | Student |
	When Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as methodist
	| Email                | Password |
	|lera21@methodist.com  | password |
	And Methodist click button homework
	And Methodist click button add homework
	And Methodist create homework course name "QA Automation"
	| Name           | Description | Link             |
	| ЗаданиеЗадание | string      | http://fjfjf.com |
	And Methodist logged out
	And Authorize user in service as teacher
	| Email               | Password | 
	| vitya21@teacher.com | password |
	And Teacher lays out the task "ЗаданиеЗадание" created by the methodologist 
	And Teacher create issuing homework course name "QA Automation"
	| Name           | Description  | Link             | StartDate  | EndDate    |
	| ЗаданиеЗадание | сделай то то | http://fjfjf.com | 30.09.2022 | 31.12.2022 |
	Then Teacher click button publish 
	When Teacher see all task
	And Teacher logged out
	And Authorize user in service as student 
	| Email                | Password |
	| Andrey21@student.com | password |
	And Student click button homework
	And Studen click button to the task
	And Studen attaches a link "https://hd.kinopoisk.ru/" to the completed task
	And Studen click airplane icon
	And Student logged out
	And Authorize user in service as teacher
	| Email                 | Password   |
	| vitya21@teacher.com   | password   |
	And Teacher checks homework 
	And Teacher returned homework
	And Teacher logged out
	And Authorize user in service as student
	| Email                | Password |
	| Andrey21@student.com | password |
	And Student attached link "https://hd.kinopoisk.ru/" of corrected homework
	And Student logged out
	And Authorize user in service as teacher
	| Email                 | Password   |
	| vitya21@teacher.com   | password   |
	Then Teacher accepted homework

@teacher @student @manager @methodist
Scenario:  Creating an assignment by a methodologist for students
	Given Register new users with roles
	| FirstName | LastName | Patronymic | Email                | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role      |
	| Milana    | Maxina   | string     | milana@student.com   | mila     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student   |
	| Lera      | Puzikova | string     | lera21@methodist.com | lera     | password | SaintPetersburg | 31.01.2000 | string        | 89817051892 | Methodist |
	| Vitya     | Strashko | string     | vitya21@teacher.com  | vitya    | password | SaintPetersburg | 01.08.1995 | string        | 89817051893 | Teacher   |
	When Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as methodist
	| Email                | Password     | 
	| lera21@methodist.com | password     | 
	And Methodist click button add task
	And Methodist create draft Homework course name "QA Automation"
	| Name           | Description | Link             |
	| ЗаданиеЗадание | string      | http://fjfjf.com |
	And Methodist click button save as draft
	And Methodist see all created homeworks
	And Methodist click edit
	And Methodist edits homework
	And Methodist click button save draft
	And Methodist logged out
	And Authorize user in service as teacher
	| Email                |  Password | 
	|  vitya21@teacher.com |  password |
	And Teacher click button homework assignment
	And Teacher fill out a new assignment form course name "QA Automation"
	|Name            | Description      | Link             |StartDate  | EndDate   |
	| ЗаданиеЗадание | сделай то то     |http://fjfjf.com  |30.09.2022 | 31.12.2022|
	And Teacher click button publish
	And Teacher logged out
	And Authorize user in service as student
	| Email              | Password |
	| milana@student.com | password |
	Then Student should sees homework