namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        [When(@"Click button create group")]
        public void WhenClickButtonCreateGroup()
        {
            var page = new GroupCreationManagerPage();
            page.ClickAddGroupButton();
        }

        [When(@"Fills in group data")]
        public void WhenFillsInGroupData(Table table)
        {
            var newGroup = table.CreateInstance<GroupCreationModel>();
            var page = new GroupCreationManagerPage();
            page.EnterGroupName(newGroup.GroupName);
            page.ClickCoursesComboBox();
            page.ClickDesiredCourseByName(newGroup.CourseName);
            page.ChooseTeacher(newGroup.FullNameOfTeacher);
            page.ChooseTutor(newGroup.FullNameOfTutor);
        }

        [When(@"Fills in edit group data")]
        public void WhenFillsInEditGroupData(Table table)
        {
            var newGroup = table.CreateInstance<GroupCreationModel>();
            var page = new GroupEditingManagerPage();
            page.EnterGroupName(newGroup.GroupName);
            page.ClickCoursesComboBox();
            page.ClickDesiredCourseByName(newGroup.CourseName);
            page.ChooseTeacher(newGroup.FullNameOfTeacher);
            page.ChooseTutor(newGroup.FullNameOfTutor);
        }

        [When(@"Click button saves group")]
        public void WhenClickButtonSavesGroup()
        {
            var page = new GroupCreationManagerPage();
            page.ClickSaveButton();
            //TODO Saves only when there are more than two teachers and tutors (Task 2.6).
        }

        [When(@"Click button saves edit group")]
        public void WhenClickButtonSavesEditGroup()
        {
            var page = new GroupEditingManagerPage();
            page.ClickSaveButton();
            //TODO Saves only when there are more than two teachers and tutors (Task 2.17).
        }

        [When(@"Click button cancels creation of group")]
        public void WhenClickButtonCancelsCreationOfGroup()
        {
            var page = new GroupCreationManagerPage();
            page.ClickCancelCreateGroupButton();
        }

        [When(@"Click button cancels editing of group")]
        public void WhenClickButtonCancelsEditingOfGroup()
        {
            var page = new GroupEditingManagerPage();
            page.ClickCancelEditGroupButton();
        }

        [When(@"Click button students list")]
        public void WhenClickButtonStudentsList()
        {
            var page = new StudentsListManagerPage();
            page.ClickStudentsListButton();
        }

        [When(@"Click button groups")]
        public void WhenClickButtonGroups()
        {
            var page = new GroupsManagerPage();
            page.ClickGroupsButton();
        }

        [When(@"Click button group with name ""([^""]*)""")]
        public void WhenClickButtonGroupWithName(string groupName)
        {
            var page = new GroupsManagerPage();
            page.ChooseGroup(groupName);
        }

        [When(@"Click button edit")]
        public void WhenClickButtonEdit()
        {
            var page = new GroupsManagerPage();
            page.ClickEditButton();
        }

        [When(@"Additing student ""([^""]*)"" to group ""([^""]*)""")]
        public void WhenManagerAddStudentToGroup(string fullNameOfStudent, string groupName)
        {
            var page = new StudentsListManagerPage();
            page.ClickByFullNameOfStudentComboBox(fullNameOfStudent);
            page.ClickDesiredGroupByName(groupName);
            //TODO The page is implemented as a mock (Task 2.6).
        }

        [When(@"Click button lessons as student")]
        public void WhenClickButtonLessonsAsStudent()
        {
            var page = new LessonsStudentPage();
            page.ClickLessonsButton();
        }

        [When(@"Click button lessons as teacher")]
        public void WhenClickButtonLessonsAsTeacher()
        {
            var page = new LessonsTeacherPage();
            page.ClickLessonsButton();
        }

        [When(@"Click button lessons as tutor")]
        public void WhenClickButtonLessonsAsTutor()
        {
            var page = new LessonsTutorPage();
            page.ClickLessonsButton();
        }

        [Then(@"Student checks presence of group by name course ""([^""]*)""")]
        public void ThenStudentChecksPresenceOfGroupByNameCourse(string courseName)
        {
            var page = new LessonsStudentPage();
            var groups = page.StudentGroups;
            Assert.Contains(groups, i => i.Text == courseName);
        }

        [Then(@"Teacher checks presence of group by name course ""([^""]*)""")]
        public void ThenTeacherChecksPresenceOfGroupByNameCourse(string courseName)
        {
            var page = new LessonsTeacherPage();
            var groups = page.TeacherGroups;
            Assert.Contains(groups, i => i.Text == courseName);
        }

        [Then(@"Tutor checks presence of group by name course ""([^""]*)""")]
        public void ThenTutorChecksPresenceOfGroupByNameCourse(string courseName)
        {
            var page = new LessonsTutorPage();
            var groups = page.TutorGroups;
            Assert.Contains(groups, i => i.Text == courseName);
        }

        [Then(@"Manager should not find group ""([^""]*)"" in list groups")]
        public void ThenManagerShouldNotFindGroupInListGroups(string groupName)
        {
            var page = new GroupsManagerPage();
            var groups = page.AllGroups;
            Assert.DoesNotContain(groups, i => i.Text == groupName);
        }

        [Then(@"Manager should find group ""([^""]*)"" in list groups")]
        public void ThenManagerShouldFindGroupInListGroups(string groupName)
        {
            var page = new GroupsManagerPage();
            var groups = page.AllGroups;
            Assert.Contains(groups, i => i.Text == groupName);
        }

        [Then(@"Error message about absence of group data, when creating group should be ""([^""]*)""")]
        public void ThenErrorMessageAboutAbsenceOfGroupDataWhenCreatingGroupShouldBe(string expectedErrorMessege)
        {
            var page = new GroupCreationManagerPage();
            var actualElement = page.GetLabelElement(expectedErrorMessege);
            Assert.Equal(expectedErrorMessege, actualElement.Text);
            //TODO Message does not appear that the course is not selected (Task 2.6.2)
        }

        [Then(@"Error message about absence of group data, when editing group should be ""([^""]*)""")]
        public void ThenErrorMessageAboutAbsenceOfGroupDataWhenEditingGroupShouldBe(string expectedErrorMessege)
        {
            var page = new GroupEditingManagerPage();
            var actualElement = page.GetLabelElement(expectedErrorMessege);
            Assert.Equal(expectedErrorMessege, actualElement.Text);
            //TODO Message does not appear that the course is not selected (Task 2.17.6)
        }

        [Then(@"Should be a teachers and tutors in group")]
        public void ThenShouldBeATeachersAndTutorsInGroup(Table table)
        {
            var users = table.CreateInstance<GroupCreationModel>();
            var page = new GroupsManagerPage();
            var actualTeachers = page.TeachersInGroup.ConvertAll<string>(new Converter<IWebElement, string>(ChangeIwebelementToStringType));
            var actualTutors = page.TutorsInGroup.ConvertAll<string>(new Converter<IWebElement, string>(ChangeIwebelementToStringType));
            Assert.Equivalent(users.FullNameOfTeacher, actualTeachers);
            Assert.Equivalent(users.FullNameOfTutor, actualTutors);
        }

        private string ChangeIwebelementToStringType(IWebElement element)
        {
            return element.Text;
        }
    }
}