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
    public partial class StudentHomeworkCheckingFeature : object, Xunit.IClassFixture<StudentHomeworkCheckingFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "StudentHomeworkChecking.feature"
#line hidden
        
        public StudentHomeworkCheckingFeature(StudentHomeworkCheckingFeature.FixtureData fixtureData, DevEduLMSAutoTests_API_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "StudentHomeworkChecking", "Teacher give a homework\r\nStudent pass the homework\r\nTeacher decline it\r\nStudent f" +
                    "ix it and send it second time\r\nTeacher approve it", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Student pass the homework from the second time")]
        [Xunit.TraitAttribute("FeatureTitle", "StudentHomeworkChecking")]
        [Xunit.TraitAttribute("Description", "Student pass the homework from the second time")]
        [Xunit.TraitAttribute("Category", "studentHomework")]
        public void StudentPassTheHomeworkFromTheSecondTime()
        {
            string[] tagsOfScenario = new string[] {
                    "studentHomework"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student pass the homework from the second time", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Patronymic",
                            "Email",
                            "Username",
                            "Password",
                            "City",
                            "BirthDate",
                            "GitHubAccount",
                            "PhoneNumber"});
                table13.AddRow(new string[] {
                            "Lidiya",
                            "Ivanova",
                            "Victorovna",
                            "lidyasha@blabla.com",
                            "Lidya",
                            "password",
                            "SaintPetersburg",
                            "15.12.1990",
                            "string",
                            "89995556633"});
#line 11
 testRunner.Given("Register students", ((string)(null)), table13, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Patronymic",
                            "Email",
                            "Username",
                            "Password",
                            "City",
                            "BirthDate",
                            "GitHubAccount",
                            "PhoneNumber"});
                table14.AddRow(new string[] {
                            "Vasiliy",
                            "Druzhin",
                            "Ivanovich",
                            "vasya@blabla.com",
                            "Vaselyok",
                            "password",
                            "SaintPetersburg",
                            "05.06.1999",
                            "string",
                            "89905552211"});
#line 14
 testRunner.Given("Register teachers", ((string)(null)), table14, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table15.AddRow(new string[] {
                            "marina@example.com",
                            "marinamarina"});
#line 17
 testRunner.Given("Authorize as manager", ((string)(null)), table15, "Given ");
#line hidden
#line 20
 testRunner.And("Give teacher role to first user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table16.AddRow(new string[] {
                            "BlaBla",
                            "2371",
                            "Forming",
                            "08.09.2022",
                            "15.04.2023",
                            "Morning",
                            "900",
                            "20"});
#line 21
 testRunner.And("Manager create new group", ((string)(null)), table16, "And ");
#line hidden
#line 24
 testRunner.And("Manager add users to group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table17.AddRow(new string[] {
                            "vasya@blabla.com",
                            "password"});
#line 25
 testRunner.Given("Authorize as teacher", ((string)(null)), table17, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Links",
                            "IsRequired"});
                table18.AddRow(new string[] {
                            "Apple",
                            "Lemon",
                            "string",
                            "true"});
#line 28
 testRunner.And("Teacher create new task", ((string)(null)), table18, "And ");
#line hidden
                TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                            "StartDate",
                            "EndDate"});
                table19.AddRow(new string[] {
                            "15.09.2022",
                            "28.09.2022"});
#line 31
 testRunner.And("Add new homework", ((string)(null)), table19, "And ");
#line hidden
                TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table20.AddRow(new string[] {
                            "lidyasha@blabla.com",
                            "password"});
#line 34
 testRunner.Given("Authorize as student", ((string)(null)), table20, "Given ");
#line hidden
#line 37
 testRunner.And("Student send passed homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.But("Teacher decline student\'s homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "But ");
#line hidden
#line 39
 testRunner.And("Student send homework from the second time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
 testRunner.When("Teacher approve it", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 41
 testRunner.Then("Homework passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                StudentHomeworkCheckingFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                StudentHomeworkCheckingFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
