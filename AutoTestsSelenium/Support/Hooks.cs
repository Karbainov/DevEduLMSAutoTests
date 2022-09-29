namespace AutoTestsSelenium.Support
{
    [Binding]
    public sealed class Hooks
    {
        private DBCleaner _cleaner;

        public Hooks()
        {
            _cleaner = new DBCleaner();
        }

        [BeforeScenario()]
        public void BeforeScenarioWithTag()
        {
            _cleaner.ClearDB();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            SingleWebDriver.CloseDriver();
            _cleaner.ClearDB();
        }
    }
}