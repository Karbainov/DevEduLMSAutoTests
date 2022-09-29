using Docker.DotNet.Models;
using OpenQA.Selenium.Support.Extensions;

namespace AutoTestsSelenium.Support
{
    public class ModelsHelper
    {
        public List<GeneralProgressResultsModel> GetResults(GeneralStudentsProgressTeacherPage page)
        {
            var driver = SingleWebDriver.GetInstance();
            driver.ExecuteJavaScript("document.body.style.zoom='0.5'");
            Thread.Sleep(100);//Without this, the zoom does not have time to change
            driver.ExecuteJavaScript("document.querySelector('#root > div > main > div.journals > div.flex-container.journal-content-container > div.scroll-content-div > div.swiper.swiper-initialized.swiper-horizontal.swiper-pointer-events.first-swiper.swiper-backface-hidden > div.swiper-wrapper').setAttribute('style','transform: translate3d(0px, 0px, 0px);')");
            driver.ExecuteJavaScript("document.querySelector('#root > div > main > div.journals > div.flex-container.journal-content-container > div.scroll-content-div > div:nth-child(2) > div.swiper-wrapper').setAttribute('style','transform: translate3d(0px, 0px, 0px);')");
            var methodsResult = new List<GeneralProgressResultsModel>();
            var homeworks = page.Homeworks;
            var names = page.StudentsNames;
            var allResults = page.AllResults;
            for (int i = 0; i < homeworks.Count; i++)
            {
                string hwName = homeworks[i].Text;
                hwName = RemoveWrongCharsFromHW(hwName);
                var results = new List<StudentsHomeworkResultModel>();
                for (int j = 0; j < names.Count; j++)
                {
                    string name = names[j].Text;
                    int index = ((allResults.Count / homeworks.Count) * i) + j;
                    string crntResult = allResults[index].Text;
                    crntResult = RemoveWrongCharsFromResult(crntResult);
                    results.Add(new StudentsHomeworkResultModel() { FullName = name, Result = crntResult });
                }
                methodsResult.Add(new GeneralProgressResultsModel() { HomeworkName = hwName, StudentsHomeworkResults = results });
            }
            return methodsResult;
        }

        public void GetReducedScale(GeneralStudentsProgressTeacherPage page)
        {
            var driver = SingleWebDriver.GetInstance();
            driver.ExecuteJavaScript("document.body.style.zoom='0.5'");
            Thread.Sleep(100);//Without this, the zoom does not have time to change
            driver.ExecuteJavaScript("document.querySelector('#root > div > main > div.journals > div.flex-container.journal-content-container > div.scroll-content-div > div.swiper.swiper-initialized.swiper-horizontal.swiper-pointer-events.first-swiper.swiper-backface-hidden > div.swiper-wrapper').setAttribute('style','transform: translate3d(0px, 0px, 0px);')");
            driver.ExecuteJavaScript("document.querySelector('#root > div > main > div.journals > div.flex-container.journal-content-container > div.scroll-content-div > div:nth-child(2) > div.swiper-wrapper').setAttribute('style','transform: translate3d(0px, 0px, 0px);')");        
        }

        public List<StudentsHomeworkResultModel> GetHomeworkResultsByHomeworkName(GeneralStudentsProgressTeacherPage page, string homeworkName)
        {
            var methodResult = new List< StudentsHomeworkResultModel>();
            var names = page.StudentsNames;
            var homeworks = page.Homeworks;
            int hwIndex = -1;
            for (int i=0; i<homeworks.Count;i++)
            {
                string hwName = homeworks[i].Text;
                hwName = RemoveWrongCharsFromHW(hwName);
                if (hwName.Contains(homeworkName))
                {
                    hwIndex = i;
                }
            }
            if (hwIndex==-1)
            {
                throw new ArgumentOutOfRangeException("Нет такого домашнего задания");
            }
            var allResult = page.AllResults;
            for (int i = 0; i < names.Count; i++)
            {
                string name = names[i].Text;
                int resultIndex=(names.Count*hwIndex+i);
                string crntResult = allResult[resultIndex].Text;
                crntResult = RemoveWrongCharsFromResult(crntResult);
                methodResult.Add(new StudentsHomeworkResultModel() { FullName = name, Result = crntResult });               
            }
            return methodResult;
        }

        private string RemoveWrongCharsFromHW(string inputStrring)
        {
            string wrongChars = $"\r\n";
            int wrongCharsLenght = 4;
            if (inputStrring.Contains(wrongChars))
            {
                int removeIndex = inputStrring.IndexOf(wrongChars);
                if (inputStrring.Contains(' '))
                {
                    inputStrring = inputStrring.Remove(removeIndex, wrongCharsLenght);
                }
                else
                {
                    inputStrring = inputStrring.Replace(wrongChars, " ");
                }
            }
            return inputStrring;
        }

        private string RemoveWrongCharsFromResult(string inputStrring)
        {
            string wrongChars = $"\r\n";
            if (inputStrring.Contains(wrongChars))
            {
                int removeIndex = inputStrring.IndexOf(wrongChars);
                inputStrring = inputStrring.Replace(wrongChars, " ");
            }
            return inputStrring;
        }
    }
}
