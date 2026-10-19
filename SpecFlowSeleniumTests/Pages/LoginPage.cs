using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SpecFlowSeleniumTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
        }

        public void Login(string username, string password)
        {
            _wait.Until(d => d.FindElement(OpenQA.Selenium.By.Id("username")).Displayed);
            _driver.FindElement(OpenQA.Selenium.By.Id("username")).SendKeys(username);
            _driver.FindElement(OpenQA.Selenium.By.Id("password")).SendKeys(password);
            _driver.FindElement(OpenQA.Selenium.By.CssSelector("button[type='submit']")).Click();
        }

        public bool IsLoggedIn()
        {
            try
            {
                return _wait.Until(d => d.Url.Contains("/secure"));
            }
            catch
            {
                return false;
            }
        }
    }
}
