using OpenQA.Selenium.Support.Extensions;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class TeacherSortsStudentsByStatusDefinitions
    {
        private IWebDriver _driver;

        [When(@"Open DevEdu site https://piter-education.ru:7074/login")]
        public void WhenOpenDevEduSiteHttpsPiter_Education_RuLogin()
        {
            _driver = SingleWebDriver.GetInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
        }

        [When(@"Teacher create new homework for new group ""([^""]*)""")]
        public void WhenTeacherCreateNewHomeworkForNewGroup(string nameGroup, Table table)
        {
            HomeworkCreationTeacherPage homeworkCreationTeacherPage;
            homeworkCreationTeacherPage = new HomeworkCreationTeacherPage();
            homeworkCreationTeacherPage.ClickHomeworksButton();
            homeworkCreationTeacherPage.ClickCreateHomework();
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            homeworkCreationTeacherPage.ClickRadioButtonGroupName(nameGroup);
            homeworkCreationTeacherPage.InputStarDate(homework.StartDate);
            homeworkCreationTeacherPage.InputEndDate(homework.EndDate);
            homeworkCreationTeacherPage.InputNameHomework(homework.Name);
            homeworkCreationTeacherPage.InputDescriptionHomework(homework.Description);
            homeworkCreationTeacherPage.InputLink(homework.Link);
            homeworkCreationTeacherPage.ClickAddLinkButton();
            homeworkCreationTeacherPage.ClickPublishButton();
        }

        [When(@"Teacher should see students results to homework in tab General Progress")]
        public void WhenTeacherShouldSeeStudentsResultsToHomeworkInTabGeneralProgress()
        {
            HomeworksTeacherPage homeworksTeacherPage;
            homeworksTeacherPage = new HomeworksTeacherPage();
            homeworksTeacherPage.ClickGeneralProgressButton();
        }

        [When(@"Teacher click ascending sorting in a column ""([^""]*)""")]
        public void WhenTeacherClickAscendingSortingInAColumn(string taskName)
        {
            GeneralStudentsProgressTeacherPage generalStudentsProgressTeacherPage;
            generalStudentsProgressTeacherPage = new GeneralStudentsProgressTeacherPage();
            generalStudentsProgressTeacherPage.OpenThisPage();
            var driver = SingleWebDriver.GetInstance();
            driver.ExecuteJavaScript("document.body.style.zoom='0.5'");
            Thread.Sleep(100);//Without this, the zoom does not have time to change
            driver.ExecuteJavaScript("document.querySelector('#root > div > main > div.journals > div.flex-container.journal-content-container > div.scroll-content-div > div.swiper.swiper-initialized.swiper-horizontal.swiper-pointer-events.first-swiper.swiper-backface-hidden > div.swiper-wrapper').setAttribute('style','transform: translate3d(0px, 0px, 0px);')");
            driver.ExecuteJavaScript("document.querySelector('#root > div > main > div.journals > div.flex-container.journal-content-container > div.scroll-content-div > div:nth-child(2) > div.swiper-wrapper').setAttribute('style','transform: translate3d(0px, 0px, 0px);')");
            generalStudentsProgressTeacherPage.ClickSortBottomButton(taskName);
        }

        [Then(@"Teacher see list after sort")]
        public void ThenTeacherSeeListAfterSort()
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher click descending sorting in a column ""([^""]*)""")]
        public void ThenTeacherClickDescendingSortingInAColumn(string name)
        {
            throw new PendingStepException();
        }
    }
}
