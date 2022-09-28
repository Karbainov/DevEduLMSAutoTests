namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class ProfileStepDefinitions
    {
        [When(@"Click button settings")]
        public void WhenClickButtonSettings()
        {
            var page = new ProfilePage();
            page.ClickSettingsButton();
        }

        [When(@"Fills data")]
        public void WhenFillsData(Table table)
        {
            var data = table.CreateInstance<RegistrationModel>();
            var page = new ProfilePage();
            page.EnterLastName(data.LastName);
            page.EnterFirstName(data.FirstName);
            page.EnterPatronymic(data.Patronymic);
            page.EnterBirthDate(data.BirthDate);
            page.EnterGitHub(data.GitHubAccount);
            page.EnterPhone(data.PhoneNumber);
        }

        [When(@"Click button save")]
        public void WhenClickButtonSave()
        {
            var page = new ProfilePage();
            page.ClickSaveButton();
        }

        [When(@"Refresh page")]
        public void WhenRefreshPage()
        {
            var page = new ProfilePage();
            page.RefreshPage();
        }

        [Then(@"Profile data must match the changed ones")]
        public void ThenProfileDataMustMatchTheChangedOnes(Table table)
        {
            var expectedProfileData = table.CreateInstance<RegistrationModel>();
            var page = new ProfilePage();
            var attributeName = "value";
            var actualProfileData = new RegistrationModel()
            {
                LastName = page.TextBoxLastName.GetAttribute(attributeName),
                FirstName = page.TextBoxFirstName.GetAttribute(attributeName),
                Patronymic = page.TextBoxPatronymic.GetAttribute(attributeName),
                BirthDate = page.TextBoxBirthDate.GetAttribute(attributeName),
                Email = page.TextBoxEmail.GetAttribute(attributeName),
                GitHubAccount = page.TextBoxGitHub.GetAttribute(attributeName),
                PhoneNumber = page.TextBoxPhone.GetAttribute(attributeName)
            };
            Assert.Equivalent(expectedProfileData, actualProfileData);
        }
    }
}
