namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        public GroupsStepDefinitions()
        {
        }

        [When(@"Click button create group")]
        public void WhenClickButtonCreateGroup()
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            groupCreationManagerPage.ClickAddGroupButton();
        }
        
        [When(@"Fills in group data")]
        public void WhenFillsInGroupData(Table table)
        {
            GroupCreationModel newGroup = table.CreateInstance<GroupCreationModel>();
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            if(newGroup.GroupName != "")
            {
                groupCreationManagerPage.EnterGroupName(newGroup.GroupName);
            }
            if (newGroup.CourseName != "")
            {
                groupCreationManagerPage.ClickCoursesComboBox();
                groupCreationManagerPage.ClickDesiredCourseByName(newGroup.CourseName);
            }
            if (newGroup.FullNameOfTeacher != "")
            {
                groupCreationManagerPage.ChooseTeacher(newGroup.FullNameOfTeacher);
            }
            if (newGroup.FullNameOfTutor != "")
            {
                groupCreationManagerPage.ChooseTutor(newGroup.FullNameOfTutor);
            }
        }

        [When(@"Fills in edit group data")]
        public void WhenFillsInEditGroupData(Table table)
        {
            GroupCreationModel newGroup = table.CreateInstance<GroupCreationModel>();
            GroupEditingManagerPage groupEditingManagerPage = new GroupEditingManagerPage();
            if (newGroup.GroupName != "")
            {
                groupEditingManagerPage.EnterGroupName(newGroup.GroupName);
            }
            if (newGroup.CourseName != "")
            {
                groupEditingManagerPage.ClickCoursesComboBox();
                groupEditingManagerPage.ClickDesiredCourseByName(newGroup.CourseName);
            }
            if (newGroup.FullNameOfTeacher != "")
            {
                groupEditingManagerPage.ChooseTeacher(newGroup.FullNameOfTeacher);
            }
            if (newGroup.FullNameOfTutor != "")
            {
                groupEditingManagerPage.ChooseTutor(newGroup.FullNameOfTutor);
            }
        }

        [When(@"Saves group")]
        public void WhenSavesGroup()
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            groupCreationManagerPage.ClickSaveButton();
            //TODO Saves only when there are more than two teachers and tutors (Task 2.6).
        }

        [When(@"Saves edit group")]
        public void WhenSavesEditGroup()
        {
            GroupEditingManagerPage groupEditingManagerPage = new GroupEditingManagerPage();
            groupEditingManagerPage.ClickExitButton();
            //TODO Saves only when there are more than two teachers and tutors (Task 2.17).
        }

        [When(@"Cancels creation of group")]
        public void WhenCancelsCreationOfGroup()
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            groupCreationManagerPage.ClickCancelCreateGroupButton();
        }

        [When(@"Click button students list")]
        public void WhenClickButtonStudentsList()
        {
            StudentsListManagerPage studentsListPage = new StudentsListManagerPage();
            studentsListPage.ClickStudentsListButton();
        }

        [When(@"Click button groups")]
        public void WhenClickButtonGroups()
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            groupsManagerPage.ClickGroupsButton();
        }

        [When(@"Click button group with name ""([^""]*)""")]
        public void WhenClickButtonGroupWithName(string groupName)
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            groupsManagerPage.ChooseGroup(groupName);
        }

        [When(@"Click button edit")]
        public void WhenClickButtonEdit()
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            groupsManagerPage.ClickEditButton();
        }

        [When(@"Additing student ""([^""]*)"" to group ""([^""]*)""")]
        public void WhenManagerAddStudentToGroup(string fullNameOfStudent, string groupName)
        {
            StudentsListManagerPage studentsListPage = new StudentsListManagerPage();
            studentsListPage.ClickByFullNameOfStudentComboBox(fullNameOfStudent);
            studentsListPage.ClickDesiredGroupByName(groupName);
            //TODO The page is implemented as a mock (Task 2.6).
        }

        [When(@"Click button lessons as student")]
        public void WhenClickButtonLessonsAsStudent()
        {
            LessonsStudentPage lessonsStudentPage = new LessonsStudentPage();
            lessonsStudentPage.ClickLessonsButton();
        }

        [When(@"Click button lessons as teacher")]
        public void WhenClickButtonLessonsAsTeacher()
        {
            LessonsTeacherPage lessonsTeacherPage = new LessonsTeacherPage();
            lessonsTeacherPage.ClickLessonsButton();
        }

        [When(@"Click button lessons as tutor")]
        public void WhenClickButtonLessonsAsTutor()
        {
            LessonsTutorPage lessonsTutorPage = new LessonsTutorPage();
            lessonsTutorPage.ClickLessonsButton();
        }

        [Then(@"Student checks presence of group by name course ""([^""]*)""")]
        public void ThenStudentChecksPresenceOfGroupByNameCourse(string courseName)
        {
            LessonsStudentPage lessonsStudentPage = new LessonsStudentPage();
            var groups = lessonsStudentPage.StudentGroups;
            Assert.Contains(groups, i => i.Text == courseName);
        }

        [Then(@"Teacher checks presence of group by name course ""([^""]*)""")]
        public void ThenTeacherChecksPresenceOfGroupByNameCourse(string courseName)
        {
            LessonsTeacherPage lessonsTeacherPage = new LessonsTeacherPage();
            var groups = lessonsTeacherPage.TeacherGroups;
            Assert.Contains(groups, i => i.Text == courseName);
        }

        [Then(@"Tutor checks presence of group by name course ""([^""]*)""")]
        public void ThenTutorChecksPresenceOfGroupByNameCourse(string courseName)
        {
            LessonsTutorPage lessonsTutorPage = new LessonsTutorPage();
            var groups = lessonsTutorPage.TutorGroups;
            Assert.Contains(groups, i => i.Text == courseName);
        }

        [Then(@"Manager checks absence of group ""([^""]*)"" in list groups")]
        public void ThenManagerChecksAbsenceOfGroupInListGroups(string groupName)
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            var groups = groupsManagerPage.AllGroups;
            Assert.DoesNotContain(groups, i => i.Text == groupName);
        }

        [Then(@"Manager checks for presence of group ""([^""]*)"" in list groups")]
        public void ThenManagerChecksForPresenceOfGroupInListGroups(string groupName)
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            var groups = groupsManagerPage.AllGroups;
            Assert.Contains(groups, i => i.Text == groupName);
        }

        [Then(@"Error message about absence of group name must match text ""([^""]*)""")]
        public void ThenErrorMessageAboutAbsenceOfGroupNameMustMatchText(string expectedErrorMessage)
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            string actualErrorMessage = groupCreationManagerPage.LabelEmptyGroupName.Text;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Then(@"Error message about absence of selected course must match text ""([^""]*)""")]
        public void ThenErrorMessageAboutAbsenceOfSelectedCourseMustMatchText(string expectedErrorMessage)
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            string actualErrorMessage = groupCreationManagerPage.LabelEmptyCourseComboBox.Text;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
            //TODO Message does not appear that the course is not selected (Task 2.6.2)
        }

        [Then(@"Error message about absence of a teacher's choice should correspond to text ""([^""]*)""")]
        public void ThenErrorMessageAboutAbsenceOfATeachersChoiceShouldCorrespondToText(string expectedErrorMessage)
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            string actualErrorMessage = groupCreationManagerPage.LabelEmptyTeacherCheckBox.Text;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Then(@"Should be a teacher in group ""([^""]*)"" and should not be a teacher ""([^""]*)""")]
        public void ThenShouldBeATeacherInGroupAndShouldNotBeATeacher(string newTeacher, string oldTeacher)
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            var teachers = groupsManagerPage.TeachersInGroup;
            Assert.Contains(teachers, i => i.Text == newTeacher);
            Assert.DoesNotContain(teachers, i => i.Text == oldTeacher);
        }

        [Then(@"Should be a tutor in group ""([^""]*)"" and should not be a tutor ""([^""]*)""")]
        public void ThenShouldBeATutorInGroupAndShouldNotBeATutor(string newTutor, string oldTutor)
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            var tutors = groupsManagerPage.TeachersInGroup;
            Assert.Contains(tutors, i => i.Text == newTutor);
            Assert.DoesNotContain(tutors, i => i.Text == oldTutor);
        }
    }
}