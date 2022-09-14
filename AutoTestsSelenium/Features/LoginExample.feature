Feature: LoginExample

Scenario: Email validation
	Given Open login page
	When Enter "QQQQQ" and "wwwww"
	Then Incerrect email text should apier

Scenario: Incorrect autorization validation
	Given Open login page
	When Enter <Mail> and <Password>
	Then Incerrect email or password text should apier
Examples:
| Mail               | Password |
| "QQQ@mail.ru"      | "QQQQ"   |
| "user@example.com" | "QQQQ"   |