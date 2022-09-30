Feature: Profile

A short summary of the feature

@teacher @tutor @methodist @student @profile
Scenario: Users in student, teacher, tutor, methodologist change profile data
	Given Register new users with roles
	| FirstName | LastName  | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role      |
	| Isabella  | Abramson  | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student   |
	| Maksim    | Karbainov | string     | maks@gmail.com   | Maksim   | 22345678 | SaintPetersburg | 18.05.1995 | string        | 89521496531 | Teacher   |
	| Elisey    | Kakoyto   | string     | elisey@gmail.com | Elisey   | 13345678 | SaintPetersburg | 07.10.1996 | string        | 89518963148 | Tutor     |
	| Misha     | Erman     | string     | mi@gmail.com     | Misha    | 87425974 | SaintPetersburg | 10.02.1998 | string        | 89518963148 | Methodist |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service
	| Email   | Password   |
	| <Email> | <Password> |
	When Open profile page by click on user name
	And Fills data profile
	| LastName | FirstName | Patronymic   | BirthDate  | PhoneNumber | GitHubAccount       |
	| Родригес | Бендер    | Блестящийзад | 01.01.2022 | 89514713285 | https://github.com/ |
	And Click button save profile changes
	And Refresh profile page
	Then Profile data must match the changed ones
	| LastName | FirstName | Patronymic   | BirthDate  | Email   | PhoneNumber | GitHubAccount       |
	| Родригес | Бендер    | Блестящийзад | 01.01.2022 | <Email> | 89514713285 | https://github.com/ |
	Examples: 
	| Email            | Password |
	| isi@gmail.com    | 11345578 |
	| maks@gmail.com   | 22345678 |
	| elisey@gmail.com | 13345678 |
	| mi@gmail.com     | 87425974 |

@student @profile
Scenario: Student changes password in profile
	Given Register new users with roles
	| FirstName | LastName  | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role      |
	| Isabella  | Abramson  | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student   |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as student
	| Email         | Password |
	| isi@gmail.com | 11345578 |
	When Open profile page by click on user name
	And Click editing password
	And Fills password data
	| OldPassword | Password | RepeatPassword |
	| 11345578    | 77777777 | 77777777       |
	And Click button save password changes
	And Student logged out
	And Open authorization page
	And Enter email "isi@gmail.com"
	And Enter password "77777777"
	And Click button Enter
	Then Text with name on sidebar should be "Abramson Isabella"
	And Text with role on sidebar should be "Студент"
	And The notification page should open

@student @profile
Scenario: Student cancels profile editing
	Given Register new users with roles
	| FirstName | LastName  | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role      |
	| Isabella  | Abramson  | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student   |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as student
	| Email         | Password |
	| isi@gmail.com | 11345578 |
	When Open profile page by click on user name
	And Fills data profile
	| LastName | FirstName | Patronymic   | BirthDate  | PhoneNumber | GitHubAccount       |
	| Родригес | Бендер    | Блестящийзад | 01.01.2022 | 89514713285 | https://github.com/ |
	And Click button cancels profile changes
	And Refresh profile page
	Then Profile data must match the changed ones
	| LastName | FirstName | Patronymic | BirthDate  | Email         | PhoneNumber | GitHubAccount |
	| Abramson | Isabella  | string     | 22.05.2001 | isi@gmail.com | 89514551247 | string        |

@student @profile
Scenario: Student cancels password changes in profile
	Given Register new users with roles
	| FirstName | LastName  | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role      |
	| Isabella  | Abramson  | string     | isi@gmail.com    | Bella    | 11345578 | SaintPetersburg | 22.05.2001 | string        | 89514551247 | Student   |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service as student
	| Email         | Password |
	| isi@gmail.com | 11345578 |
	When Open profile page by click on user name
	And Click editing password
	And Fills password data
	| OldPassword | Password | RepeatPassword |
	| 11345578    | 77777777 | 77777777       |
	And Click button cancels password changes in profile
	And Student logged out
	And Open authorization page
	And Enter email "isi@gmail.com"
	And Enter password "11345578"
	And Click button Enter
	Then Text with name on sidebar should be "Abramson Isabella"
	And Text with role on sidebar should be "Студент"
	And The notification page should open