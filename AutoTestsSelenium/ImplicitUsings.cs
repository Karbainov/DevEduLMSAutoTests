﻿global using Xunit;
global using TechTalk.SpecFlow;
global using TechTalk.SpecFlow.Assist;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Chrome;
global using OpenQA.Selenium.Interactions;
global using AutoTestsSelenium.Support;
global using AutoTestsSelenium.Support.FindElements;
global using AutoTestsSelenium.Support.Models.Request;
global using AutoTestsSelenium.Support.Models;
global using AutoTestsSelenium.PageObjects;
global using DevEduLMSAutoTests.API.StepDefinitions;
global using DevEduLMSAutoTests.API.Support.Models.Request;
global using DevEduLMSAutoTests.API.Support;
global using SeleniumExtras.WaitHelpers;
global using OpenQA.Selenium.Support.UI;
global using System.Reflection.Metadata;

[assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]