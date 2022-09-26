Feature: Groups

A short summary of the feature

@manager @teacher @student @group
Scenario: Manager creates a group with a teacher and adds a student and the student checks for the presence of a group
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Isabella  | Abramson   | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# | Maksim Karbainov  |                 |
And Click button saves group
And Click button students list
And Additing student "Isabella Abramson" to group "BaseSPb"
And Exit account as manager
And Authorize user in service as student
| Email         | Password |
| isi@gmail.com | 11345578 |
And Click button lessons as student
Then Student checks presence of group by name course "Базовый C#"

@manager @teacher @group
Scenario: Manager creates a group with the teacher and the teacher checks the presence of the group
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# | Maksim Karbainov  |                 |
And Saves group
And Exit account as manager
And Authorize user in service as teacher
| Email          | Password |
| maks@gmail.com | 22345678 |
And Click button lessons as teacher
Then Teacher checks presence of group by name course "Базовый C#"

@manager @teacher @tutor @group
Scenario: Manager creates a group with a teacher and a tutor and the tutor checks the presence of the group
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# | Maksim Karbainov  | Elisey Kakoyto  |
And Saves group
And Exit account as manager
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
When Open DevEdu web site https://piter-education.ru:7074/
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
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button groups
And Click button group with name "BaseSPb"
And Click button edit
And Fills in edit group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# | Anton Efremenkov  | Misha Mersa     |
And Click button saves edit group
And Click button groups
And Click button group with name "BaseSPb"
Then Should be a teacher in group "Anton Efremenkov" and should not be a teacher "Maksim Karbainov"
And Should be a tutor in group "Misha Mersa" and should not be a tutor "Elisey Kakoyto"

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
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button groups
And Click button group with name "BaseSPb"
And Click button edit
And Fills in edit group data
| GroupName | CourseName    | FullNameOfTeacher | FullNameOfTutor |
| QASPb     | QA Automation | Maksim Karbainov  |                 |
And Click button saves edit group
And Click button groups
Then Manager should find group "QASPb" in list groups
When Exit account as manager
And Authorize user in service as teacher
| Email          | Password |
| maks@gmail.com | 22345678 |
And Click button lessons as teacher
Then Teacher checks presence of group by name course "QA Automation"

@manager @teacher @group @editing
Scenario: Manager creates a group, edits the group and cancels editing
Given Administrator registers new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
And Admin create new groups
| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
| BaseSPb | Базовый C# | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
And Admin add users to group "BaseSPb"
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
And Open authorization page
And SignIn user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button groups
And Click button group with name "BaseSPb"
And Click button edit
And Fills in edit group data
| GroupName | CourseName    | FullNameOfTeacher | FullNameOfTutor |
| QASPb     | QA Automation | Maksim Karbainov  |                 |
And Click button cancels editing of group
And Click button groups
Then Manager should find group "BaseSPb" in list groups

@manager @group @negative
Scenario: Manager creates a group without a name negative test
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
|           | Базовый C# | Maksim Karbainov  | Elisey Kakoyto  |
And Click button saves group
Then Error message about absence of a group name, when creating a group should be "Вы не указали название"

@manager @group @negative
Scenario: Manager creates a group without choosing a course negative test
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   |            | Maksim Karbainov  | Elisey Kakoyto  |
And Click button saves group
Then Error message about lack of course selection, when creating a group should be "Вы не выбрали курс"

@manager @group @negative
Scenario: Manager creates a group without choosing a teacher negative test
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# |                   | Elisey Kakoyto  |
And Click button saves group
Then Error message about lack of teacher selection, when creating a group should be "Вы не выбрали преподавателя"

@manager @group @editing @negative
Scenario: Manager creates a group, edits a group without a name negative test
Given Administrator registers new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
And Admin create new groups
| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
| BaseSPb | Базовый C# | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
And Admin add users to group "BaseSPb"
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button groups
And Click button group with name "BaseSPb"
And Click button edit
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
|           | Базовый C# | Maksim Karbainov  | Elisey Kakoyto  |
And Click button saves edit group
Then Error message about absence of group name, when editing group should be "Вы не указали название"

@manager @group @editing @negative
Scenario: Manager creates a group, edits the group without choosing a course negative test
Given Administrator registers new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
And Admin create new groups
| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
| BaseSPb | Базовый C# | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
And Admin add users to group "BaseSPb"
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button groups
And Click button group with name "BaseSPb"
And Click button edit
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   |            | Maksim Karbainov  | Elisey Kakoyto  |
And Click button saves edit group
Then Error message about lack of course selection, when editing group should be "Вы не выбрали курс"

@manager @group @editing @negative
Scenario: Manager creates a group, edits the group without choosing a teacher negative test
Given Administrator registers new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
And Admin create new groups
| Name    | CourseName | GroupStatusId | StartDate  | EndDate    | Timetable | PaymentPerMonth | PaymentsCount |
| BaseSPb | Базовый C# | Forming       | 29.09.2022 | 25.01.2023 | string    | 2500            | 3             |
And Admin add users to group "BaseSPb"
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open DevEdu web site https://piter-education.ru:7074/
And Authorize user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
When Click button groups
And Click button group with name "BaseSPb"
And Click button edit
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# |                   | Elisey Kakoyto  |
And Click button saves edit group
Then Error message about lack of teacher selection, when editing group should be "Вы не выбрали преподавателя"