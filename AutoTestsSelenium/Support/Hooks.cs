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

        [AfterScenario]
        public void AfterScenario()
        {
            _tablesClear.ClearDB();
            SingleWebDriver.CloseDriver();
        }
    }
}