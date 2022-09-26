Feature: SpecialTwoPointFive

A short summary of the feature

@tag1
Scenario:  Creating an assignment by a methodologist for students
	Given Open DevEdu web page
	When authorization user as methodist
	| Email                 | Password     |
	| maksim@example.com    | maksimmaksim |
	And methodist click botton to come in
	And methodist click button add task
	When methodist create draft Homework
	|Name            | Description | LinkToRecord     |
	| ЗаданиеЗадание | string      |http://fjfjf.com  |
	Then methodist click button save as draft
	When methodist see all created homeworks
	And methodist click link edit
	When methodist edits homework
	Then methodist click button save draft
	And teacher authorization
	And teacher click button homework assignment
	When teacher fill out a new assignment form
	And teacher click button publish
	Then student should sees homework






