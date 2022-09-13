using TechTalk.SpecFlow;

namespace AutoTestsSelenium.Support
{
    [Binding]
    public sealed class Hooks1
    {
        [AfterScenario]
        public void AfterScenario()
        {
            //if (ScenarioContext.Current.TestError != null)
            //{
            //    int a = 5;
            //    a++;
            //}
        }
    }
}