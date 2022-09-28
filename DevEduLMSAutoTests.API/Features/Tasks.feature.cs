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
namespace DevEduLMSAutoTests.API.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class TasksFeature : object, Xunit.IClassFixture<TasksFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Tasks.feature"
#line hidden
        
        public TasksFeature(TasksFeature.FixtureData fixtureData, DevEduLMSAutoTests_API_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Tasks", "The methodist creates a task, edits it.\r\nThe teacher posts this task.\r\nThe studen" +
                    "t sees it.", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Add new task for students by methodist")]
        [Xunit.TraitAttribute("FeatureTitle", "Tasks")]
        [Xunit.TraitAttribute("Description", "Add new task for students by methodist")]
        [Xunit.TraitAttribute("Category", "methodist")]
        [Xunit.TraitAttribute("Category", "admin")]
        [Xunit.TraitAttribute("Category", "teacher")]
        [Xunit.TraitAttribute("Category", "student")]
        [Xunit.TraitAttribute("Category", "task")]
        [Xunit.TraitAttribute("Category", "homework")]
        public void AddNewTaskForStudentsByMethodist()
        {
            string[] tagsOfScenario = new string[] {
                    "methodist",
                    "admin",
                    "teacher",
                    "student",
                    "task",
                    "homework"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new task for students by methodist", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
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
                table21.AddRow(new string[] {
                            "Ilya",
                            "Baikov",
                            "string",
                            "ilya075@student.com",
                            "ilya1",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766",
                            "Student"});
                table21.AddRow(new string[] {
                            "Maksim",
                            "Karbainov",
                            "string",
                            "ilya076@methodist.com",
                            "maksim1",
                            "password",
                            "SaintPetersburg",
                            "01.01.1995",
                            "string",
                            "89997776655",
                            "Methodist"});
                table21.AddRow(new string[] {
                            "Elisey",
                            "Kakoyto",
                            "string",
                            "ilya077@techer.com",
                            "elisey1",
                            "password",
                            "SaintPetersburg",
                            "02.02.1996",
                            "string",
                            "89996665544",
                            "Teacher"});
                table21.AddRow(new string[] {
                            "Anton",
                            "Efremenkov",
                            "string",
                            "ilya078@tutor.com",
                            "anton1",
                            "password",
                            "SaintPetersburg",
                            "03.03.1994",
                            "string",
                            "89995554433",
                            "Tutor"});
#line 9
    testRunner.Given("register new users with roles", ((string)(null)), table21, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table22.AddRow(new string[] {
                            "GropForTest1",
                            "1370",
                            "Forming",
                            "26.08.2022",
                            "26.08.2023",
                            "string",
                            "5000",
                            "10"});
#line 15
    testRunner.And("manager create new group", ((string)(null)), table22, "And ");
#line hidden
#line 18
    testRunner.And("manager add users to group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Links",
                            "IsRequired",
                            "CourseIds"});
                table23.AddRow(new string[] {
                            "Test",
                            "Test",
                            "Link",
                            "true",
                            "1370"});
#line 19
    testRunner.And("methodist create new task", ((string)(null)), table23, "And ");
#line hidden
                TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Links",
                            "IsRequired"});
                table24.AddRow(new string[] {
                            "1",
                            "2",
                            "3",
                            "true"});
#line 22
    testRunner.And("methodist update task", ((string)(null)), table24, "And ");
#line hidden
#line 26
    testRunner.When("teacher sees task by id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                            "StartDate",
                            "EndDate"});
                table25.AddRow(new string[] {
                            "15.09.2022",
                            "30.09.2022"});
#line 27
    testRunner.And("teacher post task", ((string)(null)), table25, "And ");
#line hidden
#line 30
    testRunner.Then("student should sees task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                TasksFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                TasksFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
