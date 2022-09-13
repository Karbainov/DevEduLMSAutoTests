Feature: Registration

Scenario: User registration
	Given Open registration page
	And Fill all requared fields
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email         | Phone        |
	And Click on private policy checkbox 
	When Click on register button

