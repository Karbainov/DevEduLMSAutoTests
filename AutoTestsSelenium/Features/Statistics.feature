Feature: Statistics

Information about student attendance, results of homeworks.

@statistics @teacher @homework
Scenario: Teacher chek students homeworks results
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email               | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Andrey1   | Baikov     | string     | Andrey1@student.com | Andrey1  | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Andrey2   | Baikov     | string     | Andrey2@student.com | Andrey2  | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Andrey3   | Baikov     | string     | Andrey3@student.com | Andrey3  | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Anton     | Efremenkov | string     | anton@teacher.com   | anton1   | password | SaintPetersburg | 03.03.1994 | string        | 89995554433 | Teacher |
	And Create new groups
	| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| Group 1 | Базовый C# | Forming       | 26.08.2022 | 26.08.2023 | string    | 5000            | 10            |
	And Add users to group "Group 1"
	| FirstName | LastName   | Role    |
	| Andrey1   | Baikov     | Student |
	| Andrey2   | Baikov     | Student |
	| Andrey3   | Baikov     | Student |
	| Anton     | Efremenkov | Teacher |
	When Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as teacher
	| Email             | Password |
	| anton@teacher.com | password |
	And Teacher create new homework for group "Group 1"
	| Name  | Description         | Link               | StartDate  | EndDate    |
	| Lists | Make your own lists | https://google.com | 28.09.2022 | 09.10.2022 |
	And Teacher logged out
	And Students did their homework "Lists"
	| Email               | Password |
	| Andrey1@student.com | password |
	| Andrey2@student.com | password |
	| Andrey3@student.com | password |
	And Authorize user in service as teacher
	| Email             | Password |
	| anton@teacher.com | password |
	And Teacher rate homeworks
	| FullName       | Result |
	| Andrey1 Baikov | Сдано  |
	| Andrey2 Baikov | Сдано  |
	| Andrey3 Baikov | Сдано  |
	Then Teacher should see students results in homework "Lists" page
	| FullName       | Result |
	| Andrey1 Baikov | Сдано  |
	| Andrey2 Baikov | Сдано  |
	| Andrey3 Baikov | Сдано  |
	And Teacher should see students results to homework "Lists" in tab General Progress
	| FullName       | Result |
	| Andrey1 Baikov | Сдано  |
	| Andrey2 Baikov | Сдано  |
	| Andrey3 Baikov | Сдано  |