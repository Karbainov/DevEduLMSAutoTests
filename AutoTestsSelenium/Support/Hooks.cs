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

        [BeforeScenario(new string[] { "@sudent", "@teacher", "@methodist" })]
        public void BeforeScenarioWithTag()
        {
            _cleaner.ClearDB();
        }

        [BeforeScenario(new string[] {"@registration"})]
        public void BeforeScenarioWithTag()
        {
            _tablesClear.ClearDB();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _cleaner.ClearDB();
            SingleWebDriver.CloseDriver();
        }
    }
}