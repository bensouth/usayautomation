using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.Pages
{
    public class RegisterPage
    {
        private IWebDriver Driver { get; }
        public RegisterPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        // --- Personal Information ---
        public IWebElement accountCreationPage => Driver.FindElement(By.Id("account-creation_form"));
        public IWebElement title => Driver.FindElement(By.Id("id_gender1"));

        // Mandatory
        public IWebElement customerFirstName => Driver.FindElement(By.Id("customer_firstname"));
        public IWebElement customerLastName => Driver.FindElement(By.Id("customer_lastname"));
        public IWebElement customerEmail => Driver.FindElement(By.Id("email"));
        public IWebElement password => Driver.FindElement(By.Id("passwd"));
        public IWebElement newsletter => Driver.FindElement(By.Id("newsletter"));
        public IWebElement optin => Driver.FindElement(By.Id("optin"));

        // --- Your Address ---
        public IWebElement firstName => Driver.FindElement(By.Id("firstname"));
        public IWebElement lastName => Driver.FindElement(By.Id("lastname"));
        public IWebElement company => Driver.FindElement(By.Id("company"));
        public IWebElement address => Driver.FindElement(By.Id("address1"));
        public IWebElement address2 => Driver.FindElement(By.Id("address2"));
        public IWebElement city => Driver.FindElement(By.Id("city"));
        public IWebElement postcode => Driver.FindElement(By.Id("postcode"));
        public IWebElement other => Driver.FindElement(By.Id("other"));
        public IWebElement phone => Driver.FindElement(By.Id("phone"));
        public IWebElement mobile => Driver.FindElement(By.Id("phone_mobile"));
        public IWebElement alias => Driver.FindElement(By.Id("alias"));
        public IWebElement registerBtn => Driver.FindElement(By.Id("submitAccount"));

        // Error Alert Box
        public IWebElement errorAlertBox => Driver.FindElement(By.XPath("//div[contains(@class, 'alert-danger')]"));

        // Successfully navigated to My Account page 
        public IWebElement myAccount => Driver.FindElement(By.XPath("//p[contains(@class, 'info-account')]"));


        public void DateOfBirthDropdown()
        {
            SelectElement daysDropdown = new SelectElement(Driver.FindElement(By.Id("days")));
            daysDropdown.SelectByValue("1");

            SelectElement monthsDropdown = new SelectElement(Driver.FindElement(By.Id("months")));
            monthsDropdown.SelectByValue("2");

            SelectElement yearsDropdown = new SelectElement(Driver.FindElement(By.Id("years")));
            yearsDropdown.SelectByValue("1994");
        }

        public void StateDropdown()
        {
            SelectElement stateDropdown = new SelectElement(Driver.FindElement(By.Id("id_state")));
            stateDropdown.SelectByValue("3");
        }

        public void ValidatePersonalInfo()
        {
            title.Click();
            customerFirstName.SendKeys("Ben");
            customerLastName.SendKeys("South");
            password.SendKeys("password");
            DateOfBirthDropdown();
            newsletter.Click();
            optin.Click();
        }

        public void ValidateYourAddress()
        {
            firstName.SendKeys("Ben");
            lastName.SendKeys("South");
            company.SendKeys("Usay");
            address.SendKeys("Lakeside Business Park, Usay House");
            address.SendKeys("5 Hercules Court, Broadway Ln");
            city.SendKeys("Cirencester");
            StateDropdown();
            postcode.SendKeys("12345");
            other.SendKeys("01285 864670");
            phone.SendKeys("01273 308897");
            mobile.SendKeys("07463526431");
            alias.SendKeys("Unknown");
        }

        public bool IsErrorAlertBoxDisplayed()
        {
            registerBtn.Click();
            return errorAlertBox.Displayed;
        }

        public void ClickRegister() => registerBtn.Click();
    }
}
