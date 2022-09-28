Feature: UserChangeProfilePhoto

@photo 
Scenario: User change photo in his profile
	Given Register new users with roles
	| FirstName | LastName   | Patronymic | Email             | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya1     | Baikov     | string     | ilya1@student.com | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	When Open DevEdu web site https://piter-education.ru:7074/
	And Authorize user in service
	| Email             | Password |
	| ilya1@student.com | password |
	And Open profile page
	And Click on photo
	And Add new photo "<PhotoName>"
	And Click save photo
	Then Modal window should disapier
	When Refresh page
	Then User should see the updated photo
	Examples: 
	| PhotoName      |
	| BigPhoto.png   |
	| SmallPhoto.jpg |