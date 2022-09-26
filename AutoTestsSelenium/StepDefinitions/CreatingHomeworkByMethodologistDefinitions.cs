namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CreatingHomeworkByMethodologistDefinitions
    {
        private IWebDriver _driver;

        [When(@"Methodist click button add task")]
        public void WhenMethodistClickButtonAddTask()
        {
            HomeworksMethodistPage homeworksMethodistPage;
            homeworksMethodistPage = new HomeworksMethodistPage();
            homeworksMethodistPage.ClickHomeworksButton();
            homeworksMethodistPage.ClickAddHomework();
        }

        [When(@"Methodist create draft Homework course name ""([^""]*)""")]
        public void WhenMethodistCreateDraftHomeworkCourseName(string courseName, Table table)
        {
            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
            HomeworkCreationMethodistPage homeworkMethodistPage;
            homeworkMethodistPage = new HomeworkCreationMethodistPage();
            homeworkMethodistPage.ClickChoiceGroupNumber(courseName);
            homeworkMethodistPage.InputNameGroup(createHomework.Name);
            homeworkMethodistPage.InputDescriptionHomework(createHomework.Description);
            homeworkMethodistPage.InputLinkHomework(createHomework.Link);
            homeworkMethodistPage.ClickButtonAttachLink();
        }

        [When(@"Methodist click button save as draft")]
        public void ThenMethodistClickButtonSaveAsDraft()
        {
            HomeworkCreationMethodistPage homeworkMethodistPage;
            homeworkMethodistPage = new HomeworkCreationMethodistPage();
            homeworkMethodistPage.ClickButtonSaveDraft();
        }

        [When(@"Methodist see all created homeworks")]
        public void WhenMethodistSeeAllCreatedHomeworks()
        {
            HomeworkCreationMethodistPage homeworkMethodistPage;
            homeworkMethodistPage = new HomeworkCreationMethodistPage();
            homeworkMethodistPage.ClickHomeworksButton();
            //TODO The methodologist does not see his drafts. emptiness(Task 2.3)
        }

        [When(@"Methodist click edit")]
        public void WhenMethodistClickLinkEdit()
        {
            throw new PendingStepException();
            //TODO (Task 2.3)
        }

        [When(@"Methodist edits homework")]
        public void WhenMethodistEditsHomework()
        {
            throw new PendingStepException();
            //TODO (Task 2.3)
        }

        [When(@"Methodist click button save draft")]
        public void WhenMethodistClickButtonSaveDraft()
        {
            throw new PendingStepException();
            //TODO(Task 2.3)
        }

        [When(@"Teacher click button homework assignment")]
        public void WhenTeacherClickButtonHomeworkAssignment()
        {
            HomeworkExtraditionTeacherPage homeworkExtraditionTeacherPage;
            homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            homeworkExtraditionTeacherPage.ClickHomeworksButton();
            homeworkExtraditionTeacherPage.ClickAddHomeworksButton();
        }

        [When(@"Teacher fill out a new assignment form course name ""([^""]*)""")]
        public void WhenTeacherFillOutANewAssignmentFormCourseName(string courseName, Table table)
        {
            HomeworkExtraditionTeacherPage homeworkExtraditionTeacherPage;
            homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            homeworkExtraditionTeacherPage.ClickRadioButtonGroupName(courseName);
            homeworkExtraditionTeacherPage.InputStarDate(homework.StartDate);
            homeworkExtraditionTeacherPage.InputEndDate(homework.EndDate);
            homeworkExtraditionTeacherPage.InputNameHomework(homework.Name);
            homeworkExtraditionTeacherPage.InputDescriptionHomework(homework.Description);
            homeworkExtraditionTeacherPage.InputUsefulLinks(homework.Link);
            homeworkExtraditionTeacherPage.ClickAddLink();
            //TODO No choice of job number. combobox not implemented (Task 2.3)
        }

        [When(@"Teacher click button publish")]
        public void WhenTeacherClickButtonPublish()
        {
            HomeworkExtraditionTeacherPage homeworkExtraditionTeacherPage;
            homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            homeworkExtraditionTeacherPage.ClickPublish();
        }

        [Then(@"Student should sees homework")]
        public void ThenStudentShouldSeesHomework()
        {
            HomeworksStudentPage homeworksStudentPage;
            homeworksStudentPage = new HomeworksStudentPage();
            homeworksStudentPage.ClickHomeworksButton();
            //TODO Homework does not appear. emptiness (Tasl 2.3)
        }
    }
}
