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
    public partial class GroupsFeature : object, Xunit.IClassFixture<GroupsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Groups.feature"
#line hidden
        
        public GroupsFeature(GroupsFeature.FixtureData fixtureData, AutoTestsSelenium_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Groups", "A short summary of the feature", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Front manager creates a group adds students and appoints a teacher and tutor")]
        [Xunit.TraitAttribute("FeatureTitle", "Groups")]
        [Xunit.TraitAttribute("Description", "Front manager creates a group adds students and appoints a teacher and tutor")]
        [Xunit.TraitAttribute("Category", "manager")]
        [Xunit.TraitAttribute("Category", "teacher")]
        [Xunit.TraitAttribute("Category", "tutor")]
        [Xunit.TraitAttribute("Category", "student")]
        public void FrontManagerCreatesAGroupAddsStudentsAndAppointsATeacherAndTutor()
        {
            string[] tagsOfScenario = new string[] {
                    "manager",
                    "teacher",
                    "tutor",
                    "student"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Front manager creates a group adds students and appoints a teacher and tutor", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
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
                table11.AddRow(new string[] {
                            "Isabella",
                            "Abramson",
                            "string",
                            "isi@gmail.com",
                            "Bella",
                            "11345578",
                            "SaintPetersburg",
                            "22.05.2001",
                            "string",
                            "89514551247",
                            "Student"});
                table11.AddRow(new string[] {
                            "Maksim",
                            "Karbainov",
                            "string",
                            "maks@gmail.com",
                            "Maksim",
                            "22345678",
                            "SaintPetersburg",
                            "18.05.1995",
                            "string",
                            "89521496531",
                            "Teacher"});
                table11.AddRow(new string[] {
                            "Elisey",
                            "Kakoyto",
                            "string",
                            "elisey@gmail.com",
                            "Elisey",
                            "13345678",
                            "SaintPetersburg",
                            "07.10.1996",
                            "string",
                            "89518963148",
                            "Tutor"});
#line 7
testRunner.Given("Register new users with roles in service", ((string)(null)), table11, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "GroupName",
                            "CourseName",
                            "FullNameOfTeacher",
                            "FullNameOfTutor"});
                table12.AddRow(new string[] {
                            "BaseSPb",
                            "Базовый C#",
                            "Maksim Karbainov",
                            "Elisey Kakoyto"});
#line 12
testRunner.When("Manager create new group in service", ((string)(null)), table12, "When ");
#line hidden
#line 15
testRunner.And("Manager add student \"Isabella Abramson\" to group \"BaseSPb\" in service", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "CourseName"});
                table13.AddRow(new string[] {
                            "isi@gmail.com",
                            "11345578",
                            "Базовый C#"});
#line 16
testRunner.Then("Authorize student in service and check group", ((string)(null)), table13, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "CourseName"});
                table14.AddRow(new string[] {
                            "maks@gmail.com",
                            "22345678",
                            "Базовый C#"});
#line 19
testRunner.And("Authorize teacher in service and check group", ((string)(null)), table14, "And ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "CourseName"});
                table15.AddRow(new string[] {
                            "elisey@gmail.com",
                            "13345678",
                            "Базовый C#"});
#line 22
testRunner.And("Authorize tutor in service and check group", ((string)(null)), table15, "And ");
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
                GroupsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GroupsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
