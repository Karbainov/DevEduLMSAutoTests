Feature: CheckWorkWithHomework

A short summary of the feature

@teacher @student @manager
Scenario: Assigned homework by teacher, turned in by student
	Given Open the brouser and DevEdu web page
	When register users with and assigned roles
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate   | GitHubAccount | PhoneNumber | Role      |
	| Ilya1     | Baikov   | string     | ilya@student.com    | ilya     | password | SaintPetersburg | 02.07.2000  | string        | 89817051890 | Student   |
	| Milana    | Maxina   | string     | milana@student.com  | milana   | password | SaintPetersburg | 31.12.2000  | string        | 89817051891 | Student   |
	| Lera      | Puzikova | string     | lera@methodist.com  | lera     | password | SaintPetersburg | 31.01.2000  | string        | 89817051892 | Methodist |
	| Vitya     | Strashko | string     | vitya@teacher.com   | vitya    | password | SaintPetersburg | 01.08.1995  | string        | 89817051893 | Teacher   |
	And authorization user as manager
	| Email                 | Password     |
	|  marina@example.com   | marinamarina |
	And manager create new groups
	| Name          | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest01 | 1370     | Forming       | 11.09.2022 | 31.12.2022 | string    | 1000            | 10            |
	And manager add studant in new group
	And manager add teacher in new group
	Then manager click button exit
	Then authorization user as methodist
	| Email             | Password |
	| lera@methodist.com | password |
	And methodist click button homework
	When methodist click button add task
	And methodist create homework
	|Name            | Description | LinkToRecord     |
	| ЗаданиеЗадание | string      |http://fjfjf.com  |
	Then methodist click button save as draft
	And methodist see all created homeworks
	Then methoist click button exit
	And authorization user as teacher
	| Email             | Password |
	| vitya@teacher.com | password |
	And teacher click button issuing homework
	When teacher create issuing homework
	Then teacher click button publish 
	When see all task
	And teacher click button exit
	And student authorization 
	| Email               | Password |
	| ilya1@student.com   | password |
	| milana1@student.com | password |
	And student click button homework
	And  studen click button to the task
	When studen attaches a link to the completed task
	| link                        |
	| https://hd.kinopoisk.ru/    |
	And studen click airplane icon
	And studen click button exit
	And authorization user as teacher
	| Email                 | Password   |
	| vitya@teacher.com     | password   |
	And teacher click botton to come in
	And teacher click button checking assignments 
	#дальше никак потому что проверять нечего, ничего не получает препод




