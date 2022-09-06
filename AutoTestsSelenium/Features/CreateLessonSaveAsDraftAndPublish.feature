Feature: CreateLessonSaveAsDraftAndPublish

A short summary of the feature

@tag1
Scenario: Teacher create lesson as draft, save it and publish.
	Given Open a browser and go to devedu page
	Given Login as teacher
	| Email             | Password   |
	| anton@example.com | antonanton |
	And Click on create lesson

