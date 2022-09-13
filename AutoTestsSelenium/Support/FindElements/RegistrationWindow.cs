namespace AutoTestsSelenium.Support.FindElements
{
    public class RegistrationWindow
    {
        public By XPathRegistrationButton
        {
            get
            {
                return By.XPath($"//*[@href='/register']");
            }
            private set { }
        }

        public By XPathLastNameBox
        {
            get
            {
                return By.XPath($"//*[@name='lastName']");
            }
            private set { }
        }

        public By XPathFirstNameBox
        {
            get
            {
                return By.XPath($"//*[@name='firstName']");
            }
            private set { }
        }

        public By XPathPatronymicBox
        {
            get
            {
                return By.XPath($"//*[@name='patronymic']");
            }
            private set { }
        }

        public By XPathDateBirthBox
        {
            get
            {
                return By.XPath($"//*[@class='form-control']");
            }
            private set { }
        }

        public By XPathPasswordBox
        {
            get
            {
                return By.XPath($"//*[@name='password']");
            }
            private set { }
        }

        public By XPathRepeatPasswordBox
        {
            get
            {
                return By.XPath($"//*[@name='confirmPassword']");
            }
            private set { }
        }

        public By XPathEmailBox
        {
            get
            {
                return By.XPath($"//*[@name='email']");
            }
            private set { }
        }

        public By XPathPhoneNumberBox
        {
            get
            {
                return By.XPath($"//*[@name='phoneNumber']");
            }
            private set { }
        }

        public By XPathRegisterButton
        {
            get
            {
                return By.XPath($"//*[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']");
            }
            private set { }
        }

        public By XPathCancelRegistrationButton
        {
            get
            {
                return By.XPath($"//*[@class='sc-bczRLJ kEeNDb btn btn-text flex-container']");
            }
            private set { }
        }

        public By XPathPrivatePolicityCheckBox
        {
            get
            {
                return By.XPath($"//span[@class='custom-checkbox-text']");
            }
            private set { }
        }
    }
}
