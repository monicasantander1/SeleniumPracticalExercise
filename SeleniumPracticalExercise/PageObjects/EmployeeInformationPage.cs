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
        /// Sets the employee ID to the provided value
        /// </summary>
        /// <param name="employeeId">The employeeId used to find element.</param>
        public void SearchById(string employeeId)
        {
            EditBoxSendKeysAndVerify(_employeeIdFieldLocator, employeeId);
            Click(_searchButtonLocator);
        }

        /// <summary>
        /// Returns the employee ID from search results
        /// </summary>
        /// <returns>The Employeeid Id.</returns>
        public string GetEmployeeIdSearchResults()
        {
            return GetText(_idResultsLocator);
        }

        /// <summary>
        /// Returns the first name from search result
        /// </summary>
        /// <returns>The first name.</returns>
        public string GetFirstNameSearchResults()
        {
            return GetText(_firstNameResultsLocator);
        }

        /// <summary>
        /// Returns the last name from search result
        /// </summary>
        /// <returns>The Last Name.</returns>
        public string GetLastNameSearchResults()
        {
            return GetText(_lastNameResultsLocator);
        }
    }
}