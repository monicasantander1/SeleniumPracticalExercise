using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V125.CSS;
using OpenQA.Selenium.DevTools.V125.Page;
using SeleniumPracticalExercise.PageObjects.Common;


namespace SeleniumPracticalExercise.PageObjects
{
    public class VerifyEmployee : BasePageLocal
    {
        private readonly By EmployeeId = By.CssSelector("div.oxd-grid-2 input");     
        private readonly By SaveButton = By.CssSelector("button[type='submit']");   
        private readonly By PIMButton = By.CssSelector("a[href='/web/index.php/pim/viewPimModule']");   
        private readonly By TxtBoxEmployeeID = By.CssSelector("div.oxd-input-group input.oxd-input");  
        private readonly By SubmitBtn = By.CssSelector("button[type='submit']");  
        private readonly By ExpectedID = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][2]/div");  
        private readonly By ExpectedFirstName = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][3]/div");  
        private readonly By ExpectedLastName = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][4]/div");   
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
        public void SubmitButton() 
        {
            Click(SubmitBtn);
        }
        public void verifyEmployeeId(string employeeId) // to verify ID # in search result
        {
            string expectedId = GetText(ExpectedID);
            Assert.AreEqual(employeeId, expectedId, "Employee ID is not match expected value.");
        }
        public void verifyName(string firstName, string lastName)  // to verify name in searhc result
        {
            string expectedFirstname = GetText(ExpectedFirstName);
            Assert.AreEqual(firstName, expectedFirstname, "First name does not match expected value.");
            string expectedLastname = GetText(ExpectedLastName);
            Assert.AreEqual(lastName, expectedLastname, "Last name does not match expected value.");
        }
    }
}