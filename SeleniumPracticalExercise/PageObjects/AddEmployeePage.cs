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
        /// Enter Firstname & Lastname
        /// then Click Save
        /// did stale so we can wait for element to save. 
        /// </summary>
        public void SetEnterNames(string firstname, string lastname)
        {
            SendKeys(_firstNameFieldLocator, firstname);
            SendKeys(_lastNameFieldLocator, lastname);
            IWebElement saveButton = Driver.FindElement(_saveButtonLocator);
            Click(_saveButtonLocator);
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.StalenessOf(saveButton));
        }

        /// <summary>
        /// get Employee Id value & returns the Id #
        /// </summary>
        public string GetIdNum() 
        {                 
            return GetValue(_employeeIdLocator); 
        } 
    }
}