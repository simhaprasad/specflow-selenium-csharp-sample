using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowSeleniumTests.Pages;

namespace SpecFlowSeleniumTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["driver"] as IWebDriver;
            _loginPage = new LoginPage(_driver);
        }

        [Given("I navigate to the demo login page")]
        public void GivenINavigateToTheDemoLoginPage()
        {
            _loginPage.GoTo();
        }

        [When("I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            // The demo site (the-internet.herokuapp.com) expects these credentials for success
            _loginPage.Login("tomsmith", "SuperSecretPassword!");
        }

        [Then("I should see the secure area")]
        public void ThenIShouldSeeTheSecureArea()
        {
            Assert.IsTrue(_loginPage.IsLoggedIn(), "Expected to be in the secure area after successful login.");
        }
    }
}
