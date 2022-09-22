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
	When Click on athorization sidebar button
	And Authorize user in service  
	And Click on user's profile 
	Then User should see his actual information 

@registration @negative
Scenario: User try to registration with empty Last Name textbox
	Given Open DevEdu web site
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	| Мистер    |          | Иваныч     | 31.07.1998 | Azino777 | Azino777       | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message empty Last Name "Необходимо ввести фамилию" should appear

@registration @negative
Scenario: User try to registration with epty First Name textbox
	Given Open DevEdu web site
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	|           | Проппер  | Иваныч     | 31.07.1998 | Azino777 | Azino777       | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message empty First Name "Необходимо ввести имя" should appear

@registration @negative
Scenario: User try to registration with epty Email textbox
	Given Open DevEdu web site
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email | PhoneNumber  |
	| Мистер    | Проппер  | Иваныч     | 31.07.1998 | Azino777 | Azino777       |       | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message empty Email "Необходимо ввести Email" should appear