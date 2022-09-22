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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Statistics", "Information about student attendance, results of homeworks", ProgrammingLanguage.CSharp, featureTags);
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
        [Xunit.TraitAttribute("Category", "statistics")]
        [Xunit.TraitAttribute("Category", "teacher")]
        [Xunit.TraitAttribute("Category", "homework")]
        public void TeacherChekStudentsHomeworksResults()
        {
            string[] tagsOfScenario = new string[] {
                    "statistics",
                    "teacher",
                    "homework"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher chek students homeworks results", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
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
                table36.AddRow(new string[] {
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
                table36.AddRow(new string[] {
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
                table36.AddRow(new string[] {
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
                table36.AddRow(new string[] {
                            "Anton",
                            "Efremenkov",
                            "string",
                            "anton@teacher.com",
                            "anton1",
                            "password",
                            "SaintPetersburg",
                            "03.03.1994",
                            "string",
                            "89995554433",
                            "Teacher"});
#line 7
 testRunner.Given("Administrator registers new users with roles", ((string)(null)), table36, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseName",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table37.AddRow(new string[] {
                            "Group 1",
                            "Базовый C#",
                            "Forming",
                            "26.08.2022",
                            "26.08.2023",
                            "string",
                            "5000",
                            "10"});
#line 13
 testRunner.And("Admin create new groups", ((string)(null)), table37, "And ");
#line hidden
                TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Role"});
                table38.AddRow(new string[] {
                            "Ilya1",
                            "Baikov",
                            "Student"});
                table38.AddRow(new string[] {
                            "Ilya2",
                            "Baikov",
                            "Student"});
                table38.AddRow(new string[] {
                            "Ilya3",
                            "Baikov",
                            "Student"});
                table38.AddRow(new string[] {
                            "Anton",
                            "Efremenkov",
                            "Teacher"});
#line 16
 testRunner.And("Admin add users to group \"Group 1\"", ((string)(null)), table38, "And ");
#line hidden
#line 22
 testRunner.When("Open DevEdu web site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table39.AddRow(new string[] {
                            "anton@teacher.com",
                            "password"});
#line 23
 testRunner.And("Authorize user", ((string)(null)), table39, "And ");
#line hidden
                TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Link",
                            "StartDate",
                            "EndDate"});
                table40.AddRow(new string[] {
                            "Lists",
                            "Make your own lists",
                            "https://google.com",
                            "22.09.2022",
                            "09.10.2022"});
#line 26
 testRunner.And("teacher create new homework for group \"Group 1\"", ((string)(null)), table40, "And ");
#line hidden
#line 29
 testRunner.And("User exit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table41.AddRow(new string[] {
                            "ilya1@student.com",
                            "password"});
                table41.AddRow(new string[] {
                            "ilya2@student.com",
                            "password"});
                table41.AddRow(new string[] {
                            "ilya3@student.com",
                            "password"});
#line 30
 testRunner.And("Students did their homework \"Lists\"", ((string)(null)), table41, "And ");
#line hidden
                TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table42.AddRow(new string[] {
                            "anton@teacher.com",
                            "password"});
#line 35
 testRunner.And("Authorize user", ((string)(null)), table42, "And ");
#line hidden
                TechTalk.SpecFlow.Table table43 = new TechTalk.SpecFlow.Table(new string[] {
                            "FullName",
                            "Result"});
                table43.AddRow(new string[] {
                            "Ilya1 Baikov",
                            "Сдано"});
                table43.AddRow(new string[] {
                            "Ilya2 Baikov",
                            "Сдано"});
                table43.AddRow(new string[] {
                            "Ilya3 Baikov",
                            "Сдано"});
#line 38
 testRunner.And("Teacher rate homeworks", ((string)(null)), table43, "And ");
#line hidden
                TechTalk.SpecFlow.Table table44 = new TechTalk.SpecFlow.Table(new string[] {
                            "FullName",
                            "Result"});
                table44.AddRow(new string[] {
                            "Ilya1 Baikov",
                            "Сдано"});
                table44.AddRow(new string[] {
                            "Ilya2 Baikov",
                            "Сдано"});
                table44.AddRow(new string[] {
                            "Ilya3 Baikov",
                            "Сдано"});
#line 43
 testRunner.Then("Teacher should see students results in homework \"Lists\" page", ((string)(null)), table44, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table45 = new TechTalk.SpecFlow.Table(new string[] {
                            "FullName",
                            "Result"});
                table45.AddRow(new string[] {
                            "Ilya1 Baikov",
                            "Сдано"});
                table45.AddRow(new string[] {
                            "Ilya2 Baikov",
                            "Сдано"});
                table45.AddRow(new string[] {
                            "Ilya3 Baikov",
                            "Сдано"});
#line 48
 testRunner.And("teacher should see students results to homework \"Lists\" in tab General Progress", ((string)(null)), table45, "And ");
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
