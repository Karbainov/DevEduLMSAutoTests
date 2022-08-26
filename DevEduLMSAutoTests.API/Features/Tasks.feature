Feature: Tasks

A short summary of the feature

@methodist
Scenario: Add new task for students by methodist
	Given register new users
	| FirstName | LastName  | Patronymic | Email                 | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Ilya      | Baikov    | string     | ilya001@student.com   | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 |
	| Maksim    | Karbainov | string     | ilya002@methodist.com | maksim1  | password | SaintPetersburg | 01.01.1995 | string        | 89997776655 |
	| Elisey    | Kakoyto   | string     | ilya003@techer.com    | elisey1  | password | SaintPetersburg | 02.02.1996 | string        | 89996665544 |
	And authorize manager
	|  |  |
	|  |  |
	And manager add roles to users
	|  |  |
	|  |  |
	|  |  |
	|  |  |
	And manager create new group
	|  |  |  |  |  |  |  |  |
	|  |  |  |  |  |  |  |  |
	And manager add users to group
	|  |  |  |
	|  |  |  |
	|  |  |  |
	And authorize other users
	|  |  |
	|  |  |
	|  |  |
	|  |  |
	And methodist create new task
	|  |  |  |  |  |
	And methodist update task
	|  |  |  |
	When teacher post task
	Then student should sees task
