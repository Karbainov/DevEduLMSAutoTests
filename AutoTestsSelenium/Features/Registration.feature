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
Scenario: User try to registration with empty First Name textbox
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	|           | Проппер  | Иваныч     | 31.07.1998 | Azino777 | Azino777       | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message empty First Name "Необходимо ввести имя" should appear

@registration @negative
Scenario: User try to registration with empty Last Name textbox
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	| Мистер    |          | Иваныч     | 31.07.1998 | Azino777 | Azino777       | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message empty Last Name "Необходимо ввести фамилию" should appear

@registration @negative
Scenario: User try to registration with empty Email textbox
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email | PhoneNumber  |
	| Мистер    | Проппер  | Иваныч     | 31.07.1998 | Azino777 | Azino777       |       | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message Email "Необходимо ввести Email" should appear

@registration @negative
Scenario: User try to registration with wrong data format in Birth Date textbox
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate | Password | RepeatPassword | Email             | PhoneNumber  |
	| Mister    | Проппер  | Иваныч     | 31.07.199 | Azino777 | Azino777       | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message wrong Date Birth "Введите корректную дату" should appear

@registration @negative
Scenario: User try to registration with empty password textbox
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	| Мистер    | Проппер  | Иваныч     | 31.07.1998 |          | Azino777       | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message Password "Обязательно для заполнения" should appear

@registration @negative
Scenario: User try to registration with empty repeat password textbox
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	| Мистер    | Проппер  | Иваныч     | 31.07.1998 | Azino777 |                | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message Repeat Password "Обязательно для заполнения" should appear

@registration @negative
Scenario: User try to registration with password shorter than shorter than eight characters
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	| Мистер    | Проппер  | Иваныч     | 31.07.1998 | Azino    | Azino777       | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message Password "Минимальная длина - 8 знаков" should appear

@registration @negative
Scenario: User try to registration with repeat password shorter than shorter than eight characters
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	| Мистер    | Проппер  | Иваныч     | 31.07.1998 | Azino    | Azino          | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message Repeat Password "Минимальная длина - 8 знаков" should appear

@registration @negative
Scenario: User try to registration with different password and repeat password textboxes
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	| Мистер    | Проппер  | Иваныч     | 31.07.1998 | Azino777 | Azino778       | propper12@mail.ru | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message Repeat Password "Пароли не совпадают" should appear

@registration @negative
Scenario: User try to registration with wrong Email format
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email     | PhoneNumber  |
	| Мистер    | Проппер  | Иваныч     | 31.07.1998 | Azino777 | Azino777       | propper12 | +79992314545 |
	And Click on private policy checkbox
	When Click on register button
	Then Excaption message Email "Введите корректный Email" should appear

@registration @negative
Scenario: User try to registration with correct information but doesn't click on private policy checkbox
	Given Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber  |
	| Мистер    | Проппер  | Иваныч     | 31.07.1998 | Azino777 | Azino777       | propper12@mail.ru | +79992314545 |
	When Click on register button
	Then Excaption message Private policy "Для регистрации необходимо указать согласие с политикой конфиденциальности" should appear

@registration @negative
Scenario: User try to register an account with an already registered email
	Given Administrator registers new users with roles
	| FirstName | LastName   | Patronymic | Email             | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | Role    |
	| Ilya1     | Baikov     | string     | ilya1@student.com | ilya1    | password | SaintPetersburg | 23.07.1993 | string        | 89998887766 | Student |
	And Open DevEdu web site
	And Open registration page
	And Fill all requared fields
	| FirstName | LastName | Patronymic | BirthDate  | Password | RepeatPassword | Email             | PhoneNumber   |
	| Мистер    | Проппер  | Иванов     | 31.07.1998 | Azino777 | Azino777       | ilya1@student.com | +79992314545 |
	And Click on private policy checkbox 
	When Click on register button
	Then User should see the exception modal window	with text "Данный Email уже зарегистрирован"