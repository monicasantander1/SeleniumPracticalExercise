using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class AddEmployeePage : BasePageLocal
    {
        private readonly By _employeeIdLocator = By.CssSelector("div.oxd-grid-2 input");
        private readonly By _firstNameFieldLocator = By.CssSelector("input[name='firstName']");
        private readonly By _lastNameFieldLocator = By.CssSelector("input[name='lastName']");
        private readonly By _saveButtonLocator = By.CssSelector("button[type='submit']");     
        
        public AddEmployeePage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Adding an Employee's name
        /// </summary>
        /// <param name="firstName">The employee's first name.</param>
        /// <param name="lastName">The employee's last name.</param>
        public void AddEmployee(string firstName, string lastName)
        {
            SendKeys(_firstNameFieldLocator, firstName);
            SendKeys(_lastNameFieldLocator, lastName);
            IWebElement saveButton = Driver.FindElement(_saveButtonLocator);
            Click(_saveButtonLocator);
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.StalenessOf(saveButton));
        }

        /// <summary>
        /// Returns the employee ID
        /// </summary>
        /// <returns>The Employee ID./</returns>
        public string GetEmployeeId() 
        {                 
            return GetValue(_employeeIdLocator); 
        } 
    }
}