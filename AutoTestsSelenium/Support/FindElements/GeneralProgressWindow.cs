namespace AutoTestsSelenium.Support.FindElements
{
    public class GeneralProgressWindow
    {
        public static By СomponentHWName => By.XPath($"//div[starts-with(@class,'one-block block-column')]/preceding-sibling::div[starts-with(@class,'one-block tall')]/b/p");
    }
}
