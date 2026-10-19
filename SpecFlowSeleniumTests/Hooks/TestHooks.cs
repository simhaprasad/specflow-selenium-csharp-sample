using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowSeleniumTests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Download a compatible chromedriver and start Chrome
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            // Comment out the next line if you want to see the browser when tests run
            // options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            var driver = new ChromeDriver(options);
            _scenarioContext["driver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.ContainsKey("driver"))
            {
                var driver = _scenarioContext["driver"] as IWebDriver;
                try { driver?.Quit(); } catch { }
            }
        }
    }
}
