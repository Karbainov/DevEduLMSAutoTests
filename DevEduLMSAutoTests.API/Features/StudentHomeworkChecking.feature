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
	| Lidiya    | Ivanova  | Victorovna | lidyasha@blabla.com | Lidya    | password | SaintPetersburg | 15.12.1990 | string        | 89995556633 |
	| Vasiliy   | Druzhin  | Ivanovich  | vasya@blabla.com    | Vaselyok | password | SaintPetersburg | 05.06.1999 | string        | 89905552211 |
	Given Authorize as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	And Give teacher role to first user
	And Manager create new group
	| Name   | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| BlaBla | 2371     | Learning      | 11.10.2022 | 15.04.2023 | Morning   | 900             | 25            |
	And Manager add student to group
	And Manager add teacher to group
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
