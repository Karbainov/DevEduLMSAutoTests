Feature: SpecialTwoPointFive

A short summary of the feature

@tag1
Scenario:  Creating an assignment by a methodologist for students
Given Open DevEdu web page
When authorization user as methodist
And methodist click botton to come in
And methodist chooses the role of methodist 
#супер тупо, но при входе нужно это выбрать,хотя ты уже зашел подметоистом его меил ипароль
And methodist click button add task
When methodist create draft Homework
And methodist click button save as draft
And methodist see all created homeworks
When methodist click link edit
And methodist edits homework
And methodist click button save as draft
And Authorization in as a teacher
And teacher click buttom homework assignment
And teacher fill out a new assignment form
When teacher click button publish
Then student should sees homework






