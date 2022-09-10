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
