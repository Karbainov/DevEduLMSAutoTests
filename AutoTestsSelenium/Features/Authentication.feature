Feature: Authentication

Authentication is the act of proving an assertion, such as the identity of a computer system user.
User must enter a valid email and password to successfully authenticate.

@authentication
Scenario: Authentication on DevEdu web site
	Given Register new users with roles
	| FirstName | LastName | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Andrey      | Baikov   | string     | Andrey@student.com | Andrey     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Open authorization page
	And Enter email "Andrey@student.com"
	And Enter password "password"
	When Click button Enter
	Then Text with name on sidebar should be "Baikov Andrey"
	And Text with role on sidebar should be "Студент"
	And The notification page should open

@authentication
Scenario: Cancel authentication
	Given Register new users with roles
	| FirstName | LastName | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Andrey      | Baikov   | string     | Andrey@student.com | Andrey     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Open authorization page
	And Enter email "Andrey@student.com"
	And Enter password "password"
	When Click button Cancel
	Then Text in email textbox should be empty
	And Label in email textbox should be "example@mail.ru"
	And Text in password textbox should be empty

@authentication @negative
Scenario: Authentication with wrong password or email
	Given Register new users with roles
	| FirstName | LastName | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Andrey      | Baikov   | string     | Andrey@student.com | Andrey     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Open authorization page
	And Enter email "<Email>"
	And Enter password "<Password>"
	When Click button Enter
	Then Exception message under password textbox should appear with text "<Message>"
	Examples: 
	| Email            | Password   | Message                       |
	| maks@student.com | password   | Неправильные логин или пароль |
	| Andrey@student.com | passpass   | Неправильные логин или пароль |
	| Andrey@student.com | PASSWORD   | Неправильные логин или пароль |
	| Andrey@student.com | password11 | Неправильные логин или пароль |
	| Andrey@student.com | pass       | Неправильные логин или пароль |
	| Andrey@student.com |            | Введите пароль                |

@authentication @negative
Scenario: Authentication with wrong email format
	Given Register new users with roles
	| FirstName | LastName | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Andrey      | Baikov   | string     | Andrey@student.com | Andrey     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Open authorization page
	And Enter email "<Email>"
	And Enter password "password"
	When Click button Enter
	Then Exception message under email textbox should appear with text "Введен некорректный email"
	Examples: 
	| Email       |
	|             |
	| Andrey        |
	| Andrey@       |
	| Andrey@mail   |
	| Andrey@mail.  |
	| Andrey@mail.r |
	| Andrey@.ru    |
	| @mail.ru    |

@authentication @negative
Scenario: Authentication with empty email and password textboxes
Given Register new users with roles
	| FirstName | LastName | Patronymic | Email            | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Andrey      | Baikov   | string     | Andrey@student.com | Andrey     | password | SaintPetersburg | 02.07.2000 | string        | 89817051890 | Student |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Open authorization page
	And Enter email ""
	And Enter password ""
	When Click button Enter
	Then Exception message under email textbox should appear with text "Введен некорректный email"
	And Exception message under password textbox should appear with text "Введите пароль"