Feature: ManagerCancelCreationOfGroup

A short summary of the feature

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
