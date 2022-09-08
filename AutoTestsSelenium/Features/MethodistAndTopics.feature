Feature: MethodistAndTopics

A short summary of the feature

@tag1
Scenario:  Creating new topics by a methodist for students
	Given Open DevEducation web page
	When authorization user as methodist
	| Email                 | Password     |
	| maksim@example.com    | maksimmaksim |
	And methodist click "courses" button 
	And methodist choose course to edit and click "edit" button 
	And methodist add new topic 
	| TopicNumber | Name              | Duration |
	| 7           | Двумерные массивы | 12       |
	And methodist should see the updated topics in the course
	And methodist edit courses order 
	And methodist should see the updated order 
