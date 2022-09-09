using TechTalk.SpecFlow;

namespace DevEduMLSAutoTests.Api.Support
{
    [Binding]
    public sealed class Hooks
    {
        private ClearTables _clearTables;
        public Hooks()
        {
            _clearTables = new ClearTables();
        }

        [BeforeScenario(new string[] { "@sudent", "@teacher", "@methodist" })]
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