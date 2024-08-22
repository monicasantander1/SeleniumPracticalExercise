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
        /// Enter First and Last name
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public void SetNames(string firstname, string lastname)
        {
            SendKeys(_firstNameFieldLocator, firstname);
            SendKeys(_lastNameFieldLocator, lastname);
            IWebElement saveButton = Driver.FindElement(_saveButtonLocator);
            Click(_saveButtonLocator);
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.StalenessOf(saveButton));
        }

        /// <summary>
        /// get Employee Id value & returns Id #
        /// </summary>
        /// <returns></returns>
        public string GetEmployeeId() 
        {                 
            return GetValue(_employeeIdLocator); 
        } 
    }
}