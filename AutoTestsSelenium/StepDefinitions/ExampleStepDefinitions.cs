using System;
using TechTalk.SpecFlow;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class ExampleStepDefinitions
    {
        [Then(@"Wse slomalos!!!")]
        public void ThenWseSlomalos()
        {
            throw new PendingStepException();
        }
    }
}
