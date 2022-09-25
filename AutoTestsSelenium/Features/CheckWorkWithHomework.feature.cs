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
    public partial class CheckWorkWithHomeworkFeature : object, Xunit.IClassFixture<CheckWorkWithHomeworkFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CheckWorkWithHomework.feature"
#line hidden
        
        public CheckWorkWithHomeworkFeature(CheckWorkWithHomeworkFeature.FixtureData fixtureData, AutoTestsSelenium_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "CheckWorkWithHomework", "A short summary of the feature", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Assigned homework by teacher, turned in by student")]
        [Xunit.TraitAttribute("FeatureTitle", "CheckWorkWithHomework")]
        [Xunit.TraitAttribute("Description", "Assigned homework by teacher, turned in by student")]
        [Xunit.TraitAttribute("Category", "teacher")]
        [Xunit.TraitAttribute("Category", "student")]
        [Xunit.TraitAttribute("Category", "manager")]
        public void AssignedHomeworkByTeacherTurnedInByStudent()
        {
            string[] tagsOfScenario = new string[] {
                    "teacher",
                    "student",
                    "manager"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assigned homework by teacher, turned in by student", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
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
                table3.AddRow(new string[] {
                            "Ilya1",
                            "Baikov",
                            "string",
                            "ilya21@student.com",
                            "ilya",
                            "password",
                            "SaintPetersburg",
                            "02.07.2000",
                            "string",
                            "89817051890",
                            "Student"});
                table3.AddRow(new string[] {
                            "Lera",
                            "Puzikova",
                            "string",
                            "lera21@methodist.com",
                            "lera",
                            "password",
                            "SaintPetersburg",
                            "31.01.2000",
                            "string",
                            "89817051892",
                            "Methodist"});
                table3.AddRow(new string[] {
                            "Vitya",
                            "Strashko",
                            "string",
                            "vitya21@teacher.com",
                            "vitya",
                            "password",
                            "SaintPetersburg",
                            "01.08.1995",
                            "string",
                            "89817051893",
                            "Teacher"});
#line 8
 testRunner.When("register users with and assigned roles", ((string)(null)), table3, "When ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table4.AddRow(new string[] {
                            "GropForTest01",
                            "1370",
                            "Forming",
                            "11.09.2022",
                            "31.12.2022",
                            "string",
                            "1000",
                            "10"});
#line 13
 testRunner.And("manager create new group", ((string)(null)), table4, "And ");
#line hidden
#line 16
 testRunner.When("manager add users to group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "LinkToRecord"});
                table5.AddRow(new string[] {
                            "ЗаданиеЗадание",
                            "string",
                            "http://fjfjf.com"});
#line 17
 testRunner.Then("methodist create homework", ((string)(null)), table5, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table6.AddRow(new string[] {
                            "vitya21@teacher.com",
                            "password"});
#line 20
 testRunner.And("authorization user as teacher", ((string)(null)), table6, "And ");
#line hidden
#line 23
 testRunner.And("teacher click button issuing homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.Then("teacher changes role", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "LinkToRecord",
                            "StartDate",
                            "EndDate"});
                table7.AddRow(new string[] {
                            "ЗаданиеЗадание",
                            "сделай то то",
                            "http://fjfjf.com",
                            "20.09.2022",
                            "31.12.2022"});
#line 25
 testRunner.When("teacher create issuing homework", ((string)(null)), table7, "When ");
#line hidden
#line 28
 testRunner.Then("teacher click button publish", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 29
 testRunner.When("teacher see all task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.And("teacher click button exit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table8.AddRow(new string[] {
                            "ilya21@student.com",
                            "password"});
#line 31
 testRunner.And("student authorization", ((string)(null)), table8, "And ");
#line hidden
#line 34
 testRunner.And("student click button homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
 testRunner.And("studen click button to the task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.When("studen attaches a link \"https://hd.kinopoisk.ru/\" to the completed task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 37
 testRunner.And("studen click airplane icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.And("studen click button exit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table9.AddRow(new string[] {
                            "vitya21@teacher.com",
                            "password"});
#line 39
 testRunner.And("teacher checks homework", ((string)(null)), table9, "And ");
#line hidden
#line 43
 testRunner.Then("teacher returned homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 44
 testRunner.And("student attached link of corrected homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
 testRunner.Then("teacher accepted homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                CheckWorkWithHomeworkFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CheckWorkWithHomeworkFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
