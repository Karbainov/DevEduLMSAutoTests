Feature: Topics

A short summary of the feature

@methodist
Scenario: Add new topics for courses by methodist
Given register new user metodist
	| FirstName | LastName  | Patronymic | Email                          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Maksim    | Metodist  | string     | maksimmetodist13@student.com   | metodist | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 |
	And authorize user as manager
	| Email                 | Password     |
	| marina@example.com    | marinamarina |
	And manager add role metodist to user
	And authorize user as methodist
	| Email                          | Password |
	| maksimmetodist13@student.com    | password |
	And  methodist create a course
	| Name       | Description     |
	| Base Java8 | New java course |
	And methodist create a topic
	| Name       | Duration |
	| functions8 | 12       |
    And methodist add topic to course
	| Position |
	| 1        |
	And I can see the course with topic
	#And list of all courses should contains the course with topic
	
