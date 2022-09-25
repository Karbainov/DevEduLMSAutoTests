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
    public partial class AuthenticationFeature : object, Xunit.IClassFixture<AuthenticationFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Authentication.feature"
#line hidden
        
        public AuthenticationFeature(AuthenticationFeature.FixtureData fixtureData, AutoTestsSelenium_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Authentication", "Authentication is the act of proving an assertion, such as the identity of a comp" +
                    "uter system user.\r\nUser must enter a valid email and password to successfully au" +
                    "thenticate.", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Authentication on DevEdu web site")]
        [Xunit.TraitAttribute("FeatureTitle", "Authentication")]
        [Xunit.TraitAttribute("Description", "Authentication on DevEdu web site")]
        [Xunit.TraitAttribute("Category", "authentication")]
        public void AuthenticationOnDevEduWebSite()
        {
            string[] tagsOfScenario = new string[] {
                    "authentication"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Authentication on DevEdu web site", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                            "Ilya",
                            "Baikov",
                            "string",
                            "ilya@student.com",
                            "ilya",
                            "password",
                            "SaintPetersburg",
                            "02.07.2000",
                            "string",
                            "89817051890",
                            "Student"});
#line 8
 testRunner.Given("Register new users with roles", ((string)(null)), table1, "Given ");
#line hidden
#line 11
 testRunner.And("Open DevEdu web site https://piter-education.ru:7074/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.And("Open authorization page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 13
 testRunner.And("Enter email \"ilya@student.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.And("Enter password \"password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
 testRunner.When("Click button Enter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 16
 testRunner.Then("Text with name on sidebar should be \"Baikov Ilya\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.And("Text with role on sidebar should be \"Студент\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
 testRunner.And("The notification page should open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Cancel authentication")]
        [Xunit.TraitAttribute("FeatureTitle", "Authentication")]
        [Xunit.TraitAttribute("Description", "Cancel authentication")]
        [Xunit.TraitAttribute("Category", "authentication")]
        public void CancelAuthentication()
        {
            string[] tagsOfScenario = new string[] {
                    "authentication"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cancel authentication", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
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
                table2.AddRow(new string[] {
                            "Ilya",
                            "Baikov",
                            "string",
                            "ilya@student.com",
                            "ilya",
                            "password",
                            "SaintPetersburg",
                            "02.07.2000",
                            "string",
                            "89817051890",
                            "Student"});
#line 22
 testRunner.Given("Register new users with roles", ((string)(null)), table2, "Given ");
#line hidden
#line 25
 testRunner.And("Open DevEdu web site https://piter-education.ru:7074/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
 testRunner.And("Open authorization page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
 testRunner.And("Enter email \"ilya@student.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
 testRunner.And("Enter password \"password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
 testRunner.When("Click button Cancel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.Then("Text in email textbox should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 31
 testRunner.And("Label in email textbox should be \"example@mail.ru\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.And("Text in password textbox should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Authentication with wrong password or email")]
        [Xunit.TraitAttribute("FeatureTitle", "Authentication")]
        [Xunit.TraitAttribute("Description", "Authentication with wrong password or email")]
        [Xunit.TraitAttribute("Category", "authentication")]
        [Xunit.TraitAttribute("Category", "negative")]
        [Xunit.InlineDataAttribute("maks@student.com", "password", "Неправильные логин или пароль", new string[0])]
        [Xunit.InlineDataAttribute("ilya@student.com", "passpass", "Неправильные логин или пароль", new string[0])]
        [Xunit.InlineDataAttribute("ilya@student.com", "PASSWORD", "Неправильные логин или пароль", new string[0])]
        [Xunit.InlineDataAttribute("ilya@student.com", "password11", "Неправильные логин или пароль", new string[0])]
        [Xunit.InlineDataAttribute("ilya@student.com", "pass", "Неправильные логин или пароль", new string[0])]
        [Xunit.InlineDataAttribute("ilya@student.com", "", "Введите пароль", new string[0])]
        public void AuthenticationWithWrongPasswordOrEmail(string email, string password, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "authentication",
                    "negative"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("Password", password);
            argumentsOfScenario.Add("Message", message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Authentication with wrong password or email", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 35
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
                            "Ilya",
                            "Baikov",
                            "string",
                            "ilya@student.com",
                            "ilya",
                            "password",
                            "SaintPetersburg",
                            "02.07.2000",
                            "string",
                            "89817051890",
                            "Student"});
#line 36
 testRunner.Given("Register new users with roles", ((string)(null)), table3, "Given ");
#line hidden
#line 39
 testRunner.And("Open DevEdu web site https://piter-education.ru:7074/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
 testRunner.And("Open authorization page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 41
 testRunner.And(string.Format("Enter email \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.And(string.Format("Enter password \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
 testRunner.When("Click on button Enter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 44
 testRunner.Then(string.Format("Exception message under password textbox should appear with text \"{0}\"", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Authentication with wrong email format")]
        [Xunit.TraitAttribute("FeatureTitle", "Authentication")]
        [Xunit.TraitAttribute("Description", "Authentication with wrong email format")]
        [Xunit.TraitAttribute("Category", "authentication")]
        [Xunit.TraitAttribute("Category", "negative")]
        [Xunit.InlineDataAttribute("", "Введите Email", new string[0])]
        [Xunit.InlineDataAttribute("ilya", "Введен некорректный email", new string[0])]
        [Xunit.InlineDataAttribute("ilya@", "Введен некорректный email", new string[0])]
        [Xunit.InlineDataAttribute("ilya@mail", "Введен некорректный email", new string[0])]
        [Xunit.InlineDataAttribute("ilya@mail.", "Введен некорректный email", new string[0])]
        [Xunit.InlineDataAttribute("ilya@mail.r", "Введен некорректный email", new string[0])]
        [Xunit.InlineDataAttribute("ilya@.ru", "Введен некорректный email", new string[0])]
        [Xunit.InlineDataAttribute("@mail.ru", "Введен некорректный email", new string[0])]
        public void AuthenticationWithWrongEmailFormat(string email, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "authentication",
                    "negative"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("Message", message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Authentication with wrong email format", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 55
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
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
                table4.AddRow(new string[] {
                            "Ilya",
                            "Baikov",
                            "string",
                            "ilya@student.com",
                            "ilya",
                            "password",
                            "SaintPetersburg",
                            "02.07.2000",
                            "string",
                            "89817051890",
                            "Student"});
#line 56
 testRunner.Given("Register new users with roles", ((string)(null)), table4, "Given ");
#line hidden
#line 59
 testRunner.And("Open DevEdu web site https://piter-education.ru:7074/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 60
 testRunner.And("Open authorization page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 61
 testRunner.And(string.Format("Enter email \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 62
 testRunner.And("Enter password \"password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
 testRunner.When("Click on button Enter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 64
 testRunner.Then(string.Format("Exception message under email textbox should appear with text \"{0}\"", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="AuAuthentication with empty email and password textboxes")]
        [Xunit.TraitAttribute("FeatureTitle", "Authentication")]
        [Xunit.TraitAttribute("Description", "AuAuthentication with empty email and password textboxes")]
        [Xunit.TraitAttribute("Category", "authentication")]
        [Xunit.TraitAttribute("Category", "negative")]
        public void AuAuthenticationWithEmptyEmailAndPasswordTextboxes()
        {
            string[] tagsOfScenario = new string[] {
                    "authentication",
                    "negative"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AuAuthentication with empty email and password textboxes", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 77
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
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
                table5.AddRow(new string[] {
                            "Ilya",
                            "Baikov",
                            "string",
                            "ilya@student.com",
                            "ilya",
                            "password",
                            "SaintPetersburg",
                            "02.07.2000",
                            "string",
                            "89817051890",
                            "Student"});
#line 78
testRunner.Given("Register new users with roles", ((string)(null)), table5, "Given ");
#line hidden
#line 81
 testRunner.And("Open DevEdu web site https://piter-education.ru:7074/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 82
 testRunner.And("Open authorization page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
 testRunner.And("Enter email \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
 testRunner.And("Enter password \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 85
 testRunner.When("Click on button Enter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 86
 testRunner.Then("Exception message under email textbox should appear with text \"Введите Email\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 87
 testRunner.And("Exception message under password textbox should appear with text \"Введите пароль\"" +
                        "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                AuthenticationFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AuthenticationFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
