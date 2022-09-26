namespace AutoTestsSelenium.PageObjects
{
    public class GeneralStudentsProgressTeacherPage:AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/general-progress";
        public IWebElement ResultsTable => _driver.FindElement(By.XPath($"//div[@class='flex-container journal-content-container']"));
        public List<IWebElement> Homeworks => _driver.FindElements(By.XPath($"//div[starts-with(@class,'one-block block-column')]/preceding-sibling::div[starts-with(@class,'one-block tall')]/b")).ToList();
        public List<IWebElement> StudentsNames => _driver.FindElements(By.XPath($"//button[text()='Сортировать по фамилии']/../following-sibling::div")).ToList();
        public List<IWebElement> AllResults => _driver.FindElements(By.XPath($"//div[@class='scroll-content-div']/div[2]/descendant::div[starts-with(@class,'one-block')]")).ToList();
        public IWebElement BottomScrollBar => _driver.FindElement(By.XPath($"//div[contains(@class,'swiper-ini')][2]//div[@class='swiper-wrapper']"));

        public GeneralStudentsProgressTeacherPage()
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetDesiredGroupByName(string groupName)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{groupName}']/.."));
        }

        public void ClickOnBottomScrollBar()
        {
            BottomScrollBar.Click();
        }
    }
}