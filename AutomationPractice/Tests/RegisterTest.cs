using AutomationPractice.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationPractice
{
    public class RegisterTest
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
        public void RegisterAccount()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.ClickSignIn();

            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.EnterEmailAddressToCreateAccount();

            RegisterPage registerPage = new RegisterPage(webDriver);
            
            // Is the alert box displayed when mandatory fields have not been submitted
            registerPage.IsErrorAlertBoxDisplayed();
            registerPage.ValidatePersonalInfo();
            registerPage.ValidateYourAddress();
            registerPage.ClickRegister();
        }

        // Close the browser after tests have finished
       [TearDown]
        public void TearDown() => webDriver.Quit();
    }
}