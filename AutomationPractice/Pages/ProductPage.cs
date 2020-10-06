using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractice.Pages
{
    public class ProductPage
    {
        private IWebDriver Driver { get; }
        public ProductPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        IWebElement searchBar => Driver.FindElement(By.Id("search_query_top"));
        public IWebElement viewProduct => Driver.FindElement(By.XPath("//a[@class='products-block-image content_img clearfix']"));
        public IWebElement addToCartBtn => Driver.FindElement(By.Id("add_to_cart"));
        

        public IWebElement proceedToCheckoutBtn => Driver.FindElement(By.CssSelector("[title=\'Proceed to checkout']"));

        public void SearchForProduct(string product) 
        {
            searchBar.SendKeys(product + "\n");
        }

        public void ClickAddToCart()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            viewProduct.Click();
            addToCartBtn.Click();
        }

        public void ViewCart()
        {
            proceedToCheckoutBtn.Click();
        }

        public void ValidateThatTheCorrectItemHasBeenAdded()
        {
            Assert.IsTrue(Driver.PageSource.Contains("Printed Chiffon Dress"));
        }
    }
}