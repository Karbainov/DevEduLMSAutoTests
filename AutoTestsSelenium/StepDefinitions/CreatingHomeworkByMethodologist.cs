namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CreatingHomeworkByMethodologist
    {
        private IWebDriver _driver;
        private SingInWindow _singInWindow;
        private MethodistHomeworkWindow _methodistHomeworkWindow;

        CreatingHomeworkByMethodologist()
        {
            _driver = SingleWebDriver.GetInstance();
            _singInWindow = new SingInWindow();
            _methodistHomeworkWindow = new MethodistHomeworkWindow();       
        }              

        [Given(@"Open DevEdu web page")]
        public void GivenOpenDevEduWebPage()
        {
            
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl($"https://piter-education.ru:7074/login");
        }

        [When(@"authorization user as methodist")]
        public void WhenAuthorizationUserAsMethodist(Table table)
        {
            SwaggerSignInRequest singInRequest = table.CreateInstance<SwaggerSignInRequest>();
            var emailBox = _driver.FindElement(_singInWindow.XPathEmailBox);
            emailBox.SendKeys(singInRequest.Email);
            var passBox = _driver.FindElement(_singInWindow.XPathPasswordBox);
            passBox.Clear();
            passBox.SendKeys(singInRequest.Password);
        }

        [When(@"methodist click botton to come in")]
        public void WhenMethodistClickBottonToComeIn()
        {
            _driver.FindElement(_singInWindow.XPathSingInButton).Click();
            Thread.Sleep(1000);
        }

        [When(@"methodist click button add task")]
        public void WhenMethodistClickButtonAddTask()
        {
            _driver.FindElement(_methodistHomeworkWindow.XPathHomeworkButton).Click();
            _driver.FindElement(_methodistHomeworkWindow.XpathCreateHomework).Click();
            Thread.Sleep(1000);
        }

        [When(@"methodist create draft Homework")]
        public void WhenMethodistCreateDraftHomework(Table table)
        {
            _driver.FindElement(_methodistHomeworkWindow.XpathChoiceGroupNumber).Click();
            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
            var nameHomework = _driver.FindElement(_methodistHomeworkWindow.XpathNameCreateHomework);
            nameHomework.SendKeys(createHomework.Name);
            var textInput = _driver.FindElement(_methodistHomeworkWindow.XpathDescriptionHomework);
            textInput.SendKeys(createHomework.Description);
            var linkInput = _driver.FindElement(_methodistHomeworkWindow.XpathLinkInputHomework);
            linkInput.SendKeys(createHomework.Link);
        }

        [Then(@"methodist click button save as draft")]
        public void ThenMethodistClickButtonSaveAsDraft()
        {
            _driver.FindElement(_methodistHomeworkWindow.XpathButtonSaveDraftHomework).Click();
        }

        [When(@"methodist see all created homeworks")]
        public void WhenMethodistSeeAllCreatedHomeworks()
        {
            throw new PendingStepException();
        }

        [When(@"methodist click link edit")]
        public void WhenMethodistClickLinkEdit()
        {
            throw new PendingStepException();
        }

        [When(@"methodist edits homework")]
        public void WhenMethodistEditsHomework()
        {
            throw new PendingStepException();
        }

        [Then(@"methodist click button save draft")]
        public void ThenMethodistClickButtonSaveDraft()
        {
            throw new PendingStepException();
        }

        [Then(@"teacher authorization")]
        public void ThenTeacherAuthorization()
        {
            throw new PendingStepException();
        }

        [Then(@"teacher click button homework assignment")]
        public void ThenTeacherClickButtonHomeworkAssignment()
        {
            throw new PendingStepException();
        }

        [When(@"teacher fill out a new assignment form")]
        public void WhenTeacherFillOutANewAssignmentForm()
        {
            throw new PendingStepException();
        }

        [When(@"teacher click button publish")]
        public void WhenTeacherClickButtonPublish()
        {
            throw new PendingStepException();
        }

        [Then(@"student should sees homework")]
        public void ThenStudentShouldSeesHomework()
        {
            throw new PendingStepException();
        }
    }
}
