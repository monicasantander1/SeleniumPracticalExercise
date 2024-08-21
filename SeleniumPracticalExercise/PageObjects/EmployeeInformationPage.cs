using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class EmployeeInformationPage : BasePageLocal
    {
        private readonly By _addButtonLocator = By.CssSelector("div.orangehrm-header-container > button");
        private readonly By _employeeIdFieldLocator = By.CssSelector("div.oxd-input-group input.oxd-input");
        private readonly By _firstNameResultsLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][3]/div");
        private readonly By _idResultsLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][2]/div");
        private readonly By _lastNameResultsLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][4]/div");
        private readonly By _searchButtonLocator = By.CssSelector("button[type='submit']");

        public EmployeeInformationPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Clicks the Add Button
        /// </summary>
        public void ClickAdd()
        {
           Click(_addButtonLocator);
        }

        /// <summary>
        /// search for employee ID field and insert stored ID
        /// then we click search button
        /// </summary>
        /// <param name="storeEmployeeID"></param>
        public void SetEmployeeIdField(string storeEmployeeID)
        {
            EditBoxSendKeysAndVerify(_employeeIdFieldLocator, storeEmployeeID);
            Click(_searchButtonLocator);
        }

        /// <summary>
        ///  Grabbing the Text from the ID in the search results to verify
        /// </summary>
        public string EmployeeIdSearchResults()
        {
            return GetText(_idResultsLocator);
        }

        /// <summary>
        ///  Grabbing the text from the first name in search result to verify
        /// </summary>
        public string FirstNameSearchResults()
        {
            return GetText(_firstNameResultsLocator);
        }

        /// <summary>
        ///  Grabbing the text from the last name in search result to verify
        /// </summary>
        public string LastNameSearchResults()
        {
            return GetText(_lastNameResultsLocator);
        }
    }
}