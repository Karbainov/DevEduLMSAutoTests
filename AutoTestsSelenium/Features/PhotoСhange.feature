Feature: PhotoСhange

User changes photo

@tag1
Scenario: User changes photo
	Given Open a browser in DevEducation web page
	When Enter login "marina@example.com"
	And Enter password "marinamarina"
	Then Click button account login
	Given Go to account settings
	When Photo change
	Then Save changes