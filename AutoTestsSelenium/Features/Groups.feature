Feature: Groups

Group is an association of users. The group includes students, teachers and tutors.
The manager creates, edits and deletes groups and their composition.

@manager @teacher @student @group
Scenario: Manager creates a group with a teacher and adds a student and the student checks for the presence of a group
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Isabella  | Abramson   | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	When Click button create group
	And Fills in group data
	| GroupName | CourseName | FullNameOfTeacher |
	| BaseSPb   | Базовый C# | Maksim Karbainov  |
	And Click button saves group
	And Click button students list
	And Additing student "Isabella Abramson" to group "BaseSPb"
	And Manager logged out
	And Authorize user in service as student
	| Email         | Password |
	| isi@gmail.com | 11345578 |
	And Click button lessons as student
	Then Student checks presence of group by name course "Базовый C#"

@manager @teacher @tutor @group
Scenario: Manager creates a group with the teachers and tutors and the teacher checks the presence of the group
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	| Anton     | Efremenkov | string     | anton@gmail.com  | Anton    | 22111678 | SaintPetersburg | 22.07.1988 | string        | 89521477531 | Teacher |
	| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
	| Misha     | Mersa      | string     | mi@gmail.com     | Misha    | 13300178 | SaintPetersburg | 12.12.1997 | string        | 89584763148 | Tutor   |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	When Click button create group
	And Fills in group data
	| GroupName | CourseName | FullNameOfTeacher   | FullNameOfTutor   |
	| BaseSPb   | Базовый C# | <FullNameOfTeacher> | <FullNameOfTutor> |
	And Click button saves group
	And Manager logged out
	And Authorize user in service as teacher
	| Email          | Password |
	| maks@gmail.com | 22345678 |
	And Click button lessons as teacher
	Then Teacher checks presence of group by name course "Базовый C#"
	Examples: 
	| FullNameOfTeacher                  | FullNameOfTutor             |
	| Maksim Karbainov                   |                             |
	| Maksim Karbainov                   | Elisey Kakoyto              |
	| Maksim Karbainov                   | Elisey Kakoyto, Misha Mersa |
	| Maksim Karbainov, Anton Efremenkov |                             |
	| Maksim Karbainov, Anton Efremenkov | Elisey Kakoyto              |
	| Maksim Karbainov, Anton Efremenkov | Elisey Kakoyto, Misha Mersa |

@manager @teacher @tutor @group
Scenario: Manager creates a group with a teacher and a tutor and the tutor checks the presence of the group
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	When Click button create group
	And Fills in group data
	| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
	| BaseSPb   | Базовый C# | Maksim Karbainov  | Elisey Kakoyto  |
	And Click button saves group
	And Manager logged out
	And Authorize user in service as tutor
	| Email            | Password |
	| elisey@gmail.com | 13345678 |
	And Click button lessons as tutor
	Then Tutor checks presence of group by name course "Базовый C#"

@manager @group
Scenario: Manager cancel creation of group
	Given Register new users with roles
	| FirstName | LastName  | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	| Elisey    | Kakoyto   | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	When Click button create group
	And Fills in group data
	| GroupName  | CourseName | FullNameOfTeacher | FullNameOfTutor |
	| Some group | Базовый C# | Maksim Karbainov  | Elisey Kakoyto  |
	And Click button cancels creation of group
	And Click button groups
	Then Manager should not find group "Some group" in list groups

@manager @teacher @tutor @student @group @editing
Scenario: Manager creates a group, fills it with users. Manager changes the composition of the group. Manager sees that the composition of the group has changed
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Isabella  | Abramson   | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Daniela   | Watson     | string     | neli@gmail.com   | Neli     | 11333578 | SaintPetersburg | 14.01.2001 | string        | 89517751247 | Student |
	| Anton     | Efremenkov | string     | anton@gmail.com  | Anton    | 22111678 | SaintPetersburg | 22.07.1988 | string        | 89521477531 | Teacher |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
	| Misha     | Mersa      | string     | mi@gmail.com     | Misha    | 13300178 | SaintPetersburg | 12.12.1997 | string        | 89584763148 | Tutor   |
	And Create new groups
	| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| BaseSPb | Базовый C# | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
	And Add users to group "BaseSPb"
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Isabella  | Abramson   | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
	| Daniela   | Watson     | string     | neli@gmail.com   | Neli     | 11333578 | SaintPetersburg | 14.01.2001 | string        | 89517751247 | Student |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	When Click button groups
	And Click button group with name "BaseSPb"
	And Click button edit
	And Fills in edit group data
	| GroupName | CourseName | FullNameOfTeacher   | FullNameOfTutor   |
	| BaseSPb   | Базовый C# | <FullNameOfTeacher> | <FullNameOfTutor> |
	And Click button saves edit group
	And Click button groups
	And Click button group with name "BaseSPb"
	Then Should be a teachers and tutors in group
	| FullNameOfTeacher   | FullNameOfTutor   |
	| <FullNameOfTeacher> | <FullNameOfTutor> |
	Examples: 
	| FullNameOfTeacher                  | FullNameOfTutor             |
	| Maksim Karbainov                   | Elisey Kakoyto              |
	| Maksim Karbainov                   | Elisey Kakoyto, Misha Mersa |
	| Maksim Karbainov, Anton Efremenkov |                             |
	| Maksim Karbainov, Anton Efremenkov | Elisey Kakoyto              |
	| Maksim Karbainov, Anton Efremenkov | Elisey Kakoyto, Misha Mersa |

@manager @teacher @group @editing
Scenario: Manager creates a group together with the teacher. Manager changes the name of the group and the course. Manager and teacher see that the name of the group and the course have changed
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Create new groups
	| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| BaseSPb | Базовый C# | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
	And Add users to group "BaseSPb"
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	When Click button groups
	And Click button group with name "BaseSPb"
	And Click button edit
	And Fills in edit group data
	| GroupName | CourseName    | FullNameOfTeacher |
	| QASPb     | QA Automation | Maksim Karbainov  |
	And Click button saves edit group
	And Click button groups
	Then Manager should find group "QASPb" in list groups
	When Manager logged out
	And Authorize user in service as teacher
	| Email          | Password |
	| maks@gmail.com | 22345678 |
	And Click button lessons as teacher
	Then Teacher checks presence of group by name course "QA Automation"

@manager @teacher @group @editing
Scenario: Manager creates a group, edits the group and cancels editing
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Create new groups
	| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| BaseSPb | Базовый C# | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
	And Add users to group "BaseSPb"
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	When Click button groups
	And Click button group with name "BaseSPb"
	And Click button edit
	And Fills in edit group data
	| GroupName | CourseName    | FullNameOfTeacher |
	| QASPb     | QA Automation | Maksim Karbainov  |
	And Click button cancels editing of group
	And Click button groups
	Then Manager should find group "BaseSPb" in list groups

@manager @group @negative
Scenario: Manager creates a group without data negative test
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	When Click button create group
	And Fills in group data
	| GroupName   | CourseName   | FullNameOfTeacher   | FullNameOfTutor |
	| <GroupName> | <CourseName> | <FullNameOfTeacher> | Elisey Kakoyto  |
	And Click button saves group
	Then Error message about absence of group data, when creating group should be "<Message>"
	Examples: 
	| GroupName | CourseName | FullNameOfTeacher | Message                     |
	|           | Базовый C# | Maksim Karbainov  | Вы не указали название      |
	| BaseSPb   |            | Maksim Karbainov  | Вы не выбрали курс          |
	| BaseSPb   | Базовый C# |                   | Вы не выбрали преподавателя |

@manager @group @editing @negative
Scenario: Manager creates a group, edits a group without data negative test
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
	And Create new groups
	| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| BaseSPb | Базовый C# | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
	And Add users to group "BaseSPb"
	| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
	| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	When Click button groups
	And Click button group with name "BaseSPb"
	And Click button edit
	And Fills in group data
	| GroupName   | CourseName   | FullNameOfTeacher   | FullNameOfTutor |
	| <GroupName> | <CourseName> | <FullNameOfTeacher> | Elisey Kakoyto  |
	And Click button saves edit group
	Then Error message about absence of group data, when editing group should be "<Message>"
	Examples: 
	| GroupName | CourseName | FullNameOfTeacher | Message                     |
	|           | Базовый C# | Maksim Karbainov  | Вы не указали название      |
	| BaseSPb   |            | Maksim Karbainov  | Вы не выбрали курс          |
	| BaseSPb   | Базовый C# |                   | Вы не выбрали преподавателя |

@group @student
Scenario: The group completed the basic course and moved on to the next one. The student sees the history of his courses.
	Given Register new users with roles
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Вася      | Ложкин   | Вилкович   | vasyok@dev.com | Lojka    | password | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Student |
	And Create new groups
	| Name       | CourseName    | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
	| Navigators | Базовый C#    | Completed     | 21.02.2022 | 30.05.2022 | string    | 2500            | 3             |
	| Winners    | QA Automation | Forming       | 21.06.2022 | 10.10.2022 | string    | 7500            | 3             |
	And Add users to group "Navigators"
	| FirstName | LastName | Role    |
	| Вася      | Ложкин   | Student |
	And Add users to group "Winners"
	| FirstName | LastName | Role    |
	| Вася      | Ложкин   | Student |
	And Open DevEdu web site https://piter-education.ru:7074/
	When Authorize user in service as student
	| Email          | Password |
	| vasyok@dev.com | password |
	And Click button lessons as student
	Then Student checks presence of group by name course "Базовый C#"
	And Student checks presence of group by name course "QA Automation"