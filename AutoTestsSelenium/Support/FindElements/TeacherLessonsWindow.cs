﻿namespace AutoTestsSelenium.Support.FindElements
{
    public class TeacherLessonsWindow
    {
        public By XPathGroups
        {
            get
            {
                return By.XPath($"//*[@class='tab-container']");
            }
            private set { }
        }
    }
}
