Feature: SpecialTwoPointFive

A short summary of the feature

@tag1
Scenario:  Creating an assignment by a methodologist for students
Given Open DevEdu web page
When Enter the username and password of the methodologist
And Click botton "to come in"
And Click button "add task"
When Create draft Homework
And Click button "save as draft"
And See all created homeworks
When Click link "edit"
And Methodist edits homework
And Click button "save as draft"
And Authorization in as a teacher
And Click buttom "homework assignment", 
And Fill out a new assignment form
When Click button "publish"
Then student should sees homework






