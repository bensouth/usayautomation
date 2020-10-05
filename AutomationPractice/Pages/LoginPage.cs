using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractice.Pages
{
    public class LoginPage
    {
        private IWebDriver Driver { get; }

        public LoginPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        IWebElement CreateAccountText => Driver.FindElement(By.LinkText("Create an account"));

        // --- Create an account ---
        IWebElement CreateAccountEmailAddressInput => Driver.FindElement(By.Id("email_create"));
        IWebElement CreateAccountBtn => Driver.FindElement(By.Id("SubmitCreate"));

        // --- Sign in ---
        IWebElement LoginEmailAddressInput => Driver.FindElement(By.Id("email"));
        IWebElement LoginPassword => Driver.FindElement(By.Id("passwd"));
        IWebElement SignInBtn => Driver.FindElement(By.Id("SubmitLogin"));


        // Error Alert Box
        public IWebElement errorAlertBox => Driver.FindElement(By.XPath("//div[contains(@class, 'alert-danger')]"));

        // ---- Run out of time to get this to work as these didn't have IDs so needed to use XPath which was being a pain.
        //public IWebElement invalidEmailAddress => Driver.FindElement(By.LinkText("Invalid email address."));
        //public IWebElement emailAddressRequired => Driver.FindElement(By.LinkText("An email address required."));

        
        public bool CreateAccountTextDisplayed() => CreateAccountText.Displayed;


        public void EnterEmailAddressToCreateAccount()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Random number = new Random();
            //int randomNum = number.Next();

            CreateAccountEmailAddressInput.SendKeys("bsouth@live.co.uk");
            CreateAccountBtn.Click();
        }

        public bool LoginWithInvalidPassword()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginEmailAddressInput.SendKeys("invalid");
            SignInBtn.Click();
            return errorAlertBox.Displayed;
        }

        public bool LoginWithoutPassword()
        {
            LoginEmailAddressInput.Clear();
            LoginEmailAddressInput.SendKeys("withoutpassword@live.co.uk");
            SignInBtn.Click();
            return errorAlertBox.Displayed;
        }

        public void LoginWithPassword()
        {
            LoginEmailAddressInput.Clear();
            LoginEmailAddressInput.SendKeys("bsouth@live.co.uk");
            LoginPassword.SendKeys("password");
            SignInBtn.Click();
        }
    }
}
