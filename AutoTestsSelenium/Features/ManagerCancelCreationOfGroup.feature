Feature: ManagerCancelCreationOfGroup

A short summary of the feature

@manager @group
Scenario: Manager cancel creation of group
	Given Authorize as manager
	| Email              | Password     |
	| marina@example.com | marinamarina |
	And Start create a group
	When Cancel creation
	Then Group do not create
