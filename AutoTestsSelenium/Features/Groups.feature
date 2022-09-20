Feature: Groups

A short summary of the feature

@manager @teacher @student @group
Scenario: Manager creates a group with a teacher and adds a student and the student checks for the presence of a group
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Isabella  | Abramson   | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
When Open authorization page
And SignIn user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
And Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# | Maksim Karbainov  |                 |
And Saves group
And Click button students list
And Additing student "Isabella Abramson" to group "BaseSPb"
And Exit account as manager
And SignIn user in service as student
| Email         | Password |
| isi@gmail.com | 11345578 |
And Click button lessons as student
Then Student checks presence of group by name course "Базовый C#"

@manager @teacher @group
Scenario: Manager creates a group with the teacher and the teacher checks the presence of the group
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
When Open authorization page
And SignIn user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
And Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# | Maksim Karbainov  |                 |
And Saves group
And Exit account as manager
And SignIn user in service as teacher
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
When Open authorization page
And SignIn user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
And Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# | Maksim Karbainov  | Elisey Kakoyto  |
And Saves group
And Exit account as manager
And SignIn user in service as tutor
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
When Open authorization page
And SignIn user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
And Click button create group
And Fills in group data
| GroupName  | CourseName | FullNameOfTeacher | FullNameOfTutor |
| Some group | Базовый C# | Maksim Karbainov  | Elisey Kakoyto  |
And Cancels creation of group
And Click button groups
Then Manager checks group "Some group" in list groups

@manager @group
Scenario: Manager creates a group without a name negative test
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open authorization page
And SignIn user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
And Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
|           | Базовый C# | Maksim Karbainov  | Elisey Kakoyto  |
And Saves group
Then Error message about absence of group name must match text "Вы не указали название"

@manager @group
Scenario: Manager creates a group without choosing a course negative test
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open authorization page
And SignIn user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
And Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   |            | Maksim Karbainov  | Elisey Kakoyto  |
And Saves group
Then Error message about absence of selected course must match text "Вы не выбрали курс"

@manager @group
Scenario: Manager creates a group without choosing a teacher negative test
Given Register new users with roles
| FirstName | LastName   | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
| Maksim    | Karbainov  | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher |
| Elisey    | Kakoyto    | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor   |
When Open authorization page
And SignIn user in service as manager
| Email              | Password     |
| marina@example.com | marinamarina |
And Click button create group
And Fills in group data
| GroupName | CourseName | FullNameOfTeacher | FullNameOfTutor |
| BaseSPb   | Базовый C# |                   | Elisey Kakoyto  |
And Saves group
Then Error message about absence of a teacher's choice should correspond to text "Вы не выбрали преподавателя"