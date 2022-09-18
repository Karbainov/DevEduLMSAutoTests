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
    public partial class SpecialTwoPointFiveFeature : object, Xunit.IClassFixture<SpecialTwoPointFiveFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CreatingHomeworkByMethodologist.feature"
#line hidden
        
        public SpecialTwoPointFiveFeature(SpecialTwoPointFiveFeature.FixtureData fixtureData, AutoTestsSelenium_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "SpecialTwoPointFive", "A short summary of the feature", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Creating an assignment by a methodologist for students")]
        [Xunit.TraitAttribute("FeatureTitle", "SpecialTwoPointFive")]
        [Xunit.TraitAttribute("Description", "Creating an assignment by a methodologist for students")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public void CreatingAnAssignmentByAMethodologistForStudents()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating an assignment by a methodologist for students", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
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
                table9.AddRow(new string[] {
                            "Milana",
                            "Maxina",
                            "string",
                            "milana@student.com",
                            "mila",
                            "password",
                            "SaintPetersburg",
                            "02.07.2000",
                            "string",
                            "89817051890",
                            "Student"});
                table9.AddRow(new string[] {
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
                table9.AddRow(new string[] {
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
#line 7
 testRunner.When("Register users with roles", ((string)(null)), table9, "When ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "Role"});
                table10.AddRow(new string[] {
                            "lera21@methodist.com",
                            "password",
                            "Methodist"});
#line 12
 testRunner.And("Authorization user as methodist", ((string)(null)), table10, "And ");
#line hidden
#line 15
 testRunner.And("Methodist click button add task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Link"});
                table11.AddRow(new string[] {
                            "ЗаданиеЗадание",
                            "string",
                            "http://fjfjf.com"});
#line 16
 testRunner.When("Methodist create draft Homework", ((string)(null)), table11, "When ");
#line hidden
#line 19
 testRunner.Then("Methodist click button save as draft", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 20
 testRunner.When("Methodist see all created homeworks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
 testRunner.And("Methodist click link edit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
 testRunner.When("Methodist edits homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 23
 testRunner.Then("Methodist click button save draft", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password",
                            "Role"});
                table12.AddRow(new string[] {
                            "vitya21@teacher.com",
                            "password",
                            "Teacher"});
#line 24
 testRunner.And("Teacher authorization", ((string)(null)), table12, "And ");
#line hidden
#line 27
 testRunner.And("Teacher click button homework assignment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Link",
                            "StartDate",
                            "EndDate"});
                table13.AddRow(new string[] {
                            "ЗаданиеЗадание",
                            "сделай то то",
                            "http://fjfjf.com",
                            "20.09.2022",
                            "31.12.2022"});
#line 28
 testRunner.When("Teacher fill out a new assignment form", ((string)(null)), table13, "When ");
#line hidden
#line 31
 testRunner.And("Teacher click button publish", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.Then("Student should sees homework", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                SpecialTwoPointFiveFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                SpecialTwoPointFiveFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
