namespace DevEduLMSAutoTests.API.Support
{
    [Binding]
    public sealed class Hooks
    {
        private ClearBase _clearTables;
        public Hooks()
        {
            _clearTables = new ClearBase();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _clearTables.ClearDB();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _clearTables.ClearDB();
        }
    }
}