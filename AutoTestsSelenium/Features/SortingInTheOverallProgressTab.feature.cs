﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AutoTestsSelenium.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class SortingInTheOverallProgressTabFeature : object, Xunit.IClassFixture<SortingInTheOverallProgressTabFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "SortingInTheOverallProgressTab.feature"
#line hidden
        
        public SortingInTheOverallProgressTabFeature(SortingInTheOverallProgressTabFeature.FixtureData fixtureData, AutoTestsSelenium_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "SortingInTheOverallProgressTab", "Teacher sort students progress by surname", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Sort by surname")]
        [Xunit.TraitAttribute("FeatureTitle", "SortingInTheOverallProgressTab")]
        [Xunit.TraitAttribute("Description", "Sort by surname")]
        [Xunit.TraitAttribute("Category", "teacher")]
        [Xunit.TraitAttribute("Category", "homework")]
        public void SortBySurname()
        {
            string[] tagsOfScenario = new string[] {
                    "teacher",
                    "homework"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort by surname", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table103 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Patronymic",
                            "Email",
                            "Username",
                            "Password",
                            "City",
                            "BirthDate",
                            "GitHubAccount",
                            "PhoneNumber",
                            "Role"});
                table103.AddRow(new string[] {
                            "Gennadiy",
                            "Krokodilov",
                            "string",
                            "kroko@gmail.com",
                            "Gena",
                            "password",
                            "SaintPetersburg",
                            "22.05.2001",
                            "string",
                            "89514551247",
                            "Student"});
                table103.AddRow(new string[] {
                            "Gennadiy",
                            "Bukin",
                            "string",
                            "bukin@student.com",
                            "Gena",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table103.AddRow(new string[] {
                            "Gennadiy",
                            "Golub",
                            "string",
                            "golub@student.com",
                            "Gena",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table103.AddRow(new string[] {
                            "Gennadiy",
                            "Yula",
                            "string",
                            "yula@student.com",
                            "Gena",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table103.AddRow(new string[] {
                            "Gennadiy",
                            "Akril",
                            "string",
                            "kraska@student.com",
                            "Gena",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table103.AddRow(new string[] {
                            "Serafima",
                            "Pekova",
                            "string",
                            "witch@teacher.com",
                            "Sera",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Teacher"});
#line 7
 testRunner.Given("Register new users with roles", ((string)(null)), table103, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table104 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table104.AddRow(new string[] {
                            "BlaBla",
                            "2371",
                            "Forming",
                            "08.09.2022",
                            "15.04.2023",
                            "Morning",
                            "900",
                            "20"});
#line 15
 testRunner.And("Create new groups", ((string)(null)), table104, "And ");
#line hidden
                TechTalk.SpecFlow.Table table105 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Role"});
                table105.AddRow(new string[] {
                            "Gennadiy",
                            "Krokodilov",
                            "Student"});
                table105.AddRow(new string[] {
                            "Gennadiy",
                            "Bukin",
                            "Student"});
                table105.AddRow(new string[] {
                            "Gennadiy",
                            "Golub",
                            "Student"});
                table105.AddRow(new string[] {
                            "Gennadiy",
                            "Yula",
                            "Student"});
                table105.AddRow(new string[] {
                            "Gennadiy",
                            "Akril",
                            "Student"});
                table105.AddRow(new string[] {
                            "Serafima",
                            "Pekova",
                            "Teacher"});
#line 18
 testRunner.And("Add users to group \"BlaBla\"", ((string)(null)), table105, "And ");
#line hidden
                TechTalk.SpecFlow.Table table106 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Links",
                            "IsRequired"});
                table106.AddRow(new string[] {
                            "Apple",
                            "Lemon",
                            "string",
                            "true"});
#line 26
 testRunner.And("Create new task for group \"BlaBla\"", ((string)(null)), table106, "And ");
#line hidden
                TechTalk.SpecFlow.Table table107 = new TechTalk.SpecFlow.Table(new string[] {
                            "StartDate",
                            "EndDate"});
                table107.AddRow(new string[] {
                            "01.10.2022",
                            "25.10.2022"});
#line 29
 testRunner.And("Add new homeworks for group \"BlaBla\" task \"Apple\"", ((string)(null)), table107, "And ");
#line hidden
                TechTalk.SpecFlow.Table table108 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "HomeworkId",
                            "Answer"});
                table108.AddRow(new string[] {
                            "kroko@gmail.com",
                            "password",
                            "",
                            "link@razdva.ru"});
                table108.AddRow(new string[] {
                            "bukin@student.com",
                            "password",
                            "",
                            "link@razdva.ru"});
                table108.AddRow(new string[] {
                            "golub@student.com",
                            "password",
                            "",
                            "link@razdva.ru"});
                table108.AddRow(new string[] {
                            "yula@student.com",
                            "password",
                            "",
                            "link@razdva.ru"});
                table108.AddRow(new string[] {
                            "kraska@student.com",
                            "password",
                            "",
                            "link@razdva.ru"});
#line 32
 testRunner.Given("Students authorize and send homework for group \"BlaBla\" task \"Apple\"", ((string)(null)), table108, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table109 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName"});
                table109.AddRow(new string[] {
                            "Gennadiy",
                            "Krokodilov"});
                table109.AddRow(new string[] {
                            "Gennadiy",
                            "Bukin"});
                table109.AddRow(new string[] {
                            "Gennadiy",
                            "Golub"});
                table109.AddRow(new string[] {
                            "Gennadiy",
                            "Yula"});
                table109.AddRow(new string[] {
                            "Gennadiy",
                            "Akril"});
#line 39
 testRunner.Given("Accept 3 homeworks and decline 2 in group \"BlaBla\" task \"Apple\"", ((string)(null)), table109, "Given ");
#line hidden
#line 46
 testRunner.Given("Open DevEdu web site https://piter-education.ru:7074/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table110 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table110.AddRow(new string[] {
                            "witch@teacher.com",
                            "password"});
#line 47
 testRunner.Given("Authorize user in service as teacher", ((string)(null)), table110, "Given ");
#line hidden
#line 50
 testRunner.Given("Teacher go to common progress", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 51
 testRunner.And("Choose group \"BlaBla\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.When("Teacher sort students by surname", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table111 = new TechTalk.SpecFlow.Table(new string[] {
                            "FullName",
                            "Result"});
                table111.AddRow(new string[] {
                            "Gennadiy Akril",
                            "Не сдано"});
                table111.AddRow(new string[] {
                            "Gennadiy Bukin",
                            "Сдано"});
                table111.AddRow(new string[] {
                            "Gennadiy Golub",
                            "Сдано"});
                table111.AddRow(new string[] {
                            "Gennadiy Krokodilov",
                            "Cдано"});
                table111.AddRow(new string[] {
                            "Gennadiy Yula",
                            "Не сдано"});
#line 53
 testRunner.Then("Students should sort by surname", ((string)(null)), table111, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Teacher sorts students by status")]
        [Xunit.TraitAttribute("FeatureTitle", "SortingInTheOverallProgressTab")]
        [Xunit.TraitAttribute("Description", "Teacher sorts students by status")]
        [Xunit.TraitAttribute("Category", "teacher")]
        public void TeacherSortsStudentsByStatus()
        {
            string[] tagsOfScenario = new string[] {
                    "teacher"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher sorts students by status", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 62
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table112 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Patronymic",
                            "Email",
                            "Username",
                            "Password",
                            "City",
                            "BirthDate",
                            "GitHubAccount",
                            "PhoneNumber",
                            "Role"});
                table112.AddRow(new string[] {
                            "Isabella",
                            "Abramson",
                            "string",
                            "isi@gmail.com",
                            "Bella",
                            "password",
                            "SaintPetersburg",
                            "22.05.2001",
                            "string",
                            "89514551247",
                            "Student"});
                table112.AddRow(new string[] {
                            "Lilya",
                            "Baikov",
                            "string",
                            "lil@student.com",
                            "Lil",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table112.AddRow(new string[] {
                            "Diana",
                            "Noname",
                            "string",
                            "ilya2@student.com",
                            "ilya2",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table112.AddRow(new string[] {
                            "Valya",
                            "Baikova",
                            "string",
                            "ilya3@student.com",
                            "ilya3",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table112.AddRow(new string[] {
                            "Fakunto",
                            "Arano",
                            "string",
                            "ilya4@student.com",
                            "ilya4",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table112.AddRow(new string[] {
                            "Lolo",
                            "Nabokova",
                            "string",
                            "ilya5@student.com",
                            "ilya5",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table112.AddRow(new string[] {
                            "Maksim",
                            "Karbainov",
                            "string",
                            "maks@teacher.com",
                            "Maksim",
                            "password",
                            "SaintPetersburg",
                            "18.05.1995",
                            "string",
                            "89521496531",
                            "Teacher"});
#line 63
 testRunner.Given("Register new users with roles", ((string)(null)), table112, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table113 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table113.AddRow(new string[] {
                            "Паровозик любви",
                            "1370",
                            "Forming",
                            "25.09.2022",
                            "30.01.2023",
                            "string",
                            "5000",
                            "10"});
#line 72
 testRunner.And("Create new groups", ((string)(null)), table113, "And ");
#line hidden
                TechTalk.SpecFlow.Table table114 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Role"});
                table114.AddRow(new string[] {
                            "Isabella",
                            "Abramson",
                            "Student"});
                table114.AddRow(new string[] {
                            "Lilya",
                            "Baikov",
                            "Student"});
                table114.AddRow(new string[] {
                            "Diana",
                            "Noname",
                            "Student"});
                table114.AddRow(new string[] {
                            "Valya",
                            "Baikova",
                            "Student"});
                table114.AddRow(new string[] {
                            "Fakunto",
                            "Arano",
                            "Student"});
                table114.AddRow(new string[] {
                            "Lolo",
                            "Nabokova",
                            "Student"});
                table114.AddRow(new string[] {
                            "Maksim",
                            "Karbainov",
                            "Teacher"});
#line 75
 testRunner.And("Add users to group \"Паровозик любви\"", ((string)(null)), table114, "And ");
#line hidden
#line 84
 testRunner.When("Open DevEdu web site https://piter-education.ru:7074/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table115 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table115.AddRow(new string[] {
                            "maks@teacher.com",
                            "password"});
#line 85
 testRunner.And("Authorize user in service as teacher", ((string)(null)), table115, "And ");
#line hidden
                TechTalk.SpecFlow.Table table116 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Link",
                            "StartDate",
                            "EndDate"});
                table116.AddRow(new string[] {
                            "QeQe",
                            "LubluDushit",
                            "https://hd.kinopoisk.ru/",
                            "28.09.2022",
                            "29.09.2022"});
#line 88
 testRunner.And("Teacher create new homework for group \"Паровозик любви\"", ((string)(null)), table116, "And ");
#line hidden
#line 91
 testRunner.And("Teacher logged out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table117 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table117.AddRow(new string[] {
                            "isi@gmail.com",
                            "password"});
                table117.AddRow(new string[] {
                            "lil@student.com",
                            "password"});
                table117.AddRow(new string[] {
                            "ilya2@student.com",
                            "password"});
                table117.AddRow(new string[] {
                            "ilya3@student.com",
                            "password"});
                table117.AddRow(new string[] {
                            "ilya4@student.com",
                            "password"});
                table117.AddRow(new string[] {
                            "ilya5@student.com",
                            "password"});
#line 92
 testRunner.And("Students did their homework \"QeQe\"", ((string)(null)), table117, "And ");
#line hidden
                TechTalk.SpecFlow.Table table118 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table118.AddRow(new string[] {
                            "maks@teacher.com",
                            "password"});
#line 100
 testRunner.And("Authorize user in service as teacher", ((string)(null)), table118, "And ");
#line hidden
                TechTalk.SpecFlow.Table table119 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Result"});
                table119.AddRow(new string[] {
                            "Isabella Abramson",
                            "Сдано"});
                table119.AddRow(new string[] {
                            "Lilya Baikov",
                            "Сдано"});
                table119.AddRow(new string[] {
                            "Diana Noname",
                            "не сдано"});
                table119.AddRow(new string[] {
                            "Valya  Baikova",
                            "Сдано"});
                table119.AddRow(new string[] {
                            "Fakunto Arano",
                            "Сдано"});
                table119.AddRow(new string[] {
                            "Lolo Nabokova",
                            "не сдано"});
#line 103
 testRunner.And("Teacher rate homeworks", ((string)(null)), table119, "And ");
#line hidden
#line 111
 testRunner.And("Teacher open tab General Progress", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 112
 testRunner.When("Teacher click ascending sorting in a column \"Покрыть\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 113
 testRunner.Then("Teacher should see list after sort on ABC", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 114
 testRunner.And("Teacher click descending sorting in a column \"Покрыть\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 115
 testRunner.Then("Teacher should see list after sort on CBA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                SortingInTheOverallProgressTabFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                SortingInTheOverallProgressTabFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
