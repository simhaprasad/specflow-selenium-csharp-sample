# SpecFlow + Selenium + C# sample

This repository contains a minimal SpecFlow (Gherkin) + C# + Selenium sample project using .NET 6 and NUnit. It is intended as a learning starter so you can open, run, and explore how feature files map to step definitions and Page Objects.

Prerequisites
- .NET 6 SDK
- Google Chrome browser installed
- (Optional) Visual Studio 2022 / VS Code + C# extensions

Run the tests
1) From the repository root run:
   cd SpecFlowSeleniumTests
   dotnet restore
   dotnet test

Notes
- The project uses WebDriverManager to download a matching ChromeDriver at runtime.
- Features are under the `Features` folder and step definitions are under `Steps`.
