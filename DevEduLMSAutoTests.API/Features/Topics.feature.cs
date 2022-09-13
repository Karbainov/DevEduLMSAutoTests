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
    public partial class TopicsFeature : object, Xunit.IClassFixture<TopicsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Topics.feature"
#line hidden
        
        public TopicsFeature(TopicsFeature.FixtureData fixtureData, DevEduLMSAutoTests_API_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Topics", "A short summary of the feature", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Add new topics for courses by methodist")]
        [Xunit.TraitAttribute("FeatureTitle", "Topics")]
        [Xunit.TraitAttribute("Description", "Add new topics for courses by methodist")]
        [Xunit.TraitAttribute("Category", "methodist")]
        public void AddNewTopicsForCoursesByMethodist()
        {
            string[] tagsOfScenario = new string[] {
                    "methodist"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new topics for courses by methodist", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
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
                table28.AddRow(new string[] {
                            "Maksim",
                            "Metodist",
                            "string",
                            "maksimmetodist32@student.com",
                            "metodist",
                            "password",
                            "SaintPetersburg",
                            "23.07.1993",
                            "string",
                            "89998887766"});
#line 7
testRunner.Given("register new user metodist", ((string)(null)), table28, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table29.AddRow(new string[] {
                            "marina@example.com",
                            "marinamarina"});
#line 10
 testRunner.And("authorize user as manager", ((string)(null)), table29, "And ");
#line hidden
#line 13
 testRunner.And("manager add role metodist to user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table30.AddRow(new string[] {
                            "maksimmetodist32@student.com",
                            "password"});
#line 14
 testRunner.And("authorize user as methodist", ((string)(null)), table30, "And ");
#line hidden
                TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Duration"});
                table31.AddRow(new string[] {
                            "functions14",
                            "12"});
#line 17
 testRunner.And("methodist create a topic", ((string)(null)), table31, "And ");
#line hidden
                TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                            "Position"});
                table32.AddRow(new string[] {
                            "1"});
#line 20
    testRunner.And("methodist add topic to course", ((string)(null)), table32, "And ");
#line hidden
#line 23
 testRunner.And("methodist can see the list of all topics in course with this topic", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Duration"});
                table33.AddRow(new string[] {
                            "cycles3",
                            "20"});
#line 24
 testRunner.And("methodist update topic", ((string)(null)), table33, "And ");
#line hidden
#line 27
 testRunner.And("methodist can see updated topic", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                            "Position"});
                table34.AddRow(new string[] {
                            "22"});
#line 28
    testRunner.And("methodist change order of topics", ((string)(null)), table34, "And ");
#line hidden
#line 31
 testRunner.And("methodist can see changed order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                TopicsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                TopicsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
