using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class EmployeeInformationPage : BasePageLocal
    {
        
        private readonly By _addButtonLocator = By.CssSelector("div.orangehrm-header-container > button");
        private readonly By _employeeIDTxtBoxLocator = By.CssSelector("div.oxd-input-group input.oxd-input");  //EmployeeInfoPage
        private readonly By _expectedIDLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][2]/div");
        private readonly By _expectedFirstNameLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][3]/div");
        private readonly By _expectedLastNameLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][4]/div");
        private readonly By _searchButtonLocator = By.CssSelector("button[type='submit']");

        public EmployeeInformationPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Click Add Button
        /// Enter text in Firstname field and LastName field
        /// </summary>
        public void AddButton()
        {
           Click(_addButtonLocator);
        }

        /// <summary>
        ///  txtbox Emp ID and insert stored ID
        /// </summary>
        public void SetTxtBoxEmpID(string storeEmployeeID)
        {
            EditBoxSendKeysAndVerify(_employeeIDTxtBoxLocator, storeEmployeeID);
        }

        public void SearchButton()
        {
            Click(_searchButtonLocator);
        }

        /// <summary>
        ///  to verify ID # in search result
        /// </summary>
        public void verifyEmployeeId(string employeeId)
        {
            string expectedId = GetText(_expectedIDLocator);
            Assert.AreEqual(employeeId, expectedId, "Employee ID is not match expected value.");
        }

        /// <summary>
        ///  to verify name in searhc result
        /// </summary>
        public void verifyName(string firstName, string lastName)
        {
            string expectedFirstname = GetText(_expectedFirstNameLocator);
            Assert.AreEqual(firstName, expectedFirstname, "First name does not match expected value.");
            string expectedLastname = GetText(_expectedLastNameLocator);
            Assert.AreEqual(lastName, expectedLastname, "Last name does not match expected value.");
        }
    }
}