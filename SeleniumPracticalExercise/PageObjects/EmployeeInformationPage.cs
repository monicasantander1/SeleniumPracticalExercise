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
        /// Sets the employee Id to employeeId
        /// </summary>
        /// <param name="employeeId"> We are storing the locator id here. </param>
        public void SetEmployeeId(string employeeId)
        {
            EditBoxSendKeysAndVerify(_employeeIdFieldLocator, employeeId);
            Click(_searchButtonLocator);
        }

        /// <summary>
        /// Gets the employee ID from search results
        /// </summary>
        /// <returns>The text in the Employeeid field.</returns>
        public string GetEmployeeIdSearchResults()
        {
            return GetText(_idResultsLocator);
        }

        /// <summary>
        /// Gets the first name from search result
        /// </summary>
        /// <returns>The text in the first name field.</returns>
        public string GetFirstNameSearchResults()
        {
            return GetText(_firstNameResultsLocator);
        }

        /// <summary>
        /// Gets the last name from search result
        /// </summary>
        /// <returns>The text in the Last Name field.</returns>
        public string GetLastNameSearchResults()
        {
            return GetText(_lastNameResultsLocator);
        }
    }
}