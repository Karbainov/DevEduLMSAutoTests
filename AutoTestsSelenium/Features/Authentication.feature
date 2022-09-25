Feature: Authentication

Authentication is the act of proving an assertion, such as the identity of a computer system user.

@authentication
Scenario: Authentication on DevEdu web site.
	Given Administrator registers new users with roles
	| FirstName | LastName | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya      | Baikov   | string     | ilya@student.com | ilya     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student |
	When Open DevEdu web site
	And Open authorization page
	And Enter email "ilya@student.com"
	And Enter password "password"
	And Click button Enter
	Then The notification page should open
	And Text with name on sidebar should be "Baikov Ilya"
	And Text with role on sidebar should be "Студент"
