Feature: UserChangeProfilePhoto

@photo 
Scenario: User set photo in his profile
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email             | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya1     | Baikov     | string     | ilya1@student.com | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service
	| Email             | Password |
	| ilya1@student.com | password |
	When Open profile page by click on users name
	And Click on photo
	And Add photo "<PhotoName>"
	And Click save photo
	Then Modal window should disapier
	When Refresh page
	Then User should see his photo
	Examples: 
	| PhotoName      |
	| BigPhoto.png   |
	| SmallPhoto.jpg |

@photo
Scenario: User cancel adding photo
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email             | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya1     | Baikov     | string     | ilya1@student.com | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	And Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service
	| Email             | Password |
	| ilya1@student.com | password |
	When Open profile page by click on users name
	And Click on photo
	And Add photo "SmallPhoto.jpg"
	And Click cancel button
	And Refresh page
	Then Photo should not appear 

@photo
Scenario: User change photo in profile
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email             | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya1     | Baikov     | string     | ilya1@student.com | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	And Authorize user in service
	| Email             | Password |
	| ilya1@student.com | password |
	When Open profile page by click on users name
	And Click on photo
	And Add photo "SmallPhoto.jpg"
	And Click save photo
	Then Modal window should disapier
	When Refresh page
	Then User should see his photo
	When Click on photo
	And Add photo "BigPhoto.png"
	And Click save photo
	Then Modal window should disapier
	When Refresh page
	Then User should see the updated photo