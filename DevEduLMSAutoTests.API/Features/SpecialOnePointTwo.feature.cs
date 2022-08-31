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
    [NUnit.Framework.DescriptionAttribute("SpecialOnePointTwo")]
    public partial class SpecialOnePointTwoFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "SpecialOnePointTwo.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "SpecialOnePointTwo", "A short summary of the feature", ProgrammingLanguage.CSharp, featureTags);
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
        [NUnit.Framework.DescriptionAttribute("Сreating an activity for students by teacher")]
        [NUnit.Framework.CategoryAttribute("teacher")]
        [NUnit.Framework.CategoryAttribute("student")]
        public void СreatingAnActivityForStudentsByTeacher()
        {
            string[] tagsOfScenario = new string[] {
                    "teacher",
                    "student"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Сreating an activity for students by teacher", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                            "Valeria",
                            "Puzikova",
                            "string",
                            "lera04@methodist.com",
                            "lera1",
                            "password",
                            "SaintPetersburg",
                            "01.02.1996",
                            "string",
                            "89071961416"});
                table1.AddRow(new string[] {
                            "Milana",
                            "Maxina",
                            "string",
                            "maxina04@teacher.com",
                            "maxina1",
                            "password",
                            "SaintPetersburg",
                            "01.01.1995",
                            "string",
                            "89817051818"});
#line 7
 testRunner.Given("register new user", ((string)(null)), table1, "Given ");
#line hidden
#line 11
 testRunner.And("authorize admina", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.And("manager add roles to user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table2.AddRow(new string[] {
                            "lera04@methodist.com",
                            "password"});
                table2.AddRow(new string[] {
                            "maxina04@teacher.com",
                            "password"});
                table2.AddRow(new string[] {
                            "marina@example.com",
                            "marinamarina"});
#line 13
 testRunner.And("authorize user", ((string)(null)), table2, "And ");
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
                            "GropForTest01",
                            "1370",
                            "Forming",
                            "27.08.2022",
                            "31.12.2022",
                            "string",
                            "1000",
                            "10"});
#line 18
 testRunner.And("manager create new groups", ((string)(null)), table3, "And ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Duration"});
                table4.AddRow(new string[] {
                            "creating a calculator",
                            "3"});
#line 21
 testRunner.And("methodist create topic", ((string)(null)), table4, "And ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Date",
                            "AdditionalMaterials",
                            "GroupId",
                            "Name",
                            "LinkToRecord",
                            "TopicIds",
                            "IsPublished"});
                table5.AddRow(new string[] {
                            "11.09.2022",
                            "string",
                            "1633",
                            "string",
                            "http://fjfjf.com",
                            "697",
                            "false"});
#line 24
 testRunner.And("teacher create a lesson a draft", ((string)(null)), table5, "And ");
#line hidden
#line 28
 testRunner.And("admin add teacher group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
 testRunner.And("teacher sees the published lesson", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "AdditionalMaterials",
                            "LinkToRecord",
                            "Date",
                            "TopicIds"});
                table6.AddRow(new string[] {
                            "string",
                            "http://fjfjf.com",
                            "01.09.2022",
                            "697"});
#line 30
 testRunner.When("teacher update lesson", ((string)(null)), table6, "When ");
#line hidden
#line 33
    testRunner.Then("teacher can see published a lesson", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion