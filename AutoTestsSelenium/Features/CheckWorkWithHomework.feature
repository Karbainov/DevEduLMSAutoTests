Feature: CheckWorkWithHomework

A short summary of the feature

@tag1
Scenario: Assigned homework by teacher, turned in by student
	Given Open DevEdu web page
	When authorization user as manager
	| Email                 | Password     |
	|  marina@example.com   | marinamarina |
	And manager create new groups
	| Name          | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest01 | 1370     | Forming       | 27.08.2022 | 31.12.2022 | string    | 1000            | 10            |
	And manager add studant in new group
	And manager add teacher in new group
	Then authorization user as teacher
	| Email                 | Password     |
	| anton@example.com     | antonanton   |
	And teacher click botton to come in
	And teacher click button homework
	When teacher click button add task
	And teacher create homework
	| Name|  | Description | LinkToRecord |
	Then teacher click buttom publish
	And teacher click button 
	When see all task
	And teacher click button exit
	And student authorization 
	|Email              | Password   |
	| stepa@example.com | stepastepa |
	And student click button homework
	And  studen click button to the task
	When studen attaches a link to the completed task
	| link                        |
	| https://hd.kinopoisk.ru/    |
	And studen click airplane icon
	And studen click button exit
	And authorization user as teacher
	| Email                 | Password     |
	| anton@example.com     | antonanton   |
	And teacher click botton to come in
	And teacher click button checking assignments 
	#дальше никак потому что проверять нечего, ничего не получает препод




