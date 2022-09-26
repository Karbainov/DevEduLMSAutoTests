namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class LessonsStepDefinitions
    {
        [Given(@"Click on create lesson")]
        public void GivenClickOnCreateLesson()
        {
            var lessonsTeacherPage = new LessonsTeacherPage();
            lessonsTeacherPage.ClickAddLessonButton();
        }
        //TODO: the next page is empty
    }
}
