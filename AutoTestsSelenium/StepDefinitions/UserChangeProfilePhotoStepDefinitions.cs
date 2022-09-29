using OpenQA.Selenium.Support.Extensions;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class UserChangeProfilePhotoStepDefinitions
    {

        private string _profilePhotoLink;

        [When(@"Open profile page by click on users name")]
        public void WhenOpenProfilePage()
        {
            var page = new ProfilePage();
            page.ClickNameButton();
        }

        [When(@"Click on photo")]
        public void WhenClickOnPhoto()
        {
            var page = new ProfilePage();
            page.ClickOnProfilePhoto();

        }

        [When(@"Add photo ""([^""]*)""")]
        public void WhenAddNewPhoto(string photoName)
        {
            var page = new ProfilePage();
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
            var page = new ProfilePage();
            page.ClickButtonSavePhoto();
        }

        [Then(@"Modal window should disapier")]
        public void ThenModalWindowShouldDisapier()
        {
            var page = new ProfilePage();
            Assert.True(page.IsModalWindowPhotoDisapier());
        }

        [When(@"Refresh page")]
        public void WhenRefreshPage()
        {
            var page = new ProfilePage();
            Thread.Sleep(1000);//upload waiting
            page.RefreshPage();
        }

        [Then(@"User should see his photo")]
        public void ThenUserShouldSeeHisPhoto()
        {
            var page = new ProfilePage();
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
            _profilePhotoLink = actualLinks.First();
        }

        [When(@"Click cancel button")]
        public void WhenClickCancelButton()
        {
            var page = new ProfilePage();
            page.ClickButtonCancelAddPhoto();
        }

        [Then(@"Photo should not appear")]
        public void ThenPhotoShouldNotAppear()
        {
            var page = new ProfilePage();
            var photos = page.Photos;
            Assert.Empty(photos);
        }

        [Then(@"User should see the updated photo")]
        public void ThenUserShouldSeeTheUpdatedPhoto()
        {
            var page = new ProfilePage();
            Thread.Sleep(1000);//download waiting
            var photos = page.Photos;
            int expectedPhotosCount = 2;
            int actualPhotosCount = photos.Count;
            Assert.Equal(expectedPhotosCount, actualPhotosCount);
            List<string> actualLinks = new List<string>();
            foreach (var photo in photos)
            {
                actualLinks.Add(photo.GetAttribute("src"));
            }
            Assert.True(actualLinks.TrueForAll(x => x.Equals(actualLinks.First())));
            Assert.False(actualLinks.TrueForAll(x => x.Equals(_profilePhotoLink)));
        }
    }
}