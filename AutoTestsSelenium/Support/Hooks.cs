namespace AutoTestsSelenium.Support
{
    [Binding]
    public sealed class Hooks
    {
        private DBCleaner _tablesClear;

        public Hooks()
        {
            _tablesClear = new DBCleaner();
        }

        [BeforeScenario(new string[] {"@registration"})]
        public void BeforeScenarioWithTag()
        {
            _tablesClear.ClearDB();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _tablesClear.ClearDB();
        }
    }
}