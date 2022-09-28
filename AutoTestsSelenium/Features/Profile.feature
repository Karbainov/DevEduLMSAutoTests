Feature: Profile

A short summary of the feature

@teacher @tutor @methodist @student
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
When Click button settings
And Fills data
| LastName | FirstName | Patronymic   | BirthDate  | PhoneNumber | GitHubAccount       |
| Родригес | Бендер    | Блестящийзад | 01.01.2022 | 89514713285 | https://github.com/ |
And Click button save
And Refresh page
Then Profile data must match the changed ones
| LastName | FirstName | Patronymic   | BirthDate  | Email   | PhoneNumber | GitHubAccount       |
| Родригес | Бендер    | Блестящийзад | 01.01.2022 | <Email> | 89514713285 | https://github.com/ |
Examples: 
| Email            | Password |
| isi@gmail.com    | 11345578 |
| maks@gmail.com   | 22345678 |
| elisey@gmail.com | 13345678 |
| mi@gmail.com     | 87425974 |

