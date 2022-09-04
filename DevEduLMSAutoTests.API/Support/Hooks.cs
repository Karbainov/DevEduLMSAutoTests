using TechTalk.SpecFlow;

namespace DevEduLMSAutoTests.API.Support
{
    [Binding]
    public sealed class Hooks
    {
        private ClearTables _clearTables;
        public Hooks()
        {
            _clearTables = new ClearTables();
        }

        [BeforeScenario("@student")]
        public void BeforeScenarioWithTag()
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