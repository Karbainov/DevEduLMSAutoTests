namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        public GroupsStepDefinitions()
        {
        }

        [Given(@"Register new users with roles")]
        public void GivenRegisterNewUsersWithRoles(Table table)
        {
            GroupsAPIStepDefinitions managerCreatesAGroupAddsUsersBySwagger = new GroupsAPIStepDefinitions();
            managerCreatesAGroupAddsUsersBySwagger.GivenRegisterNewUsersWithRolesInService(table);
        }

        [When(@"Open authorization page")]
        public void WhenOpenAuthorizationPage()
        {
            AuthorizationUnauthorizedPage authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage();
            authorizationUnauthorizedPage.OpenThisPage();
        }

        [When(@"SignIn user in service as manager")]
        [When(@"SignIn user in service as student")]
        [When(@"SignIn user in service as teacher")]
        [When(@"SignIn user in service as tutor")]
        public void WhenSignInUserInServiceAsManager(Table table)
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

        [When(@"Saves group")]
        public void WhenSavesGroup()
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            groupCreationManagerPage.ClickSaveButton();
            //TODO Saves only when there are more than two teachers and tutors (Task 2.6).
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
            StudentsListPage studentsListPage = new StudentsListPage();
            studentsListPage.ClickStudentsListButton();
        }

        [When(@"Click button groups")]
        public void WhenClickButtonGroups()
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            groupsManagerPage.ClickGroupsButton();
        }

        [When(@"Additing student ""([^""]*)"" to group ""([^""]*)""")]
        public void WhenManagerAddStudentToGroup(string fullNameOfStudent, string groupName)
        {
            StudentsListPage studentsListPage = new StudentsListPage();
            studentsListPage.ClickGroupsComboBoxByFullNameOfStudent(fullNameOfStudent);
            studentsListPage.ClickDesiredGroupByName(groupName);
            //TODO The page is implemented as a mock (Task 2.6).
        }

        [When(@"Exit account as manager")]
        public void WhenExitAccountAsManager()
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

        [Then(@"Manager checks group ""([^""]*)"" in list groups")]
        public void ThenManagerChecksGroupInListGroups(string groupName)
        {
            GroupsManagerPage groupsManagerPage = new GroupsManagerPage();
            var groups = groupsManagerPage.AllGroups;
            Assert.DoesNotContain(groups, i => i.Text == groupName);
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
    }
}
