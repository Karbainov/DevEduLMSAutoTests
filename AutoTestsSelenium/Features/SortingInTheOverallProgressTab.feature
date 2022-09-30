Feature: SortingInTheOverallProgressTab

Teacher sort students progress by surname

@teacher @homework
Scenario: Sort by surname
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Gennadiy  | Krokodilov | string     | kroko@gmail.com    | Gena     | password | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Gennadiy  | Bukin      | string     | bukin@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Golub      | string     | golub@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Yula       | string     | yula@student.com   | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Gennadiy  | Akril      | string     | kraska@student.com | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Serafima  | Pekova     | string     | witch@teacher.com  | Sera     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Teacher |
	And Create new groups
	| Name   | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| BlaBla | 2371     | Forming       | 08.09.2022 | 15.04.2023 | Morning   | 900             | 20            |
	And Add users to group "BlaBla"
	| FirstName | LastName   | Role    |
	| Gennadiy  | Krokodilov | Student |
	| Gennadiy  | Bukin      | Student |
	| Gennadiy  | Golub      | Student |
	| Gennadiy  | Yula       | Student |
	| Gennadiy  | Akril      | Student |
	| Serafima  | Pekova     | Teacher |
	And Create new task for group "BlaBla"
	| Name  | Description | Links  | IsRequired |
	| Apple | Lemon       | string | true       |
	And Add new homeworks for group "BlaBla" task "Apple"
	| StartDate  | EndDate    |
	| 01.10.2022 | 25.10.2022 |
	Given Students authorize and send homework for group "BlaBla" task "Apple"
	| Email              | Password | HomeworkId | Answer         |
	| kroko@gmail.com    | password |            | link@razdva.ru |
	| bukin@student.com  | password |            | link@razdva.ru |
	| golub@student.com  | password |            | link@razdva.ru |
	| yula@student.com   | password |            | link@razdva.ru |
	| kraska@student.com | password |            | link@razdva.ru |
	Given Check homeworks in group "BlaBla" task "Apple"
	| FirstName | LastName   | Result   |
	| Gennadiy  | Krokodilov | Сдано    |
	| Gennadiy  | Bukin      | Сдано    |
	| Gennadiy  | Golub      | Сдано    |
	| Gennadiy  | Yula       | Не сдано |
	| Gennadiy  | Akril      | Не сдано |
	Given Open DevEdu web site https://piter-education.ru:7074/
	Given Authorize user in service as teacher
	| Email             | Password |
	| witch@teacher.com | password |
	When Teacher open tab General Progress	
	And Choose group "BlaBla"
	When Teacher sort students by surname
	Then Students should sort by surname
	| FullName            | Result   |
	| Gennadiy Akril      | Не сдано |
	| Gennadiy Bukin      | Сдано    |
	| Gennadiy Golub      | Сдано    |
	| Gennadiy Krokodilov | Cдано    |
	| Gennadiy Yula       | Не сдано |

@teacher
Scenario: Teacher sorts students by status
	Given Register new users with roles
	| FirstName | LastName  | Patronymic | Email             | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Барабан   | Second    | string     | isi@gmail.com     | Bella    | password | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Ворона    | Амеба     | string     | lil@student.com   | Lil      | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Абрикос   | Филя      | string     | ilya2@student.com | ilya2    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	| Maksim    | Karbainov | string     | maks@teacher.com  | Maksim   | password | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Create new groups
	| Name            | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| Паровозик любви | 1370     | Forming       | 25.09.2022 | 30.01.2023 | string    | 5000            | 10            |
	And Add users to group "Паровозик любви"
	| FirstName | LastName  | Role    |
	| Барабан   | Second    | Student |
	| Ворона    | Амеба     | Student |
	| Абрикос   | Филя      | Student |
	| Maksim    | Karbainov | Teacher |
	When Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as teacher
	| Email            | Password |
	| maks@teacher.com | password |
	And Teacher create new homework for group "Паровозик любви"
	| Name      | Description  | Link                      | StartDate  | EndDate    |
	| Структуры | LubluDushit  | https://hd.kinopoisk.ru/  | 30.09.2022 | 02.10.2022 |
	And Teacher logged out
	And Students did their homework "Структуры"
	| Email             | Password |
	| isi@gmail.com     | password |
	| lil@student.com   | password |
	| ilya2@student.com | password |
	And Authorize user in service as teacher
	| Email            | Password |
	| maks@teacher.com | password |
	And Teacher rate homeworks
	| Email          | Result           |
	| Барабан Second | Проверить правки |
	| Ворона Амеба   | Не сдано         |
	| Абрикос Филя   | Не сдано         |
	And Teacher open tab General Progress	
	When Teacher click ascending sorting in a column "Структуры"
	Then Teacher should see list "Структуры" after sort on ABC
	| FullName       | Result           |
	| Абрикос Филя   | Не сдано         |
	| Ворона Амеба   | Не сдано         |
	| Барабан Second | Проверить правки |
	And Teacher click descending sorting in a column "Структуры"
	Then Teacher should see list "Структуры" after sort on CBA
	| FullName       | Result           |
	| Барабан Second | Проверить правки |
	| Абрикос Филя   | Не сдано         |
	| Ворона Амеба   | Не сдано         |