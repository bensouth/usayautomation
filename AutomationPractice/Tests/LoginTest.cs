using AutomationPractice.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.Tests
{
    public class LoginTest
    {
        // Setup the Browser driver
        IWebDriver webDriver = new ChromeDriver(@"C:\repos\AutomationPractice\AutomationPractice\");

        [SetUp]
        public void Setup()
        {
            // Navigate to the site
            webDriver.Navigate().GoToUrl("http://automationpractice.com/");
        }

        [Test]
        public void ValidateLogin()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.ClickSignIn();

            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.LoginWithInvalidPassword();
            loginPage.LoginWithoutPassword();
            loginPage.LoginWithPassword();
        }


        // Close the browser after tests have finished
        [TearDown]
        public void TearDown() => webDriver.Quit();
    }
}
