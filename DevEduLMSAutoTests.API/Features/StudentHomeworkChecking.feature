Feature: StudentHomeworkChecking

Teacher give a homework
Student pass the homework
Teacher decline it
Student fix it and send it second time
Teacher approve it

@studentHomework
Scenario: Student pass the homework from the second time
	Given Register two users
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Лидия     | Иванова  | Викторовна | lidyasha@blabla.com | Lidya    | password | SaintPetersburg | 1990-05-10 | string        | 89995556633 |
	| Василий   | Дружин   | Иванович   | vasya@blabla.com    | Vaselyok | password | SaintPetersburg | 1999-02-06 | string        | 89905552211 |
	Given Authorize as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	And  Give teacher role to one user
	And Admin create new course
	| Name             | Description |
	| Best Course Ever | Bla bla bla |
	And Manager create new group
	And Manager add student to group
	Given Authorize as teacher
	| Email               | Password |
	| lidyasha@blabla.com | 12345678 |
	And Teacher create new task
	And Add new homework
	And Student send passed homework
	But Teacher decline student's homework
	And Student send homework from the second time
	When Teacher approve it
	Then Homework passed
