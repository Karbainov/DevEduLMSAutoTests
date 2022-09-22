namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class UserChangeProfilePhotoStepDefinitions
    {

        [When(@"Open profile page")]
        public void WhenOpenProfilePage()
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.OpenThisPage();
        }

        [When(@"Click on photo")]
        public void WhenClickOnPhoto()
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.ClickOnProfilePhoto();

        }

        [When(@"Click on add new file")]
        public void WhenClickOnAddNewFile()
        {
            throw new PendingStepException();
        }

        [When(@"Add new photo")]
        public void WhenAddNewPhoto()
        {
            throw new PendingStepException();
        }

        [Then(@"user should see the updated photo")]
        public void ThenUserShouldSeeTheUpdatedPhoto()
        {
            throw new PendingStepException();
        }
    }
}
