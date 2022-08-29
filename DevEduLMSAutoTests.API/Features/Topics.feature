Feature: Topics

A short summary of the feature

@methodist
Scenario: Add new topics for cources by methodist
Given register new user metodist
	| FirstName | LastName  | Patronymic | Email                        | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Maksim    | Metodist  | string     | maksimmetodist@student.com   | metodist | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 |
	And authorize user
	| Email                 | Password     |
	| marina@example.com    | marinamarina |
	And manager add role metodist to user
	And authorize user
	| Email                         | Password |
	| maksimmetodist@student.com    | password |