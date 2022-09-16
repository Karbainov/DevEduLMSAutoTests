namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class FrontManagerCreatesAGroupAddsUsersStepDefinitions
    {
        private IWebDriver _driver;
        private RegistrationWindow _registrationWindow;
        private SingInWindow _singInWindow;
        private Actions _action;
        private List<FrontRegisterRequest> _students;
        private List<FrontRegisterRequest> _teachers;
        private List<FrontRegisterRequest> _tutors;

        FrontManagerCreatesAGroupAddsUsersStepDefinitions()
        {
            _driver = new ChromeDriver();
            _registrationWindow = new RegistrationWindow();
            _singInWindow = new SingInWindow();
            _action = new Actions(_driver);
            _students = new List<FrontRegisterRequest>();
            _teachers = new List<FrontRegisterRequest>();
            _tutors = new List<FrontRegisterRequest>();
        }

        [Given(@"open the brouser and open DevEducation web page")]
        public void GivenOpenTheBrouserAndOpenDevEducationWebPage()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
        }

        [Given(@"registration users in service")]
        public void GivenRegistrationUsersInService(Table table)
        {
            List<FrontRegisterRequest> users = table.CreateSet<FrontRegisterRequest>().ToList();
            foreach (var user in users)
            {
                switch (user.Role)
                {
                    case Options.RoleStudent:
                        {
                            _students.Add(user);
                        }
                        break;
                    case Options.RoleTeacher:
                        {
                            _teachers.Add(user);
                        }
                        break;
                    case Options.RoleTutor:
                        {
                            _tutors.Add(user);
                        }
                        break;
                }
                var registrationButton = _driver.FindElement(_registrationWindow.XPathRegistrationButton);
                registrationButton.Click();
                var lastNameBox = _driver.FindElement(_registrationWindow.XPathLastNameBox);
                lastNameBox.SendKeys(user.LastName);
                var firstNameBox = _driver.FindElement(_registrationWindow.XPathFirstNameBox);
                firstNameBox.SendKeys(user.FirstName);
                var patronymicBox = _driver.FindElement(_registrationWindow.XPathPatronymicBox);
                patronymicBox.SendKeys(user.Patronymic);
                var dateBirthBox = _driver.FindElement(_registrationWindow.XPathDateBirthBox);
                _action.DoubleClick(dateBirthBox).Build().Perform();
                dateBirthBox.SendKeys(Keys.Backspace);
                dateBirthBox.SendKeys(user.BirthDate);
                var passwordBox = _driver.FindElement(_registrationWindow.XPathPasswordBox);
                passwordBox.SendKeys(user.Password);
                var repeatPasswordBox = _driver.FindElement(_registrationWindow.XPathRepeatPasswordBox);
                repeatPasswordBox.SendKeys(user.RepeatPassword);
                var emailBox = _driver.FindElement(_registrationWindow.XPathEmailBox);
                emailBox.SendKeys(user.Email);
                var phoneNamberBox = _driver.FindElement(_registrationWindow.XPathPhoneNumberBox);
                phoneNamberBox.SendKeys(user.PhoneNumber);
                var registerButton = _driver.FindElement(_registrationWindow.XPathRegisterButton);
                registerButton.Click();
                var cancelRegistrationButton = _driver.FindElement(_registrationWindow.XPathCancelRegistrationButton);
                cancelRegistrationButton.Click();
            }
        }

        [Given(@"authorize users in service")]
        public void GivenAuthorizeUsersInService(Table table)
        {
            _driver.Navigate().GoToUrl(Urls.Host);
            List<SingInRequest> users = table.CreateSet<SingInRequest>().ToList();
            foreach (var user in users)
            {
                var emailBox = _driver.FindElement(_singInWindow.XPathEmailBox);
                emailBox.SendKeys(user.Email);
                var passwordBox = _driver.FindElement(_singInWindow.XPathPasswordBox);
                _action.DoubleClick(passwordBox).Build().Perform();
                passwordBox.SendKeys(Keys.Backspace);
                passwordBox.SendKeys(user.Password);
                var sindInButton = _driver.FindElement(_singInWindow.XPathSingInButton);
                sindInButton.Click();
                var cancelSingInButton = _driver.FindElement(_singInWindow.XPathCancelSingInButton);
                cancelSingInButton.Click();
            }
        }

    }
}
