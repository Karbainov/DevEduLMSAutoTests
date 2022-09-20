Feature: SpecialTwoPointFive

A short summary of the feature

@tag1
Scenario:  Creating an assignment by a methodologist for students
	When Register users with roles
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate   | GitHubAccount | PhoneNumber | Role      |
	| Milana    | Maxina   | string     | milana@student.com    | mila     | password | SaintPetersburg | 02.07.2000  | string        | 89817051890 | Student   |
	| Lera      | Puzikova | string     | lera21@methodist.com  | lera     | password | SaintPetersburg | 31.01.2000  | string        | 89817051892 | Methodist |
	| Vitya     | Strashko | string     | vitya21@teacher.com   | vitya    | password | SaintPetersburg | 01.08.1995  | string        | 89817051893 | Teacher   |
	And Authorization user as methodist
	| Email                | Password     | Role        |
	| lera21@methodist.com | password     | Methodist   |
	And Methodist click button add task
	When Methodist create draft Homework
	| CourseName   | Name           | Description | Link             |
	| QA Automation| ЗаданиеЗадание | string      | http://fjfjf.com |
	Then Methodist click button save as draft
	When Methodist see all created homeworks
	And Methodist click link edit
	When Methodist edits homework
	Then Methodist click button save draft
	And Teacher authorization
	| Email                |  Password | Role    |
	|  vitya21@teacher.com |  password | Teacher |
	And Teacher click button homework assignment
	When Teacher fill out a new assignment form
	|Name            | Description      | Link             |StartDate  | EndDate   |
	| ЗаданиеЗадание | сделай то то     |http://fjfjf.com  |20.09.2022 | 31.12.2022|
	And Teacher click button publish
	Then Student should sees homework
	| Email              | Password |
	| milana@student.com | password |






