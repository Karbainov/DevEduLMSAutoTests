Feature: UserChangeProfilePhoto

@photo 
Scenario: User change photo in his profile
	Given Administrator registers new users with roles
	| FirstName | LastName   | Patronymic | Email             | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya1     | Baikov     | string     | ilya1@student.com | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	When Open DevEdu web site
	And Authorize user
	| Email             | Password |
	| ilya1@student.com | password |
	And Open profile page
	And Click on photo
	And Click on add new file
	And Add new photo 
	Then user should see the updated photo
	
