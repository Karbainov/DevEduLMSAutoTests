Feature: CreatingHomeworkByMethodologist

A short summary of the feature

@teacher @student @manager @methodist
Scenario:  Creating an assignment by a methodologist for students
	Given Administrator registers new users with roles
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate   | GitHubAccount | PhoneNumber | Role      |
	| Milana    | Maxina   | string     | milana@student.com    | mila     | password | SaintPetersburg | 02.07.2000  | string        | 89817051890 | Student   |
	| Lera      | Puzikova | string     | lera21@methodist.com  | lera     | password | SaintPetersburg | 31.01.2000  | string        | 89817051892 | Methodist |
	| Vitya     | Strashko | string     | vitya21@teacher.com   | vitya    | password | SaintPetersburg | 01.08.1995  | string        | 89817051893 | Teacher   |
	When Open DevEdu site "https://piter-education.ru:7074/login"
	And Authorize user
	| Email                | Password     | 
	| lera21@methodist.com | password     | 
	And Methodist click button add task
	When Methodist create draft Homework course name "QA Automation"
	| Name           | Description | Link             |
	| ЗаданиеЗадание | string      | http://fjfjf.com |
	And Methodist click button save as draft
	When Methodist see all created homeworks
	And Methodist click edit
	When Methodist edits homework
	And Methodist click button save draft
	And User exit
	And Authorize user
	| Email                |  Password | 
	|  vitya21@teacher.com |  password |
	And Teacher click button homework assignment
	When Teacher fill out a new assignment form course name "QA Automation"
	|Name            | Description      | Link             |StartDate  | EndDate   |
	| ЗаданиеЗадание | сделай то то     |http://fjfjf.com  |20.09.2022 | 31.12.2022|
	And Teacher click button publish
	And User exit
	And Authorize user
	| Email              | Password |
	| milana@student.com | password |
	Then Student should sees homework






