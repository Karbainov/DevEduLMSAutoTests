namespace AutoTestsSelenium.Support
{
    public class ModelsHelper
    {
        public List<GeneralProgressResultsModel> GetResults(GeneralStudentsProgressTeacherPage page)
        {
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
