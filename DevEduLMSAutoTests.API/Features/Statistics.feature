Feature: Statistics

Teacher can notes student attendance and see attendance statistics

@admin @teacher @student @lesson @statistic
Scenario: Attendance statistics
	Given register new users
	| FirstName | LastName   | Patronymic | Email               | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Zloi      | Negativniy | Chel       | chel666@student.com | Chel     | password | SaintPetersburg | 03.10.2000 | string        | 89759407395 |
	| Dobriy    | Positivniy | Mheh       | mheh777@teacher.com | Mheh     | password | SaintPetersburg | 08.07.1995 | string        | 89756475703 |
	And authorize admin
	And manager add roles to user
	And authorize user
	| Email               | Password     |
	| chel666@student.com | password     |
	| mheh777@teacher.com | password     |
	| marina@example.com  | marinamarina |
	And admin create course
	And manager create new groups
	| Name          | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| GropForTest01 | 1370     | Forming       | 27.08.2022 | 31.12.2022 | string    | 100             | 10            |
	And admin add teacher group
	And manager add users to group
	And teacher create a lesson a draft
	| Date       | AdditionalMaterials | GroupId | Name   | LinkToRecord     | TopicIds | IsPublished |
	| 11.09.2022 | string              | 1654    | string | http://fjfjf.com | 703      | true        |
	And teacher sees a draft lesson
	When teacher update lesson
    | AdditionalMaterials | LinkToRecord     | Date       | TopicIds |
    | string              | http://fjfjf.com | 02.09.2022 | 703      |
    Then teacher can see published a lesson
	And student can see published a lesson
	Given teacher notes presence of students
	When teacher opens table of attendance
	Then teacher sees statistics of student attendance