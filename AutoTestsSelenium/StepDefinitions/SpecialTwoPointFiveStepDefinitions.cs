namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class SpecialTwoPointFiveStepDefinitions
    {
        private IWebDriver _driver;
        private readonly By _emailInput = By.XPath("//input[@ class='form-input']");
        private readonly By _passwordInput = By.XPath("//input[@class='form-input custom-password']");
        private readonly By _enterButton = By.XPath("//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']");
        private readonly By _homeworkButton = By.XPath("//span[text()='Домашние задания'] ");
        private readonly By _createHomework = By.XPath("//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']");
        private readonly By _choiceGroupNumber = By.XPath("//span[text()='QA Automation'] ");
        private readonly By _nameCreateHomework = By.XPath("//input[@class='form-input']");
        private readonly By _textInputCreateHomework = By.XPath("//textarea[@class='form-input']");
        private readonly By _linkInputCreateHomework = By.XPath("//textarea[@class='form-input_link form-input']");
        private readonly By _buttonSaveDraftHomework = By.XPath("//button[@class='sc-bczRLJ jsAGPN btn btn-white-with-border flex-container']");

        [Given(@"Open DevEdu web page")]
        public void GivenOpenDevEduWebPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl($"https://piter-education.ru:7074/login");
        }

        [When(@"authorization user as methodist")]
        public void WhenAuthorizationUserAsMethodist(Table table)
        {
            SwaggerSignInRequest singInRequest = table.CreateInstance<SwaggerSignInRequest>();
            var emailBox = _driver.FindElement(_emailInput);
            emailBox.SendKeys(singInRequest.Email);
            var passBox = _driver.FindElement(_passwordInput);
            passBox.Clear();
            passBox.SendKeys(singInRequest.Password);
        }

        [When(@"methodist click botton to come in")]
        public void WhenMethodistClickBottonToComeIn()
        {
            var enter = _driver.FindElement(_enterButton);
            enter.Click();
            Thread.Sleep(1000);
        }

        [When(@"methodist click button add task")]
        public void WhenMethodistClickButtonAddTask()
        {
            var homework = _driver.FindElement(_homeworkButton);
            homework.Click();

            var createHomework = _driver.FindElement(_createHomework);
            createHomework.Click();
            Thread.Sleep(1000);
        }

        [When(@"methodist create draft Homework")]
        public void WhenMethodistCreateDraftHomework(Table table)
        {
            var groupNumber = _driver.FindElement(_choiceGroupNumber);
            groupNumber.Click();

            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
            var nameHomework = _driver.FindElement(_nameCreateHomework);
            nameHomework.SendKeys(createHomework.Name);

            var textInput = _driver.FindElement(_textInputCreateHomework);
            textInput.SendKeys(createHomework.Description);

            var linkInput = _driver.FindElement(_linkInputCreateHomework);
            linkInput.SendKeys(createHomework.Link);
        }

        [Then(@"methodist click button save as draft")]
        public void ThenMethodistClickButtonSaveAsDraft()
        {
            var saveDraftHomework = _driver.FindElement(_buttonSaveDraftHomework);
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
