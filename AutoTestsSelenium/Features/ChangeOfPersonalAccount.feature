Feature: ChangeOfPersonalAccount

The user changes personal data: first name, patronymic, last name, date of birth.

@tag1
Scenario: User data changes
	Given Open a browser in DevEducation web page
	When Enter login account
	| Login              | Password     |
	| marina@example.com | marinamarina |
	Then Click button account login
	Given Go to account settings
	When Change LastName, FirstName, Patronymic, GitHub, Phone
	| LastName | FirstName | Patronymic | GitHub              | Phone       |
	| Максина  | Марина    | Сергеевна  | https://github.com/ | 89435235475 |
	And Change Date Birth 
	Then Save changes