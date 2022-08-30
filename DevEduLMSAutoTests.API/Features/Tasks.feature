﻿Feature: Tasks

A short summary of the feature

@methodist
Scenario: Add new task for students by methodist
	Given register new users
	| FirstName | LastName  | Patronymic | Email                 | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Ilya      | Baikov    | string     | ilya075@student.com   | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 |
	| Maksim    | Karbainov | string     | ilya076@methodist.com | maksim1  | password | SaintPetersburg | 01.01.1995 | string        | 89997776655 |
	| Elisey    | Kakoyto   | string     | ilya077@techer.com    | elisey1  | password | SaintPetersburg | 02.02.1996 | string        | 89996665544 |
	And authorize admin
	And manager add roles to users
	And authorize users
	| Email                 | Password     |
	| ilya075@student.com   | password     |
	| ilya076@methodist.com | password     |
	| ilya077@techer.com    | password     |
	And manager create new group
	| Name         | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest1 | 1370     | Forming       | 26.08.2022 | 26.08.2023 | string    | 5000            | 10            |
	And manager add users to group
	And methodist create new task
	| Name          | Description | Links | IsRequired | CourseIds |
	| FirstTaskTest | qweqwe      | link  | true       | 1370      |
	And methodist update task
	| Name    | Description | Links    | IsRequired |
	| NewName | qweqweqwe   | New link | true       |
	#When teacher see task
	When teacher sees task by id
	And teacher post task
	| StartDate  | EndDate    |
	| 15.09.2022 | 30.09.2022 |
	Then student should sees task



