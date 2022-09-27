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
        public void SortBySurname()
        {
            string[] tagsOfScenario = new string[] {
                    "teacher"};
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
                TechTalk.SpecFlow.Table table97 = new TechTalk.SpecFlow.Table(new string[] {
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
                table97.AddRow(new string[] {
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
                table97.AddRow(new string[] {
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
                table97.AddRow(new string[] {
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
                table97.AddRow(new string[] {
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
                table97.AddRow(new string[] {
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
                table97.AddRow(new string[] {
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
 testRunner.Given("Register new users with roles", ((string)(null)), table97, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table98 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table98.AddRow(new string[] {
                            "BlaBla",
                            "2371",
                            "Forming",
                            "08.09.2022",
                            "15.04.2023",
                            "Morning",
                            "900",
                            "20"});
#line 15
 testRunner.And("Create new groups", ((string)(null)), table98, "And ");
#line hidden
                TechTalk.SpecFlow.Table table99 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Role"});
                table99.AddRow(new string[] {
                            "Gennadiy",
                            "Krokodilov",
                            "Student"});
                table99.AddRow(new string[] {
                            "Gennadiy",
                            "Bukin",
                            "Student"});
                table99.AddRow(new string[] {
                            "Gennadiy",
                            "Golub",
                            "Student"});
                table99.AddRow(new string[] {
                            "Gennadiy",
                            "Yula",
                            "Student"});
                table99.AddRow(new string[] {
                            "Gennadiy",
                            "Akril",
                            "Student"});
                table99.AddRow(new string[] {
                            "Serafima",
                            "Pekova",
                            "Teacher"});
#line 18
 testRunner.And("Add users to group \"BlaBla\"", ((string)(null)), table99, "And ");
#line hidden
                TechTalk.SpecFlow.Table table100 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Links",
                            "IsRequired"});
                table100.AddRow(new string[] {
                            "Apple",
                            "Lemon",
                            "string",
                            "true"});
#line 26
 testRunner.And("Admin create new task", ((string)(null)), table100, "And ");
#line hidden
                TechTalk.SpecFlow.Table table101 = new TechTalk.SpecFlow.Table(new string[] {
                            "StartDate",
                            "EndDate"});
                table101.AddRow(new string[] {
                            "01.10.2022",
                            "25.10.2022"});
#line 29
 testRunner.And("Admin add new homework", ((string)(null)), table101, "And ");
#line hidden
                TechTalk.SpecFlow.Table table102 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "String"});
                table102.AddRow(new string[] {
                            "kroko@gmail.com",
                            "password",
                            "link@razdva.ru"});
                table102.AddRow(new string[] {
                            "bukin@student.com",
                            "password",
                            "link@razdva.ru"});
                table102.AddRow(new string[] {
                            "golub@student.com",
                            "password",
                            "link@razdva.ru"});
                table102.AddRow(new string[] {
                            "yula@student.com",
                            "password",
                            "link@razdva.ru"});
                table102.AddRow(new string[] {
                            "kraska@student.com",
                            "password",
                            "link@razdva.ru"});
#line 32
 testRunner.Given("Students authorize and send their homework", ((string)(null)), table102, "Given ");
#line hidden
#line 39
 testRunner.Given("Admin accept three homeworks and decline two", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 40
 testRunner.Given("Open a browser and open login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table103 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table103.AddRow(new string[] {
                            "witch@teacher.com",
                            "password"});
#line 41
 testRunner.Given("Teacher authorize", ((string)(null)), table103, "Given ");
#line hidden
#line 44
 testRunner.Given("Teacher go to common progress", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 45
 testRunner.When("Teacher sort students by sername", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 46
 testRunner.Then("Students should sort by sername", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 49
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table99 = new TechTalk.SpecFlow.Table(new string[] {
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
                table99.AddRow(new string[] {
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
                table99.AddRow(new string[] {
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
                table99.AddRow(new string[] {
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
                table99.AddRow(new string[] {
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
                table99.AddRow(new string[] {
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
                table99.AddRow(new string[] {
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
                table99.AddRow(new string[] {
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
#line 50
 testRunner.Given("Register new users with roles", ((string)(null)), table99, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table100 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table100.AddRow(new string[] {
                            "Паровозик любви",
                            "1370",
                            "Forming",
                            "25.09.2022",
                            "30.01.2023",
                            "string",
                            "5000",
                            "10"});
#line 59
 testRunner.And("Create new groups", ((string)(null)), table100, "And ");
#line hidden
                TechTalk.SpecFlow.Table table101 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Role"});
                table101.AddRow(new string[] {
                            "Isabella",
                            "Abramson",
                            "Student"});
                table101.AddRow(new string[] {
                            "Lilya",
                            "Baikov",
                            "Student"});
                table101.AddRow(new string[] {
                            "Diana",
                            "Noname",
                            "Student"});
                table101.AddRow(new string[] {
                            "Valya",
                            "Baikova",
                            "Student"});
                table101.AddRow(new string[] {
                            "Fakunto",
                            "Arano",
                            "Student"});
                table101.AddRow(new string[] {
                            "Lolo",
                            "Nabokova",
                            "Student"});
                table101.AddRow(new string[] {
                            "Maksim",
                            "Karbainov",
                            "Teacher"});
#line 62
 testRunner.And("Add users to group \"Паровозик любви\"", ((string)(null)), table101, "And ");
#line hidden
#line 71
 testRunner.When("Open DevEdu site https://piter-education.ru:7074/login", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table102 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table102.AddRow(new string[] {
                            "maks@teacher.com",
                            "password"});
#line 72
 testRunner.And("Authorize user in service as teacher", ((string)(null)), table102, "And ");
#line hidden
                TechTalk.SpecFlow.Table table103 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Link",
                            "StartDate",
                            "EndDate"});
                table103.AddRow(new string[] {
                            "QeQe",
                            "LubluDushit",
                            "https://hd.kinopoisk.ru/",
                            "26.09.2022",
                            "28.09.2022"});
#line 75
 testRunner.When("Teacher create new homework for new group \"Паровозик любви\"", ((string)(null)), table103, "When ");
#line hidden
#line 78
 testRunner.And("Exit account as teacher", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table104 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table104.AddRow(new string[] {
                            "isi@gmail.com",
                            "password"});
                table104.AddRow(new string[] {
                            "lil@student.com",
                            "password"});
                table104.AddRow(new string[] {
                            "ilya2@student.com",
                            "password"});
                table104.AddRow(new string[] {
                            "ilya3@student.com",
                            "password"});
                table104.AddRow(new string[] {
                            "ilya4@student.com",
                            "password"});
                table104.AddRow(new string[] {
                            "ilya5@student.com",
                            "password"});
#line 79
 testRunner.And("Students did their homework \"QeQe\"", ((string)(null)), table104, "And ");
#line hidden
                TechTalk.SpecFlow.Table table105 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table105.AddRow(new string[] {
                            "maks@teacher.com",
                            "password"});
#line 87
 testRunner.And("Authorize user in service as teacher", ((string)(null)), table105, "And ");
#line hidden
                TechTalk.SpecFlow.Table table106 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Result"});
                table106.AddRow(new string[] {
                            "Isabella Abramson",
                            "Сдано"});
                table106.AddRow(new string[] {
                            "Lilya Baikov",
                            "Сдано"});
                table106.AddRow(new string[] {
                            "Diana Noname",
                            "не сдано"});
                table106.AddRow(new string[] {
                            "Valya  Baikova",
                            "Сдано"});
                table106.AddRow(new string[] {
                            "Fakunto Arano",
                            "Сдано"});
                table106.AddRow(new string[] {
                            "Lolo Nabokova",
                            "не сдано"});
#line 90
 testRunner.And("Teacher rate homeworks", ((string)(null)), table106, "And ");
#line hidden
#line 98
 testRunner.And("Teacher should see students results to homework in tab General Progress", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 99
 testRunner.When("Teacher click ascending sorting in a column \"Покрыть\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 100
 testRunner.Then("Teacher see list after sort", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 101
 testRunner.And("Teacher click descending sorting in a column \"Покрыть\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
 testRunner.Then("Teacher see list after sort", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
