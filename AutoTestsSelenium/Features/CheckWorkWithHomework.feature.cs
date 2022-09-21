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
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
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
                table1.AddRow(new string[] {
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
                table1.AddRow(new string[] {
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
                table1.AddRow(new string[] {
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
 testRunner.When("Register users", ((string)(null)), table1, "When ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table2.AddRow(new string[] {
                            "GropForTest01",
                            "1370",
                            "Forming",
                            "11.09.2022",
                            "31.12.2022",
                            "string",
                            "1000",
                            "10"});
#line 13
 testRunner.And("Manager create new group", ((string)(null)), table2, "And ");
#line hidden
#line 16
 testRunner.When("Manager add users to group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table3.AddRow(new string[] {
                            "lera21@methodist.com",
                            "password"});
#line 17
 testRunner.And("Methodist authorization on the site", ((string)(null)), table3, "And ");
#line hidden
#line 20
 testRunner.When("Methodist click button homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
 testRunner.And("Methodist click button add homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "CourseName",
                            "Name",
                            "Description",
                            "Link"});
                table4.AddRow(new string[] {
                            "QA Automation",
                            "ЗаданиеЗадание",
                            "string",
                            "http://fjfjf.com"});
#line 22
 testRunner.Then("Methodist create homework", ((string)(null)), table4, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "Role"});
                table5.AddRow(new string[] {
                            "vitya21@teacher.com",
                            "password",
                            "Teacher"});
#line 25
 testRunner.And("Authorization user as teacher", ((string)(null)), table5, "And ");
#line hidden
#line 28
 testRunner.Then("Teacher lays out the task \"ЗаданиеЗадание\" created by the methodologist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "CourseName",
                            "Name",
                            "Description",
                            "Link",
                            "StartDate",
                            "EndDate"});
                table6.AddRow(new string[] {
                            "QA Automation",
                            "ЗаданиеЗадание",
                            "сделай то то",
                            "http://fjfjf.com",
                            "20.09.2022",
                            "31.12.2022"});
#line 29
 testRunner.When("Teacher create issuing homework", ((string)(null)), table6, "When ");
#line hidden
#line 32
 testRunner.Then("Teacher click button publish", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 33
 testRunner.When("Teacher see all task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table7.AddRow(new string[] {
                            "ilya21@student.com",
                            "password"});
#line 34
 testRunner.And("Student authorization", ((string)(null)), table7, "And ");
#line hidden
#line 37
 testRunner.And("Student click button homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.And("Studen click button to the task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.When("Studen attaches a link \"https://hd.kinopoisk.ru/\" to the completed task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
 testRunner.And("Studen click airplane icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "Role"});
                table8.AddRow(new string[] {
                            "vitya21@teacher.com",
                            "password",
                            "Teacher"});
#line 41
 testRunner.And("Teacher checks homework", ((string)(null)), table8, "And ");
#line hidden
#line 44
 testRunner.Then("Teacher returned homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table9.AddRow(new string[] {
                            "ilya21@student.com",
                            "password"});
#line 45
 testRunner.When("Student attached link \"https://hd.kinopoisk.ru/\" of corrected homework", ((string)(null)), table9, "When ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "Role"});
                table10.AddRow(new string[] {
                            "vitya21@teacher.com",
                            "password",
                            "Teacher"});
#line 48
 testRunner.Then("Teacher accepted homework", ((string)(null)), table10, "Then ");
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
