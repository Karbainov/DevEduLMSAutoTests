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
        [When(@"Add new photo ""([^""]*)""")]
        public void WhenAddNewPhoto(string photoName)
        {
            ProfilePage page = new ProfilePage();
            string scrypt = "document.querySelector('#root > div.modal-background > div > div.buttons-container > label > input').setAttribute('class','display')";
            var driver = SingleWebDriver.GetInstance();
            driver.ExecuteJavaScript(scrypt);
            string filePath = Directory.GetCurrentDirectory();
            filePath = filePath.Replace("bin\\Debug\\net6.0", $"Support\\UsersPhotos\\{photoName}");
            page.InputFile.SendKeys(filePath);
        }

        [When(@"Click save photo")]
        public void WhenClickSavePhoto()
        {
            ProfilePage page = new ProfilePage();
            page.ClickButtonSavePhoto();
        }

        [Then(@"Modal window should disapier")]
        public void ThenModalWindowShouldDisapier()
        {
            ProfilePage page = new ProfilePage();
            Assert.True(page.IsModalWindowPhotoDisapier());
        }

        [When(@"Refresh page")]
        public void WhenRefreshPage()
        {
            ProfilePage page = new ProfilePage();
            Thread.Sleep(1000);//upload waiting
            page.RefreshPage();
        }


        [Then(@"User should see the updated photo")]
        public void ThenUserShouldSeeTheUpdatedPhoto()
        {
            ProfilePage page = new ProfilePage();
            Thread.Sleep(1000);//download waiting
            var photos = page.Photos;
            int expectedPhotosCount = 2;
            int actualPhotosCount = photos.Count;
            Assert.Equal(expectedPhotosCount, actualPhotosCount);
            List<string> actualLinks = new List<string>();
            foreach(var photo in photos)
            {
                actualLinks.Add(photo.GetAttribute("src"));
            }
            Assert.True(actualLinks.TrueForAll(x=>x.Equals(actualLinks.First())));
        }
    }
}