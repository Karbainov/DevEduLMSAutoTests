Feature: Registration

@registration @student
Scenario: User registration
	Given Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber   |
	| Мистер    | Проппер  | Иванов     | 31.07.1998 | Azino777 | Azino777       | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox 
	When Click on register button
	Then User should see the welcome modal window
	And Click on athorization sidebar button
	And Authorize user in service  
	And Click on user's profile 
	Then User should see his actual information 