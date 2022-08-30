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
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ManagerCreatesAGroupAddsUsers")]
    public partial class ManagerCreatesAGroupAddsUsersFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "ManagerCreatesAGroupAddsUsers.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "ManagerCreatesAGroupAddsUsers", "A short summary of the feature", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Manager creates a group adds students and appoints a teacher and tutor")]
        [NUnit.Framework.CategoryAttribute("manager")]
        public void ManagerCreatesAGroupAddsStudentsAndAppointsATeacherAndTutor()
        {
            string[] tagsOfScenario = new string[] {
                    "manager"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Manager creates a group adds students and appoints a teacher and tutor", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                            "PhoneNumber"});
                table1.AddRow(new string[] {
                            "Gabriel",
                            "Wilson",
                            "string",
                            "wl2@gmail.com",
                            "Gabi",
                            "11345678",
                            "SaintPetersburg",
                            "15.04.1999",
                            "string",
                            "89514781247"});
                table1.AddRow(new string[] {
                            "Isabella",
                            "Abramson",
                            "string",
                            "isi2@gmail.com",
                            "Bella",
                            "11345578",
                            "SaintPetersburg",
                            "22.05.2001",
                            "string",
                            "89514551247"});
                table1.AddRow(new string[] {
                            "Sophie",
                            "Anderson",
                            "string",
                            "sophie2@gmail.com",
                            "Sophi",
                            "11344678",
                            "SaintPetersburg",
                            "18.01.1998",
                            "string",
                            "89511781247"});
                table1.AddRow(new string[] {
                            "Maksim",
                            "Karbainov",
                            "string",
                            "maks2@gmail.com",
                            "Maksim",
                            "22345678",
                            "SaintPetersburg",
                            "18.05.1995",
                            "string",
                            "89521496531"});
                table1.AddRow(new string[] {
                            "Elisey",
                            "Kakoyto",
                            "string",
                            "elisey2@gmail.com",
                            "Elisey",
                            "13345678",
                            "SaintPetersburg",
                            "07.10.1996",
                            "string",
                            "89518963148"});
#line 7
testRunner.Given("register new users in the service", ((string)(null)), table1, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table2.AddRow(new string[] {
                            "marina@example.com",
                            "marinamarina"});
#line 14
testRunner.And("authorize manager in servise", ((string)(null)), table2, "And ");
#line hidden
#line 17
testRunner.And("manager add roles to users in service", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "CourseId",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth",
                            "PaymentsCount"});
                table3.AddRow(new string[] {
                            "BaseSPb",
                            "1370",
                            "Forming",
                            "29.09.2022",
                            "25.01.2023",
                            "string",
                            "2500",
                            "3"});
#line 18
testRunner.When("manager create new group in service", ((string)(null)), table3, "When ");
#line hidden
#line 21
testRunner.And("manager add users to group in service", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table4.AddRow(new string[] {
                            "wl2@gmail.com",
                            "11345678"});
                table4.AddRow(new string[] {
                            "isi2@gmail.com",
                            "11345578"});
                table4.AddRow(new string[] {
                            "sophie2@gmail.com",
                            "11344678"});
                table4.AddRow(new string[] {
                            "maks2@gmail.com",
                            "22345678"});
                table4.AddRow(new string[] {
                            "elisey2@gmail.com",
                            "13345678"});
#line 22
testRunner.Then("authorize users in service", ((string)(null)), table4, "Then ");
#line hidden
#line 29
testRunner.And("check the user\'s group in service", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
