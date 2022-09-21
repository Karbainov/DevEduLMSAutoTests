Feature: Statistics

Information about student attendance, results of homeworks

@statistics @teacher @homework
Scenario: Teacher chek students homeworks results
	Given Administrator registers new users with roles
	| FirstName | LastName   | Patronymic | Email             | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya1     | Baikov     | string     | ilya1@student.com | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Ilya2     | Baikov     | string     | ilya2@student.com | ilya2    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Ilya3     | Baikov     | string     | ilya3@student.com | ilya3    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Anton     | Efremenkov | string     | anton@teacher.com | anton1   | password | SaintPetersburg | 03.03.1994 | string        | 89995554433 | Teacher |
	And Admin create new groups
	| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| Group 1 | Базовый C# | Forming       | 26.08.2022 | 26.08.2023 | string    | 5000            | 10            |
	And Admin add users to group "Group 1"
	| FirstName | LastName   | Role    |
	| Ilya1     | Baikov     | Student |
	| Ilya2     | Baikov     | Student |
	| Ilya3     | Baikov     | Student |
	| Anton     | Efremenkov | Teacher |
	When Open DevEdu web site
	And Authorize user
	| Email             | Password |
	| anton@teacher.com | password |
	And teacher create new homework for group "Group 1"
	| Name  | Description         | Link               | StartDate  | EndDate    |
	| Lists | Make your own lists | https://google.com | 21.09.2022 | 09.10.2022 |
	And Students did their homework "Lists"
	| Email             | Password |
	| ilya1@student.com | password |
	| ilya2@student.com | password |
	| ilya3@student.com | password |
	And Authorize user
	| Email             | Password |
	| anton@teacher.com | password |
	And Teacher rate homeworks
	| FullName     | Result |
	| Ilya1 Baikov | Сдано  |
	| Ilya2 Baikov | Сдано  |
	| Ilya3 Baikov | Сдано  |
	Then Teacher should see students results in homework "Lists" page
	| FullName     | Result |
	| Ilya1 Baikov | Сдано  |
	| Ilya2 Baikov | Сдано  |
	| Ilya3 Baikov | Сдано  |
	And teacher should see students results to homework "Lists" in tab General Progress
	| FullName     | Result |
	| Ilya1 Baikov | Сдано  |
	| Ilya2 Baikov | Сдано  |
	| Ilya3 Baikov | Сдано  |