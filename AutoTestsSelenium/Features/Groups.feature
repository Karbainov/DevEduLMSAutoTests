Feature: Groups

A short summary of the feature

@manager @teacher @tutor @student
Scenario: Front manager creates a group adds students and appoints a teacher and tutor
Given Register new users with roles in service
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Isabella  | Abramson   | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Manager create new group in service
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# | Maksim Karbainov  | Elisey Kakoyto  |
And Manager add student "Isabella Abramson" to group "BaseSPb" in service 
Then Authorize student in service and check group
| Email         | Password | CourseName | Role    |
| isi@gmail.com | 11345578 | Базовый C# | Student |
And Authorize teacher in service and check group
| Email          | Password | CourseName | Role    |
| maks@gmail.com | 22345678 | Базовый C# | Teacher |
And Authorize tutor in service and check group
| Email            | Password | CourseName | Role  |
| elisey@gmail.com | 13345678 | Базовый C# | Tutor |

@manager @group
Scenario: Manager cancel creation of group
	Given Registrate users with roles
	| FirstName | LastName  | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	| Elisey    | Kakoyto   | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
	Given Open a browser and open login page
	Given SignIn as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	And Start create a group
	| GroupName  | CourseName   | FullNameOfTeacher | FullNameOfTutor |
	| Some group | Backend Java | Maksim Karbainov  | Elisey Kakoyto  |
	When Cancel creation
	Then Group "Some group" do not create