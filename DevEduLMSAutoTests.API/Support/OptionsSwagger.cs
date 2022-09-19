namespace DevEduLMSAutoTests.API.Support
{
    public static class OptionsSwagger
    {
        public const string RoleAdmin = "Admin";
        public const string RoleManager = "Manager";
        public const string RoleMethodist = "Methodist";
        public const string RoleTeacher = "Teacher";
        public const string RoleTutor = "Tutor";
        public const string RoleStudent = "Student";
        public const string ManagersEmail = "marina@example.com";
        public const string ManagersPassword = "marinamarina";
        public const string AdminsEmail = "user@example.com";
        public const string AdminsPassword = "stringst";
        public const string ConnectionString = @"Data Source = 80.78.240.16;Initial Catalog = DevEdu;Persist Security Info = True;User ID = student;Password = qwe!23;";
        public static Dictionary<string, int> Courses = new Dictionary<string, int>
        {
            { "Базовый C#", 1370 },
            { "Frontend React", 1371 },
            { "Backend C#", 2371 },
            { "Базовый Java", 2374 },
            { "Backend Java", 2375 },
            { "QA Automation", 2376 }
        };
        public static SwaggerSignInRequest AdminSignIn = new SwaggerSignInRequest() { Email=AdminsEmail, Password=AdminsPassword };
    }
}