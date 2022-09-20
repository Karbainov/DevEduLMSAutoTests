namespace AutoTestsSelenium.PageObjects
{
    public class GeneralStudentsProgressTeacherPage:AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/general-progress";
        public IWebElement ResultsTable => _driver.FindElement(By.XPath($"//div[@class='flex-container journal-content-container']"));
        public List<IWebElement> StudentsNames => _driver.FindElements(By.XPath($"//button[text()='Сортировать по фамилии']/../following-sibling::div")).ToList();

        public GeneralStudentsProgressTeacherPage(IWebDriver driver) : base(driver)
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

        public GeneralProgressResultsModel GetStudentsHomeworkResults(string homeworkName)
        {
            GeneralProgressResultsModel studentsResults = new GeneralProgressResultsModel();
            studentsResults.HomeworkName = homeworkName;
            studentsResults.StudentsHomeworkResults = new List<StudentsHomeworkResultModel>();
            var studentsNames = StudentsNames;
            foreach(var student in studentsNames)
            {
                string name = student.Text;
                var result = GetHomeworkResults(homeworkName);
                studentsResults.StudentsHomeworkResults.Add(new StudentsHomeworkResultModel() { FullName = name});
            }
            return studentsResults;
        }

        private IWebElement GetHomeworkResults(string homeworkName)
        {
            IWebElement methodsResult = null;
            string xpathAll = $"//div[starts-with(@class,'swiper-slide')]//div[starts-with(@class,'one-block tall')]//b";
            List<IWebElement> elements = _driver.FindElements(By.XPath(xpathAll)).ToList();
            for(int i = 0; i < elements.Count; i++)
            {
                var element = elements[i];
                //if(element.Text == homeworkName)
                if(element.Text == "DoulblyLinkedList")
                {
                    methodsResult = elements[(i + (i / 2))];
                    string ggg = methodsResult.GetAttribute("class");
                }
                //if(str == "")
                //{
                //    string xpathForText = $"//div[starts-with(@class,'swiper-slide')][{i + 1}]//div[starts-with(@class,'one-block tall')]//b[1]/p[1]";
                //    var el = element.FindElement(By.XPath(xpathForText));
                //    string s = el.Text;
                //}
            }
            return methodsResult;
        }
    }
}