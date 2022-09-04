Feature: StudentHomeworkChecking

Teacher give a homework
Student pass the homework
Teacher decline it
Student fix it and send it second time
Teacher approve it

@studentHomework
Scenario: Student pass the homework from the second time
	Given Register students
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Lidiya    | Ivanova  | Victorovna | lidyasha@blabla.com | Lidya    | password | SaintPetersburg | 15.12.1990 | string        | 89995556633 |
	Given Register teachers
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Vasiliy   | Druzhin  | Ivanovich  | vasya@blabla.com    | Vaselyok | password | SaintPetersburg | 05.06.1999 | string        | 89905552211 |
	Given Authorize as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	And Give teacher role to first user
	And Manager create new group
	| Name   | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| BlaBla | 2371     | Forming       | 08.09.2022 | 15.04.2023 | Morning   | 900             | 20            |
	And Manager add users to group
	Given Authorize as teacher
	| Email            | Password |
	| vasya@blabla.com | password |
	And Teacher create new task
	| Name  | Description | Links  | IsRequired |
	| Apple | Lemon       | string | true       |
	And Add new homework
    | StartDate  | EndDate    |
    | 15.09.2022 | 28.09.2022 |
	Given Authorize as student
	| Email               | Password |
	| lidyasha@blabla.com | password |
	And Student send passed homework
	But Teacher decline student's homework
	And Student send homework from the second time
	When Teacher approve it
	Then Homework passed
