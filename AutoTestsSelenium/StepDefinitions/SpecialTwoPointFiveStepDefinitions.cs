namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class SpecialTwoPointFiveStepDefinitions
    {
        private IWebDriver _driver;
        private RegistrationWindow _registrationWindow;
        private SingInWindow _singInWindow;
        private MethodistHomeworkWindow _methodistHomeworkWindow;

        SpecialTwoPointFiveStepDefinitions()
        {
            _driver = new ChromeDriver();
            _registrationWindow = new RegistrationWindow();
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
            SingInRequest singInRequest = table.CreateInstance<SingInRequest>();
            var emailBox = _driver.FindElement(_singInWindow.XPathEmailBox);
            emailBox.SendKeys(singInRequest.Email);
            var passBox = _driver.FindElement(_singInWindow.XPathPasswordBox);
            passBox.Clear();
            passBox.SendKeys(singInRequest.Password);
        }

        [When(@"methodist click botton to come in")]
        public void WhenMethodistClickBottonToComeIn()
        {
            var enter = _driver.FindElement(_singInWindow.XPathSingInButton);
            enter.Click();
            Thread.Sleep(1000);
        }

        [When(@"methodist click button add task")]
        public void WhenMethodistClickButtonAddTask()
        {
            var homework = _driver.FindElement(_methodistHomeworkWindow.XPathHomeworkButton);
            homework.Click();

            var createHomework = _driver.FindElement(_methodistHomeworkWindow.XpathCreateHomework);
            createHomework.Click();
            Thread.Sleep(1000);
        }

        [When(@"methodist create draft Homework")]
        public void WhenMethodistCreateDraftHomework(Table table)
        {
            var groupNumber = _driver.FindElement(_methodistHomeworkWindow.XpathChoiceGroupNumber);
            groupNumber.Click();
            CreateHomework createHomework = table.CreateInstance<CreateHomework>();
            var nameHomework = _driver.FindElement(_methodistHomeworkWindow.XpathNameCreateHomework);
            nameHomework.SendKeys(createHomework.Name);
            var textInput = _driver.FindElement(_methodistHomeworkWindow.XpathDescriptionHomework);
            textInput.SendKeys(createHomework.Description);
            var linkInput = _driver.FindElement(_methodistHomeworkWindow.XpathLinkInputHomework);
            linkInput.SendKeys(createHomework.LinkToRecord);
        }

        [Then(@"methodist click button save as draft")]
        public void ThenMethodistClickButtonSaveAsDraft()
        {
            var saveDraftHomework = _driver.FindElement(_methodistHomeworkWindow.XpathButtonSaveDraftHomework);
            saveDraftHomework.Click();
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
