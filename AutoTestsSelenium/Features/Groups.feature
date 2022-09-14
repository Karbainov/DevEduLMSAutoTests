Feature: Groups

Group - an association of users. The group consists of students, teachers and tutors. 
Groups go through classes, perform tasks. The manager creates, deletes and edits groups.

@group
Scenario: Create and edit new group
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
	When manager create new group from browser

	Then [outcome]

@manager @teacher @tutor @student
Scenario: Front manager creates a group adds students and appoints a teacher and tutor
Given register new users with roles in service
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Isabella  | Abramson   | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When manager create new group in service
| Name    | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
| BaseSPb | 1370     | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
And manager add users to group in service
Then authorize student in service and check group
And authorize teacher in service and check group
And authorize tutor in service and check group