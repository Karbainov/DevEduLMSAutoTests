namespace AutoTestsSelenium.Support
{
    public class SingleWebDriver
    {
        private static IWebDriver _instance;

        private SingleWebDriver() { }

        public static IWebDriver GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ChromeDriver();
            }
            return _instance;
        }

        public static IWebDriver GetInstance(ChromeOptions options)
        {
            if (_instance == null)
            {
                _instance = new ChromeDriver(options);
            }
            return _instance;
        }
    }
}
