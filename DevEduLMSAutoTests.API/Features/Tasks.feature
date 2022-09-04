Feature: Tasks

The methodist creates a task, edits it.
The teacher posts this task.
The student sees it.

@methodist @admin @teacher @student @task @homework
Scenario: Add new task for students by methodist
	Given register new users with roles
	| FirstName | LastName   | Patronymic | Email                 | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role      |
	| Ilya      | Baikov     | string     | ilya075@student.com   | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Maksim    | Karbainov  | string     | ilya076@methodist.com | maksim1  | password | SaintPetersburg | 01.01.1995 | string        | 89997776655 | Methodist |
	| Elisey    | Kakoyto    | string     | ilya077@techer.com    | elisey1  | password | SaintPetersburg | 02.02.1996 | string        | 89996665544 | Teacher   |
	| Anton     | Efremenkov | string     | ilya078@tutor.com     | anton1   | password | SaintPetersburg | 03.03.1994 | string        | 89995554433 | Tutor     |
	And manager create new group
	| Name         | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest1 | 1370     | Forming       | 26.08.2022 | 26.08.2023 | string    | 5000            | 10            |
	And manager add users to group
	And methodist create new task
	| Name | Description | Links | IsRequired | CourseIds |
	| Test | Test        | Link  | true       | 1370      |
	And methodist update task
	| Name | Description | Links | IsRequired |
	| 1    | 2           | 3     | true       |
	#When teacher see task by groupId
	When teacher sees task by id
	And teacher post task
	| StartDate  | EndDate    |
	| 15.09.2022 | 30.09.2022 |
	Then student should sees task
