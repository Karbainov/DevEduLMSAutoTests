namespace AutoTestsSelenium.Support.FindElements
{
    public class HomeworkResultsElements
    {
        public By XPathStudentsResultByNameByResult(string studentsFullName, string studentsResult)
        {
            string xpath = $"//*[text()='{studentsFullName}']/following-sibling::*[text()='{studentsResult}']";
            return By.XPath(xpath);
        }
    }
}
