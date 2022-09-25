Feature: Authentication

Authentication is the act of proving an assertion, such as the identity of a computer system user.

@authentication
Scenario: Authentication on DevEdu web site.
	Given Administrator registers new users with roles
	| FirstName | LastName | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya      | Baikov   | string     | ilya@student.com | ilya     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student |
	And Open DevEdu web site
	And Open authorization page
	And Enter email "ilya@student.com"
	And Enter password "password"
	When Click button Enter
	Then Text with name on sidebar should be "Baikov Ilya"
	And Text with role on sidebar should be "Студент"
	And The notification page should open

@authentication
Scenario: Cancel authentication
	Given Administrator registers new users with roles
	| FirstName | LastName | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya      | Baikov   | string     | ilya@student.com | ilya     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student |
	And Open DevEdu web site
	And Open authorization page
	And Enter email "ilya@student.com"
	And Enter password "password"
	When Click button Cancel
	Then Text in email textbox should be empty
	And Label in email textbox should be "example@mail.ru"
	And Text in password textbox should be empty

@authentication @negative
Scenario: Authentication with wrong password
	Given Administrator registers new users with roles
	| FirstName | LastName | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya      | Baikov   | string     | ilya@student.com | ilya     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student |
	And Open DevEdu web site
	And Open authorization page
	And Enter email "ilya@student.com"
	And Enter password "passpass"
	When Click on button Enter
	Then Excaption message wrong password or email "Неправильные логин или пароль" should appear
