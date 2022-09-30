namespace AutoTestsSelenium.Support.Models
{
    public class GroupCreationModel
    {
        public string GroupName { get; set; }
        public string CourseName { get; set; }
        public List<string> FullNameOfTeacher { get; set; }
        public List<string> FullNameOfTutor { get; set; }
    }
}