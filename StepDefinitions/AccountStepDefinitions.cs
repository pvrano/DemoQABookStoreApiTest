using System;
using BookStoreApiReqnrollTest.Helpers;
using BookStoreApiReqnrollTest.Models;
using NUnit.Framework;
using Reqnroll;
using RestSharp;
using SpecFlow.Internal.Json;

namespace BookStoreApiReqnrollTest.StepDefinitions
{
    [Binding]
    public class AccountStepDefinitions
    {
        private readonly TestClient _testClient;
        private readonly ScenarioContext _scenarioContext;

        public AccountStepDefinitions(ScenarioContext sc)
        {
            _scenarioContext = sc;
            _testClient = new TestClient("https://demoqa.com");
        }


        [When("I create a new user with name {string} and password {string}")]
        public void WhenICreateANewUserWithNameAndPassword(string name, string password)
        {
            _scenarioContext["Response"] = _testClient.createNewUser(name, password);

        }

        [Then("A new user should be created with unique userID")]
        public void ThenANewUserShouldBeCreatedWithUniqueUserID()
        {
            RestResponse<UserResponse> response = _scenarioContext.Get<RestResponse<UserResponse>>("Response");
            UserResponse content = response.Data;
            Console.WriteLine(content);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.IsSuccessStatusCode, Is.EqualTo(true));
        }

        [Given("I have the userID {string}")]
        public void GivenIHaveTheUserID_Bfbb_Bbddecc(string userID)
        {

            _scenarioContext["UserID"] = userID;
        }

        [When("I get the user with userID")]
        public void WhenIGetTheUserWithUserID()
        {
            string userID = _scenarioContext.Get<string>("UserID");
            try
            {
                var response = _testClient.getUserById(userID) as RestResponse<UserResponse>;
                _scenarioContext["Response"] = response;
                UserResponse user = response.Data;
                Console.WriteLine(response.Data);
                _scenarioContext["User"] = user;
            }
            catch (NotAuthorisedException ex)
            {
                _scenarioContext["Exception"] = ex;
            }
        }



        [Then("It should throw Unauthorized exception with code {string} and message {string}")]
        public void ThenItShouldHandleUnauthorizedException(string code, string message)
        {
            NotAuthorisedException ex = _scenarioContext.Get<NotAuthorisedException>("Exception");
            Assert.That(ex, Is.Not.Null);

            Assert.That(ex.NotAuthorisedExceptionResponse.Code, Is.EqualTo(code));
            Assert.That(ex.NotAuthorisedExceptionResponse.Message, Is.EqualTo(message));


        }

        [When("I authorise the user with name {string} and password {string}")]
        public void WhenIGenerateATokenWithUsernameAndPassword(string username, string password)
        {
            try
            {
                var response = _testClient.generateToken(username, password) as RestResponse<GenerateTokenResponse>;
                _scenarioContext["Response"] = response;
                GenerateTokenResponse tokenResponse = response.Data;
                Console.WriteLine(tokenResponse);
                _scenarioContext["Token"] = tokenResponse.Token;
            }
            catch (NotAuthorisedException ex)
            {
                _scenarioContext["Exception"] = ex;
            }
        }

        [Then("The user should be authorised successfully")]
        public void ThenTheUserShouldBeAuthorisedSuccessfully()
        {
            RestResponse<GenerateTokenResponse> response = _scenarioContext.Get<RestResponse<GenerateTokenResponse>>("Response");
            GenerateTokenResponse tokenResponse = response.Data;
            Assert.That(response, Is.Not.Null);
            Assert.That(response.IsSuccessStatusCode, Is.EqualTo(true));
            Assert.That(tokenResponse.Token, Is.Not.Null.Or.Empty);
            _scenarioContext["Token"] = tokenResponse.Token;
            Console.WriteLine($"Token: {tokenResponse.Token}");
        }

    }
}
