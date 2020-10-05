using AutomationPractice.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationPractice.Tests
{
    public class CheckoutTest
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
        public void ValidateItemInCart()
        {
            ProductPage productPage = new ProductPage(webDriver);
            productPage.SearchForProduct("blouse");
            productPage.ClickAddToCart();
            productPage.ViewCart();
            productPage.ValidateThatTheCorrectItemHasBeenAdded();
        }

        // Close the browser after tests have finished
        [TearDown]
        public void TearDown() => webDriver.Quit();
    }
}
