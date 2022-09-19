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

        [AfterScenario]
        public void AfterScenario()
        {
            _cleaner.ClearDB();
            SingleWebDriver.CloseDriver();
        }
    }
}