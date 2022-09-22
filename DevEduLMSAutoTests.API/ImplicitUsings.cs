global using FluentAssertions;
global using TechTalk.SpecFlow;
global using Xunit;
global using System.Text.Json.Serialization;
global using System.Collections.Generic;
global using TechTalk.SpecFlow.Assist;
global using System.Net;
global using System.Net.Http;
global using System.Net.Http.Headers;
global using System.Text;
global using System.Text.Json;
global using System.Data.SqlClient;
global using DevEduLMSAutoTests.API.Support;
global using DevEduLMSAutoTests.API.Support.Models.Response;
global using DevEduLMSAutoTests.API.Support.Models.Request;
global using DevEduLMSAutoTests.API.Clients;
global using DevEduLMSAutoTests.API.Support.Mappers;
global using AutoMapper;

[assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]