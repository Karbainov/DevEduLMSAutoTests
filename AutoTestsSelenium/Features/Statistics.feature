Feature: Statistics

A short summary of the feature

@tag1
Scenario: Teacher chek students homeworks results
	Given register new users with roles
	| FirstName | LastName   | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role      |
	| Ilya1     | Baikov     | string     | ilya1@student.com  | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Ilya2     | Baikov     | string     | ilya2@student.com  | ilya2    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Ilya3     | Baikov     | string     | ilya3@student.com  | ilya3    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Ilya4     | Baikov     | string     | ilya4@student.com  | ilya4    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Ilya5     | Baikov     | string     | ilya5@student.com  | ilya5    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Ilya6     | Baikov     | string     | ilya6@student.com  | ilya6    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Ilya7     | Baikov     | string     | ilya7@student.com  | ilya6    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Ilya8     | Baikov     | string     | ilya8@student.com  | ilya6    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Ilya9     | Baikov     | string     | ilya9@student.com  | ilya6    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student   |
	| Anton     | Efremenkov | string     | ilya@teacher.com   | anton1   | password | SaintPetersburg | 03.03.1994 | string        | 89995554433 | Teacher   |
	And manager create new group
	| Name          | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GroupForTest1 | 1370     | Forming       | 26.08.2022 | 26.08.2023 | string    | 5000            | 10            |
	And manager add users to group
	When teacher create new homework
	| Name  | Description         | Link               | StartDate  | EndDate    |
	| Lists | Make your own lists | https://google.com | 11.09.2022 | 09.10.2022 |
	And students did their homework
	And teacher rate homeworks
	| FullName     | Result |
	| Ilya1 Baikov | Сдано  |
	| Ilya2 Baikov | Сдано  |
	| Ilya3 Baikov | Сдано  |
	| Ilya4 Baikov | Сдано  |
	| Ilya5 Baikov | Сдано  |
	| Ilya6 Baikov | Сдано  |
	| Ilya7 Baikov | Сдано  |
	| Ilya8 Baikov | Сдано  |
	| Ilya9 Baikov | Сдано  |
	Then teacher should see students results in homewok tab
	And teacher should see students results in tab General Progress