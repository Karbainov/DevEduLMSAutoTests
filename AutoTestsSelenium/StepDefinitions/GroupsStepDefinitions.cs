namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        public GroupsStepDefinitions()
        {
        }

        [Given(@"Open authorization page")]
        public void GivenOpenAuthorizationPage()
        {
            AuthorizationUnauthorizedPage authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage();
            authorizationUnauthorizedPage.OpenThisPage();
        }

        [Given(@"SignIn user in service as manager")]
        [When(@"SignIn user in service as student")]
        [When(@"SignIn user in service as teacher")]
        [When(@"SignIn user in service as tutor")]
        public void GivenSignInUserInServiceAsManager(Table table)
        {
            AuthorizationUnauthorizedPage authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage();
            SwaggerSignInRequest user = table.CreateInstance<SwaggerSignInRequest>();
            authorizationUnauthorizedPage.EnterEmail(user.Email);
            authorizationUnauthorizedPage.EnterPassword(user.Password);
            authorizationUnauthorizedPage.ClickEnterButton();
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
            groupCreationManagerPage.EnterGroupName(newGroup.GroupName);
            groupCreationManagerPage.ClickCoursesComboBox();
            groupCreationManagerPage.ClickDesiredCourseByName(newGroup.CourseName);
            groupCreationManagerPage.ChooseTeacher(newGroup.FullNameOfTeacher);
            groupCreationManagerPage.ChooseTutor(newGroup.FullNameOfTutor);
        }

        [When(@"Fills in edit group data")]
        public void WhenFillsInEditGroupData(Table table)
        {
            GroupCreationModel newGroup = table.CreateInstance<GroupCreationModel>();
            GroupEditingManagerPage groupEditingManagerPage = new GroupEditingManagerPage();
            groupEditingManagerPage.EnterGroupName(newGroup.GroupName);
            groupEditingManagerPage.ClickCoursesComboBox();
            groupEditingManagerPage.ClickDesiredCourseByName(newGroup.CourseName);
            groupEditingManagerPage.ChooseTeacher(newGroup.FullNameOfTeacher);
            groupEditingManagerPage.ChooseTutor(newGroup.FullNameOfTutor);
        }

        [When(@"Click button saves group")]
        public void WhenClickButtonSavesGroup()
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            groupCreationManagerPage.ClickSaveButton();
            //TODO Saves only when there are more than two teachers and tutors (Task 2.6).
        }

        [When(@"Click button saves edit group")]
        public void WhenClickButtonSavesEditGroup()
        {
            GroupEditingManagerPage groupEditingManagerPage = new GroupEditingManagerPage();
            groupEditingManagerPage.ClickSaveButton();
            //TODO Saves only when there are more than two teachers and tutors (Task 2.17).
        }

        [When(@"Click button cancels creation of group")]
        public void WhenClickButtonCancelsCreationOfGroup()
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            groupCreationManagerPage.ClickCancelCreateGroupButton();
        }

        [When(@"Click button cancels editing of group")]
        public void WhenClickButtonCancelsEditingOfGroup()
        {
            GroupEditingManagerPage groupEditingManagerPage = new GroupEditingManagerPage();
            groupEditingManagerPage.ClickCancelEditGroupButton();
        }

        [When(@"Click button students list")]
        public void WhenClickButtonStudentsList()
        {
            StudentsListManagerPage studentsListManagerPage = new StudentsListManagerPage();
            studentsListManagerPage.ClickStudentsListButton();
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
            StudentsListManagerPage studentsListManagerPage = new StudentsListManagerPage();
            studentsListManagerPage.ClickByFullNameOfStudentComboBox(fullNameOfStudent);
            studentsListManagerPage.ClickDesiredGroupByName(groupName);
            //TODO The page is implemented as a mock (Task 2.6).
        }

        [When(@"Click button exit of account as manager")]
        public void WhenClickButtonExitOfAccountAsManager()
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            groupCreationManagerPage.ClickExitButton();
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

        [Then(@"Manager should not find group ""([^""]*)"" in list groups")]
        public void ThenManagerShouldNotFindGroupInListGroups(string groupName)
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            var groups = groupsManagerPage.AllGroups;
            Assert.DoesNotContain(groups, i => i.Text == groupName);
        }

        [Then(@"Manager should find group ""([^""]*)"" in list groups")]
        public void ThenManagerShouldFindGroupInListGroups(string groupName)
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            var groups = groupsManagerPage.AllGroups;
            Assert.Contains(groups, i => i.Text == groupName);
        }

        [Then(@"Error message about absence of a group name, when creating a group should be ""([^""]*)""")]
        public void ThenErrorMessageAboutAbsenceOfAGroupNameWhenCreatingAGroupShouldBe(string expectedErrorMessage)
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            string actualErrorMessage = groupCreationManagerPage.LabelEmptyGroupName.Text;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Then(@"Error message about lack of course selection, when creating a group should be ""([^""]*)""")]
        public void ThenErrorMessageAboutLackOfCourseSelectionWhenCreatingAGroupShouldBe(string expectedErrorMessage)
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            string actualErrorMessage = groupCreationManagerPage.LabelEmptyCourseComboBox.Text;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
            //TODO Message does not appear that the course is not selected (Task 2.6.2)
        }

        [Then(@"Error message about lack of teacher selection, when creating a group should be ""([^""]*)""")]
        public void ThenErrorMessageAboutLackOfTeacherSelectionWhenCreatingAGroupShouldBe(string expectedErrorMessage)
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            string actualErrorMessage = groupCreationManagerPage.LabelEmptyTeacherCheckBox.Text;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Then(@"Error message about absence of group name, when editing group should be ""([^""]*)""")]
        public void ThenErrorMessageAboutAbsenceOfGroupNameWhenEditingGroupShouldBe(string expectedErrorMessage)
        {
            GroupEditingManagerPage groupEditingManagerPage = new GroupEditingManagerPage();
            string actualErrorMessage = groupEditingManagerPage.LabelEmptyGroupName.Text;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Then(@"Error message about lack of course selection, when editing group should be ""([^""]*)""")]
        public void ThenErrorMessageAboutLackOfCourseSelectionWhenEditingGroupShouldBe(string expectedErrorMessage)
        {
            GroupEditingManagerPage groupEditingManagerPage = new GroupEditingManagerPage();
            string actualErrorMessage = groupEditingManagerPage.LabelEmptyCourseComboBox.Text;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
            //TODO Message does not appear that the course is not selected (Task 2.17.6)
        }

        [Then(@"Error message about lack of teacher selection, when editing group should be ""([^""]*)""")]
        public void ThenErrorMessageAboutLackOfTeacherSelectionWhenEditingGroupShouldBe(string expectedErrorMessage)
        {
            GroupEditingManagerPage groupEditingManagerPage = new GroupEditingManagerPage();
            string actualErrorMessage = groupEditingManagerPage.LabelEmptyTeacherCheckBox.Text;
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
