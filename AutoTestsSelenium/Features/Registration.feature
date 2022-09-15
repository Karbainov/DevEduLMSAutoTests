Feature: Registration

Scenario: User registration
	Given Open registration page
	And Click on registration on sidebar
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email           | PhoneNumber  |
	| Мистер    | Проппер  | Иванов     | 31.07.1998 | Azino777 | Azino777       | propper@mail.ru | +79992314545 |
	And Click on private policy checkbox 
	When Click on register button
	And Click on athorization sidebar button 
	And Authorize user in service  
	And click on user's profile 
	Then user should see his actual information 

