namespace AutoTestsSelenium.Support
{
    [Binding]
    public sealed class Hooks
    {
        private TablesClear _tablesClear;

        public Hooks()
        {
            _tablesClear = new TablesClear();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _tablesClear.ClearDB();
        }
    }
}