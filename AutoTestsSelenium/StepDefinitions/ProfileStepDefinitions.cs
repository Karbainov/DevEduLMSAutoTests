namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class ProfileStepDefinitions
    {
        [When(@"Fills data profile")]
        public void WhenFillsDataProfile(Table table)
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

        [When(@"Fills password data")]
        public void WhenFillsPasswordData(Table table)
        {
            var data = table.CreateInstance<RegistrationModel>();
            var page = new ChandingPasswordPage();
            page.EnterOldPassword(data.OldPassword);
            page.EnterNewPassword(data.Password);
            page.EnterRepeatNewPassword(data.RepeatPassword);
        }

        [When(@"Click button save profile changes")]
        public void WhenClickButtonSaveProfileChanges()
        {
            var page = new ProfilePage();
            page.ClickSaveButton();
        }

        [When(@"Click button save password changes")]
        public void WhenClickButtonSavePasswordChanges()
        {
            var page = new ChandingPasswordPage();
            page.ClickSaveButton();
        }

        [When(@"Click editing password")]
        public void WhenClickEditingPassword()
        {
            var page = new ProfilePage();
            page.ClickChangePasswordButton();
        }

        [When(@"Click button cancels profile changes")]
        public void WhenClickButtonCancelsProfileChanges()
        {
            var page = new ProfilePage();
            page.ClickCancelButton();
        }

        [When(@"Click button cancels password changes in profile")]
        public void WhenClickButtonCancelsPasswordChangesInProfile()
        {
            var page = new ChandingPasswordPage();
            page.ClickCancelButton();
        }

        [When(@"Refresh profile page")]
        public void WhenRefreshProfilePage()
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