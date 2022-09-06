Feature: Topics

A short summary of the feature

@methodist
Scenario: Add new topics for courses by methodist
Given register new user metodist
	| FirstName | LastName  | Patronymic | Email                          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Maksim    | Metodist  | string     | maksimmetodist32@student.com   | metodist | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 |
	And authorize user as manager
	| Email                 | Password     |
	| marina@example.com    | marinamarina |
	And manager add role metodist to user
	And authorize user as methodist
	| Email                          | Password |
	| maksimmetodist32@student.com    | password |
	And methodist create a topic
	| Name        | Duration  |
	| functions14 | 12       |
    And methodist add topic to course
	| Position |
	| 1        |
	And methodist can see the list of all topics in course with this topic
	And methodist update topic 
	| Name    | Duration |
	| cycles3 | 20       |
	And methodist can see updated topic
    And methodist change order of topics
	| Position |
	| 22       |
	And methodist can see changed order

	
