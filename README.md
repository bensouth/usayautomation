# Automation Practice
Thank you for taking you time to review my automated tests.

I aplogise for it taking a week to be submitted but I was away on holiday.

If I had more than a few hours I would have liked to do the following:
- Provided better handling of the chrome driver & support multiple browsers
- Added a report for the test results
- Implemented a better way of handling methods using Page Object Model

## Installation

Change the location of the web driver in all tests, this needs to match where you have saved the solution as this needs to be able to find the ChromeDriver.exe file.

For example if you have your solution at C:\Downloads\usayautomation\AutomationPractice\ChromeDriver.exe you should change the line below to: 

```python
IWebDriver webDriver = new ChromeDriver(@"C:\Downloads\usayautomation\AutomationPractice\");
```

The files that need to be changed are:
- LoginTest.cs
- RegisterTest.cs
- CheckoutTest.cs

## Usage

Open up the Visual Studio 2019 and run the tests through the Test Explorer.
