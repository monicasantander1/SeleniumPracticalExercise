using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class EmployeeInformationPage : BasePageLocal
    {
        private readonly By _addButtonLocator = By.CssSelector("div.orangehrm-header-container > button");
        private readonly By _employeeIdFieldLocator = By.CssSelector("div.oxd-input-group input.oxd-input");
        private readonly By _firstNameResultsLocator = By.CssSelector("div.oxd-table-cell:nth-child(3)");
        private readonly By _idResultsLocator = By.CssSelector("div.oxd-table-cell:nth-child(2)");
        private readonly By _lastNameResultsLocator = By.CssSelector("div.oxd-table-cell:nth-child(4)");
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
        /// Searches for an employee by employee ID
        /// </summary>
        /// <param name="employeeId">The employee's ID.</param>
        public void SearchById(string employeeId)
        {
            EditBoxSendKeysAndVerify(_employeeIdFieldLocator, employeeId);
            Click(_searchButtonLocator);
        }

        /// <summary>
        /// Returns the employee ID from search results
        /// </summary>
        /// <returns>The Employee Id.</returns>
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