Feature: ChangeOfPersonalAccount

The user changes personal data: first name, patronymic, last name, date of birth.

@tag1
Scenario: User data changes
	Given Open a browser in DevEducation web page
	When Enter login "marina@example.com" in the field
	And Enter password "marinamarina" in the field
	Then Click button account login
	Given Go to account settings
	When Change "LastName", "FirstName", "Patronymic", "DateBirth"
	Then Save changes