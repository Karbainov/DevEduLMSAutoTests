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
    public partial class StatisticsFeature : object, Xunit.IClassFixture<StatisticsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Statistics.feature"
#line hidden
        
        public StatisticsFeature(StatisticsFeature.FixtureData fixtureData, AutoTestsSelenium_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Statistics", null, ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Teacher chek students homeworks results")]
        [Xunit.TraitAttribute("FeatureTitle", "Statistics")]
        [Xunit.TraitAttribute("Description", "Teacher chek students homeworks results")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public void TeacherChekStudentsHomeworksResults()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher chek students homeworks results", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
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
                table17.AddRow(new string[] {
                            "Ilya1",
                            "Baikov",
                            "string",
                            "ilya1@student.com",
                            "ilya1",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table17.AddRow(new string[] {
                            "Ilya2",
                            "Baikov",
                            "string",
                            "ilya2@student.com",
                            "ilya2",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table17.AddRow(new string[] {
                            "Ilya3",
                            "Baikov",
                            "string",
                            "ilya3@student.com",
                            "ilya3",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table17.AddRow(new string[] {
                            "Ilya4",
                            "Baikov",
                            "string",
                            "ilya4@student.com",
                            "ilya4",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table17.AddRow(new string[] {
                            "Ilya5",
                            "Baikov",
                            "string",
                            "ilya5@student.com",
                            "ilya5",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table17.AddRow(new string[] {
                            "Ilya6",
                            "Baikov",
                            "string",
                            "ilya6@student.com",
                            "ilya6",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table17.AddRow(new string[] {
                            "Ilya7",
                            "Baikov",
                            "string",
                            "ilya7@student.com",
                            "ilya6",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table17.AddRow(new string[] {
                            "Ilya8",
                            "Baikov",
                            "string",
                            "ilya8@student.com",
                            "ilya6",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table17.AddRow(new string[] {
                            "Ilya9",
                            "Baikov",
                            "string",
                            "ilya9@student.com",
                            "ilya6",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table17.AddRow(new string[] {
                            "Anton",
                            "Efremenkov",
                            "string",
                            "ilya@teacher.com",
                            "anton1",
                            "password",
                            "SaintPetersburg",
                            "03.03.1994",
                            "string",
                            "89995554433",
                            "Teacher"});
#line 5
 testRunner.Given("register new users with roles", ((string)(null)), table17, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table18.AddRow(new string[] {
                            "GroupForTest1",
                            "1370",
                            "Forming",
                            "26.08.2022",
                            "26.08.2023",
                            "string",
                            "5000",
                            "10"});
#line 17
 testRunner.And("manager create new group", ((string)(null)), table18, "And ");
#line hidden
#line 20
 testRunner.And("manager add users to group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Link",
                            "StartDate",
                            "EndDate"});
                table19.AddRow(new string[] {
                            "Lists",
                            "Make your own lists",
                            "https://google.com",
                            "10.09.2022",
                            "09.10.2022"});
#line 21
 testRunner.When("teacher create new homework", ((string)(null)), table19, "When ");
#line hidden
#line 25
 testRunner.And("students did their homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                            "FullName",
                            "Result"});
                table20.AddRow(new string[] {
                            "Ilya1 Baikov",
                            "Сдано"});
                table20.AddRow(new string[] {
                            "Ilya2 Baikov",
                            "Сдано"});
                table20.AddRow(new string[] {
                            "Ilya3 Baikov",
                            "Сдано"});
                table20.AddRow(new string[] {
                            "Ilya4 Baikov",
                            "Сдано"});
                table20.AddRow(new string[] {
                            "Ilya5 Baikov",
                            "Сдано"});
                table20.AddRow(new string[] {
                            "Ilya6 Baikov",
                            "Сдано"});
                table20.AddRow(new string[] {
                            "Ilya7 Baikov",
                            "Сдано"});
                table20.AddRow(new string[] {
                            "Ilya8 Baikov",
                            "Сдано"});
                table20.AddRow(new string[] {
                            "Ilya9 Baikov",
                            "Сдано"});
#line 26
 testRunner.And("teacher rate homeworks", ((string)(null)), table20, "And ");
#line hidden
#line 37
 testRunner.Then("teacher should see students results in homewok tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 38
 testRunner.And("teacher should see students results in tab General Progress", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                StatisticsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                StatisticsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
