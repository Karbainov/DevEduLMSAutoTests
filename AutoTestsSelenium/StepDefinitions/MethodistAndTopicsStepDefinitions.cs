namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class MethodistAndTopicsStepDefinitions
    {
        private IWebDriver _driver;
        private SingInWindow _singInWindow;
        private readonly By _coursesButton = By.XPath("//a[@href='/courses']");
        private readonly By _editButton = By.XPath("//a[@class='link-with-text-decoration']");
        private readonly By _addTopicNumber = By.XPath("//input[@name='position']");
        private readonly By _addTopicName = By.XPath("//input[@name='topicName']");
        private readonly By _addTopicDuration = By.XPath("//input[@name='hoursCount']");
        private readonly By _saveTopicButton = By.XPath("//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']");

        private readonly By _drugAndDropTopic = By.XPath("//div[@data-rbd-drag-handle-draggable-id='Базовое понимание классов']");
        private readonly By _placeToDrop = By.XPath("//*[@id='root']/div/main/div[1]/div[3]/div[1]");

        MethodistAndTopicsStepDefinitions()
        {
            _driver = new ChromeDriver();
            _singInWindow = new SingInWindow();
        }

        [Given(@"Open DevEducation web")]
        public void GivenOpenDevEducationWebPage()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
        }

        [When(@"authorize as methodist")]
        public void WhenAuthorizeMethodist(Table table)
        {
            SingInRequest singRequest = table.CreateInstance<SingInRequest>();
            _driver.FindElement(_singInWindow.XPathEmailBox).SendKeys(singRequest.Email);
            var password = _driver.FindElement(_singInWindow.XPathPasswordBox);
            password.Clear();
            password.SendKeys(singRequest.Password);
            var enter = _driver.FindElement(_singInWindow.XPathSingInButton);
            enter.Click();
            Thread.Sleep(1000);
        }

        [When(@"methodist click courses button")]
        public void WhenMethodistClickButton()
        {
           _driver.FindElement(_coursesButton).Click();
        }

        [When(@"methodist choose course to edit and click edit button")]
        public void WhenMethodistChooseCourseToEditAndClickEditButton()
        {
            _driver.FindElement(_editButton).Click();
        }

        [When(@"methodist add new topic")]
        public void WhenMethodistAddNewTopic(Table table)
        {
            AddTopicRequest addTopicRequest = table.CreateInstance<AddTopicRequest>();
            _driver.FindElement(_addTopicNumber).SendKeys(addTopicRequest.TopicNumber);
            _driver.FindElement(_addTopicName).SendKeys(addTopicRequest.Name);
            _driver.FindElement(_addTopicDuration).SendKeys(addTopicRequest.Duration);
            var save = _driver.FindElement(_saveTopicButton);
            save.Click();
            Thread.Sleep(1000);
        }

        [When(@"methodist edit courses order")]
        public void WhenMethodistEditCoursesOrder()
        {
            var actions = new Actions(_driver);
            var topicToDrug = _driver.FindElement(_drugAndDropTopic);
            var placeToDrop = _driver.FindElement(_placeToDrop);

            actions.DragAndDrop(topicToDrug, placeToDrop)
           .Perform();

            Thread.Sleep(2000);
        }

        [When(@"methodist should see the updated topics in the course")]
        public void WhenMethodistShouldSeeTheUpdatedTopicsInTheCourse()
        {
            throw new PendingStepException();
        }

    }
}
