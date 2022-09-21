namespace AutoTestsSelenium.Support.Models
{
    public class GeneralProgressResultsModel
    {
        public string HomeworkName { get; set; }
        public List<StudentsHomeworkResultModel> StudentsHomeworkResults { get; set; }

        public static List<GeneralProgressResultsModel> GetResults(GeneralStudentsProgressTeacherPage page)
        {
            var methodsResult = new List<GeneralProgressResultsModel>();
            var homeworks = page.Homeworks;
            var names = page.StudentsNames;
            int tmp = 0;
            var allResults = page.AllResults;
            for(int i = 0; i < homeworks.Count; i++)
            {
                string hwName = homeworks[i].Text;
                if (hwName == "")
                {
                    var elements = homeworks[i].FindElements(By.XPath($"//div[starts-with(@class,'one-block block-column')]/preceding-sibling::div[starts-with(@class,'one-block tall')]/b/p"));
                    hwName = $"{elements[tmp].Text} {elements[tmp + 1].Text}";
                    tmp += 2;
                }
                var results = new List<StudentsHomeworkResultModel>();
                for(int j= 0; j < names.Count; j++)
                {
                    string name = names[j].Text;
                    int index = ((allResults.Count/homeworks.Count)*i)+j;
                    string crntResult = allResults[index].Text;
                    results.Add(new StudentsHomeworkResultModel() { FullName = name, Result = crntResult});
                }
                methodsResult.Add(new GeneralProgressResultsModel() { HomeworkName=hwName, StudentsHomeworkResults = results});
            }
            return methodsResult;
        }
    }
}
