namespace AutoTestsSelenium.Support.FindElements
{
    public class SingInWindow
    {
        public By XPathEmailBox
        {
            get
            {
                return By.XPath($"//*[@name='email']");
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

        public By XPathSingInButton
        {
            get
            {
                return By.XPath("//button[text()='Войти']");
            }
            private set { }
        }

        public By XPathCancelSingInButton
        {
            get
            {
                return By.XPath("//span[text()='Выйти']");
            }
            private set { }
        }
    }
}
