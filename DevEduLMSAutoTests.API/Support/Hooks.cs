namespace DevEduLMSAutoTests.API.Support
{
    [Binding]
    public sealed class Hooks
    {
        private TablesClear _tablesClear;
        public Hooks()
        {
            _tablesClear = new TablesClear();
        }

        [BeforeScenario(new string[] {"@sudent", "@teacher", "@methodist"})]
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