using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V125.CSS;
using OpenQA.Selenium.DevTools.V125.Page;
using SeleniumExtras.WaitHelpers;
using SeleniumPracticalExercise.PageObjects.Common;
using static SeleniumPracticalExercise.PageObjects.Common.BasePageLocal;


namespace SeleniumPracticalExercise.PageObjects
{
    public class VerifyEmployee : BasePageLocal
    {
        private readonly By EmployeeId = By.CssSelector("div.oxd-grid-2 input");     // EMployee ID # Locator
        private readonly By SaveButton = By.CssSelector("button[type='submit']");    // Save Button Locator
        private readonly By PIMButton = By.CssSelector("a[href='/web/index.php/pim/viewPimModule']");   // PIM Locator
        private readonly By TxtBoxEmployeeID = By.CssSelector("div.oxd-input-group input.oxd-input");  // EmployeeID TextBox locator 
        private readonly By SubmitButton = By.CssSelector("button[type='submit']");  // Submit Locator
        private readonly By DisplayedID = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][2]/div");  // search result displayed ID
        private readonly By FirstNameDisplay = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][3]/div");  //search result displayed firstname
        private readonly By LastNameDisplay = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][4]/div");   //search result displayed lastname

        public VerifyEmployee(IWebDriver driver) : base(driver)
        {

        }


        public void ClickSave()
        {
            Click(SaveButton);
        }

        public void ClickPIM()
        {
            Click(PIMButton);
        }
        public string IDNum() // get Emp ID value 
        {                 
            return GetValue(EmployeeId); // well return the ID #
        }


       public void TxtBoxEmpID(string storeEmployeeID) // txtbox Emp ID but need to insert ID
        {
            EditBoxSendKeysAndVerify(TxtBoxEmployeeID, storeEmployeeID);
           
        } 

        public void SubmitBut() 
        {
            Click(SubmitButton);
        }

        public void verifyEmployeeId(string employeeId) // to verify ID # in search result
        {
            string displayId = GetText(DisplayedID);
            Assert.AreEqual(employeeId, displayId, "Employee ID is not match expected value.");
        }
        public void verifyName(string firstName, string lastName)  // to verify name in searhc result
        {
            string displayFirst = GetText(FirstNameDisplay);
            Assert.AreEqual(firstName, displayFirst, "First name does not match expected value.");
            string displayLast = GetText(LastNameDisplay);
            Assert.AreEqual(lastName, displayLast, "Last name does not match expected value.");
        }

    }
}