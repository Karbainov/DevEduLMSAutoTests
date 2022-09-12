Feature: ManagerCancelCreationOfGroup

A short summary of the feature

@manager @group
Scenario: Manager cancel creation of group
	Given Authorize as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	Given Registrate few students
	| FirstName  | LastName   | Patronymic | Email               | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Lidiya     | Ivanova    | Victorovna | lidyasha@blabla.com | Lidya    | password | SaintPetersburg | 15.12.1990 | string        | 89995556633 |
	| Ivangelina | Rusachenko | Olgovna    | iva@blabla.com      | Ivasha   | password | SaintPetersburg | 26.02.1999 | string        | 89996663322 |
	And Registrate a teacher
	| FirstName | LastName | Patronymic | Email               | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Vasiliy   | Druzhin  | Ivanovich  | vasya@blabla.com    | Vaselyok | password | SaintPetersburg | 05.06.1999 | string        | 89905552211 |
	And Registrate a tutor
	| FirstName | LastName  | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Igor      | Artemonov | Ildarovich | igoryok@blabla.com | Igoryok  | password | SaintPetersburg | 01.09.1995 | string        | 89992225544 |
	Given Open a browser and open a page
	Given SignIn as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	And Start create a group "Orange"
	When Cancel creation
	Then Group do not create
