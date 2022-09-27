using OpenQA.Selenium.Support.Extensions;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class UserChangeProfilePhotoStepDefinitions
    {

        [When(@"Open profile page")]
        public void WhenOpenProfilePage()
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.ClickNameButton();
        }

        [When(@"Click on photo")]
        public void WhenClickOnPhoto()
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.ClickOnProfilePhoto();

        }

        [When(@"Add new photo")]
        public void WhenAddNewPhoto()
        {
            ProfilePage page = new ProfilePage();
            string scrypt = "document.querySelector('#root > div.modal-background > div > div.buttons-container > label > input').setAttribute('class','display')";
            var driver = SingleWebDriver.GetInstance();
            driver.ExecuteJavaScript(scrypt);
            string filePath = Directory.GetCurrentDirectory();
            filePath = filePath.Replace("bin\\Debug\\net6.0", "TestPhotoFile.jpg");
            page.InputFile.SendKeys(filePath);
            page.ClickButtonSavePhoto();
            page.RefreshPage();
        }

        [Then(@"User should see the updated photo")]
        public void ThenUserShouldSeeTheUpdatedPhoto()
        {
            ProfilePage page = new ProfilePage();
            var photos = page.Photos;
            int expectedPhotosCount = 2;
            int actualPhotosCount = photos.Count;
            Assert.Equal(expectedPhotosCount, actualPhotosCount);
        }
    }
}