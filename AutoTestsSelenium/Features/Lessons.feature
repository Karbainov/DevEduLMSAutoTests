Feature: Lessons

Teacher create lesson as draft, save it and publish

@teacher @lesson
Scenario: Lesson creation as draft and publishing
    Given Register new users with roles
    | FirstName | LastName   | Patronymic | Email              | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
    | Gennadiy  | Krokodilov | string     | kroko@gmail.com    | Gena     | password | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
    | Gennadiy  | Bukin      | string     | bukin@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
    | Gennadiy  | Golub      | string     | golub@student.com  | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
    | Serafima  | Pekova     | string     | witch@teacher.com  | Sera     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Teacher |
    And Create new groups
    | Name   | CourseId | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
    | BlaBla | 2371     | Forming       | 08.09.2022 | 15.04.2023 | Morning   | 900             | 20            |
    And Add users to group "BlaBla"
    | FirstName | LastName   | Patronymic | Email             | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
    | Gennadiy  | Krokodilov | string     | kroko@gmail.com   | Gena     | password | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
    | Gennadiy  | Bukin      | string     | bukin@student.com | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
    | Gennadiy  | Golub      | string     | golub@student.com | Gena     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
    | Serafima  | Pekova     | string     | witch@teacher.com | Sera     | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Teacher |
    Given Open DevEdu web site https://piter-education.ru:7074/
    Given Authorize user in service as teacher
    | Email             | Password |
    | witch@teacher.com | password |
    And Click on create lesson