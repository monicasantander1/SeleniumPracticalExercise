using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumPracticalExercise.PageObjects.Common;


namespace SeleniumPracticalExercise.PageObjects
{
    public class AddEmployeePage : BasePageLocal
    {
        private readonly By _employeeIdLocator = By.CssSelector("div.oxd-grid-2 input");
        private readonly By _firstNameTxtBoxLocator = By.CssSelector("input[name='firstName']");
        private readonly By _lastNameTxtBoxLocator = By.CssSelector("input[name='lastName']");
        private readonly By _saveButtonLocator = By.CssSelector("button[type='submit']");     
        
        public AddEmployeePage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Enter Firstname & Lastname
        /// then Click Save
        /// did stale so we can wait  for element to save. if not it will not find element later
        /// </summary>
        public void EnterNames(string firstname, string lastname)
        {
            SendKeys(_firstNameTxtBoxLocator, firstname);
            SendKeys(_lastNameTxtBoxLocator, lastname);
            IWebElement saveButton = Driver.FindElement(_saveButtonLocator);
            Click(_saveButtonLocator);
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.StalenessOf(saveButton));
        }

        /// <summary>
        /// get Emp ID value & returns the ID #
        /// </summary>
        public string GetIDNum() 
        {                 
            return GetValue(_employeeIdLocator); 
        } 
    }
}