using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class EmployeeInformationPage : BasePageLocal
    {
        private readonly By _actualFirstNameLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][3]/div");
        private readonly By _actualIDLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][2]/div");
        private readonly By _actualLastNameLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][4]/div");
        private readonly By _addButtonLocator = By.CssSelector("div.orangehrm-header-container > button");
        private readonly By _employeeIDTxtBoxLocator = By.CssSelector("div.oxd-input-group input.oxd-input"); 
        private readonly By _searchButtonLocator = By.CssSelector("button[type='submit']");

        public EmployeeInformationPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// PIM button
        /// this is the first time on page where we....
        /// Click Add Button
        /// Enter text in Firstname field and LastName field
        /// </summary>
        public void AddButton()
        {
           Click(_addButtonLocator);
        }

        /// <summary>
        /// this is the second time on page where we...... 
        /// search for emp id textbox and insert stored ID
        /// then we click search button
        /// </summary>
        public void SetTxtBoxEmpID(string storeEmployeeID)
        {
            EditBoxSendKeysAndVerify(_employeeIDTxtBoxLocator, storeEmployeeID);
            Click(_searchButtonLocator);
        }

        /// <summary>
        ///  this is to verify ID # in search result
        /// </summary>
        public string verifyEmployeeId()
        {
            return GetText(_actualIDLocator);
        }

        /// <summary>
        ///  this is to verify first name in search result
        /// </summary>
        public string verifyFirstNameResults()
        {
            return GetText(_actualFirstNameLocator);
        }

        /// <summary>
        ///  this is to verify last name in search result
        /// </summary>
        public string verifyLasttNameResults()
        {
            return GetText(_actualLastNameLocator);
        }
    }
}