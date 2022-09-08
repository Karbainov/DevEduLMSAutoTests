﻿namespace AutoTestsSelenium.Support.FindElements
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
                return By.XPath($"//*[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']");
            }
            private set { }
        }

        public By XPathCancelSingInButton
        {
            get
            {
                return By.XPath($"//*[@class='sc-bczRLJ kEeNDb btn btn-text flex-container']");
            }
            private set { }
        }
    }
}