Feature: SpecialOnePointTwo

A short summary of the feature

@teacher @student
Scenario: Сreating an activity for students by teacher
	Given register new user
	| FirstName   | LastName  | Patronymic | Email                | Username  | Password  | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Valeria     | Puzikova  | string     | lera04@methodist.com | lera1      | password | SaintPetersburg | 01.02.1996 | string        | 89071961416 |
	| Milana      | Maxina    | string     | maxina04@techer.com  | maxina1    | password | SaintPetersburg | 01.01.1995 | string        | 89817051818 |
	And authorize admina
	And manager add roles to user
	And authorize user
	| Email                 | Password     |
	| lera04@methodist.com  | password     |
	| maxina04@techer.com   | password     |
	| marina@example.com    | marinamarina |
	And manager create new groups
	| Name         | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest01| 1370      | Forming       | 27.08.2022 | 31.12.2022 | string    | 1000            | 10            |
	And methodist create topic 
	| Name                | Duration |
	|creating a calculator|      3   |
	And teacher create a lesson
	| Date        | AdditionalMaterials | GroupId | Name  | LinkToRecord       | TopicIds |IsPublished |
	|11.09.2022   |   string            | 1583    |string |http://fjfjf.com    | 668      |true        |
	And teacher saves the lesson as a draft
	And teacher publishes a draft lesson
	And lesson recording appears
	When teacher update lesson
    | AdditionalMaterials | LinkToRecord    | Date       |TopicIds |
	|   string            |http://fjfjf.com |01.09.2022  |668      |
    Then teacher can see published a lesson