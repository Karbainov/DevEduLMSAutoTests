Feature: SpecialOnePointTwo

A short summary of the feature

@teacher
Scenario: Сreating an activity for students by teacher
	Given the first number is 50
	Given register new users
	| FirstName   | LastName  | Patronymic | Email                | Username  | Password  | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Milana      | Maxina    | string     | maxina1@techer.com   | maxina1    | password | SaintPetersburg | 01.01.1995 | string        | 89817051818 |
	| Valeria     | Puzikova  | string     | lera@methodist.com   | lera1      | password | SaintPetersburg | 01.02.1996 | string        | 89071961416 |
	And authorize users
	| Email                 | Password     |
	| maxina1@techer.com    | password     |
	| lera@methodist.com    | password     |
	| marina@example.com    | marinamarina |
	And manager add roles to user
	And manager create new group
	| Name         | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest01| 01       | Forming       | 27.08.2022 | 31.12.2022 | string    | 1000            | 10            |
	And methodist create topic 
	| Name                | Duration |
	|creating a calculator|      2   |
	And teacher create a lesson
	| Date        | AdditionalMaterials | GroupId | Name  | LinkToRecord    | TopicIds |IsPublished |
	|01.09.2022   |   string            | Forming |string |string           | Forming  |true        |
	And teacher saves the lesson as a draft
	When teacher publishes a draft lesson
	When lesson recording appears
	And teacher update lesson
    | AdditionalMaterials | LinkToRecord    | Date       |TopicIds |
	|   string            |string           |01.09.2022  |Forming  |
    Then teacher publishes a lesson