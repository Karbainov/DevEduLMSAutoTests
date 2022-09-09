Feature: ManagerCancelCreationOfGroup

A short summary of the feature

@manager @group
Scenario: Manager cancel creation of group
	Given Open a browser and open a page
	Given Authorize as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	And Start create a group "Orange"
	When Cancel creation
	Then Group do not create
