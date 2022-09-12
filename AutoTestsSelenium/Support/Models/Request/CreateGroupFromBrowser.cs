namespace AutoTestsSelenium.Support.Models.Request
{
    public class CreateGroupFromBrowser
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public List<string> Teachers { get; set; }
        public List<string> Tutors { get; set; }
    }
}
