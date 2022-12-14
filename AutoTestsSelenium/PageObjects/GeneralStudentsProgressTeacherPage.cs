namespace AutoTestsSelenium.PageObjects
{
    public class GeneralStudentsProgressTeacherPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/general-progress";
        public IWebElement ResultsTable => _driver.FindElement(By.XPath($"//div[@class='flex-container journal-content-container']"));
        public List<IWebElement> Homeworks => _driver.FindElements(By.XPath($"//div[starts-with(@class,'one-block block-column')]/preceding-sibling::div[starts-with(@class,'one-block tall')]/b")).ToList();
        public List<IWebElement> StudentsNames => _driver.FindElements(By.XPath($"//button[text()='Сортировать по фамилии']/../following-sibling::div")).ToList();
        public List<IWebElement> AllResults => _driver.FindElements(By.XPath($"//div[@class='scroll-content-div']/div[2]/descendant::div[starts-with(@class,'one-block')]")).ToList();
        public IWebElement BottomScrollBar => _driver.FindElement(By.XPath($"//div[contains(@class,'swiper-ini')][2]//div[@class='swiper-wrapper']"));
        public IWebElement ButtonSortBySurname => _driver.FindElement(By.XPath($"//button[text()='Сортировать по фамилии']"));
        public IWebElement TopScrollBar => _driver.FindElement(By.XPath($"//div[@class='scroll-content-div']/div[1]/div/div[@class='swiper-scrollbar-drag']"));
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

        public void ClickSortBottomButton(string taskName)
        {
            GetSortBottomButtonByName(taskName).Click();
        }

        public void ClickSortTopButton(string taskName)
        {
            GetSortTopButtonByName(taskName).Click();
        }

        public IWebElement GetSortBottomButtonByName(string taskName)
        {
            try
            {
                return _driver.FindElement(By.XPath($"//*[contains(text(),'{taskName}')]/../following-sibling::div/button[2]"));
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return _driver.FindElement(By.XPath($"//*[contains(text(),'{taskName}')]/../../following-sibling::div/button[2]"));
            }
        }

        public void ClickDesiredGroup(string groupName)
        {
            GetDesiredGroupByName(groupName).Click();
        }

        public IWebElement GetSortTopButtonByName(string taskName)
        {
            try
            {
                return _driver.FindElement(By.XPath($"//*[contains(text(),'{taskName}')]/../following-sibling::div/button[1]"));
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return _driver.FindElement(By.XPath($"//*[contains(text(),'{taskName}')]/../../following-sibling::div/button[1]"));
            }
        }    

        public void ClickOnBottomScrollBar()
        {
            BottomScrollBar.Click();
        }

        public void ClickSortBySurname()
        {
            ButtonSortBySurname.Click();
        }

        public List<IWebElement> GetAllResults()
        {
            return _driver.FindElements(By.XPath($"//*[@class='one-block block-column']/b")).ToList();
        }

        public List<IWebElement> GetAllFullNames()
        {
            List<IWebElement> names = _driver.FindElements(By.XPath($"//*[@class='one-block students-list']")).ToList();
            List<IWebElement> namesWithouTitles = new List<IWebElement>();
            for (int i = 1; i < names.Count; i++)
            {
                namesWithouTitles.Add(names[i]);
            }
            return namesWithouTitles;
        }

        public void MoveLeftTopScrollBar()
        {
            new Actions(_driver)
                .DragAndDropToOffset(TopScrollBar, -200, 0)
                .Build()
                .Perform();
        }
    }
}