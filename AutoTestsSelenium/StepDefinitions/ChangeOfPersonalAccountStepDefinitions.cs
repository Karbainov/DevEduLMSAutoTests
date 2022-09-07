namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class ChangeOfPersonalAccountStepDefinitions
    {
        WebDriver _driver;

        public const string Host = $"https://piter-education.ru:7074";
        private readonly By _emailInput = By.XPath($"//input[@class='form-input']");
        private readonly By _passwordInput = By.XPath($"//input[@class='form-input custom-password']");
        private readonly By _enterButton = By.XPath($"//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']");
        private readonly By _enterAccount = By.XPath($"//span[@class='avatar-name margin-right-avatar transition-styles']");
        private readonly By _lastNameInput = By.XPath($"//input[@name='lastName']");
        private readonly By _firstNameInput = By.XPath($"//input[@name='firstName']");
        private readonly By _patronymicInput = By.XPath($"//input[@name='patronymic']");
        private readonly By _gitHubInput = By.XPath($"//input[@name='gitHubAccount']");
        private readonly By _phoneInput = By.XPath($"//input[@name='phoneNumber']");
        private readonly By _calendarSelectionButton = By.XPath($"//button[@class='date-picker__button']");
        private readonly By _linePassUpToYear = By.XPath($"//th[@class='rdtSwitch']");
        private readonly By _yearSelectionInput = By.XPath($"//td[@data-value='1992']");
        private readonly By _monthSelectionInput = By.XPath($"//td[@data-value='1']");
        private readonly By _daySelectionInput = By.XPath($"//td[@data-value='12']");
        private readonly By _saveButton = By.XPath($"//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']");

        [Given(@"Open a browser in DevEducation web page")]
        public void GivenOpenABrowserInDevEducationWebPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Host);
        }

        [When(@"Enter login account")]
        public void WhenEnterLoginAccount(Table table)
        {
            AuthModel authModel = table.CreateInstance<AuthModel>();
            var emailBox = _driver.FindElement(_emailInput);
            emailBox.SendKeys(authModel.Login);
            var passBox = _driver.FindElement(_passwordInput);
            passBox.Clear();
            passBox.SendKeys(authModel.Password);
        }

        [Then(@"Click button account login")]
        public void ThenClickButtonAccountLogin()
        {
            var button = _driver.FindElement(_enterButton);
            button.Click();
            Thread.Sleep(1000);
        }

        [Given(@"Go to account settings")]
        public void GivenGoToAccountSettings()
        {
            var button = _driver.FindElement(_enterAccount);
            button.Click();
            Thread.Sleep(1000);
        }

        [When(@"Change LastName, FirstName, Patronymic, GitHub, Phone")]
        public void WhenChangeLastNameFirstNamePatronymicGitHubPhone(Table table)
        {
            AccountModel accountModel = table.CreateInstance<AccountModel>();
            var textLastName = _driver.FindElement(_lastNameInput);;
            textLastName.Clear();
            textLastName.SendKeys(accountModel.LastName);

            var textFirstName = _driver.FindElement(_firstNameInput);
            textFirstName.Clear();
            textFirstName.SendKeys(accountModel.FirstName);

            var textPatronymic = _driver.FindElement(_patronymicInput);
            textPatronymic.Clear();
            textPatronymic.SendKeys(accountModel.Patronymic);

            var textGitHub = _driver.FindElement(_gitHubInput);
            textGitHub.Clear();
            textGitHub.SendKeys(accountModel.GitHub);

            var textPhone = _driver.FindElement(_phoneInput);
            textPhone.Clear();
            textPhone.SendKeys(accountModel.Phone);
        }

        [When(@"Change Date Birth")]
        public void WhenChangeDateBirth()
        {
            var calendarSelection = _driver.FindElement(_calendarSelectionButton);
            calendarSelection.Click();
            var linePassUpToMonth = _driver.FindElement(_linePassUpToYear);
            linePassUpToMonth.Click();
            var linePassUpToYear = _driver.FindElement(_linePassUpToYear);
            linePassUpToYear.Click();
            var yearSelection = _driver.FindElement(_yearSelectionInput);
            yearSelection.Click();
            var monthSelection = _driver.FindElement(_monthSelectionInput);
            monthSelection.Click();
            var daySelection = _driver.FindElement(_daySelectionInput);
            daySelection.Click();
        }

        [Then(@"Save changes")]
        public void ThenSaveChanges()
        {
            var saveButton = _driver.FindElement(_saveButton);
            saveButton.Click();
        }
    }
}
