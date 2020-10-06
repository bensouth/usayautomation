using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public class HomePage
    {
        private IWebDriver Driver { get; }
        public HomePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        IWebElement loginBtn => Driver.FindElement(By.LinkText("Sign in"));

        public void ClickSignIn() => loginBtn.Click();
    }
}
