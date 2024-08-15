using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V125.CSS;
using OpenQA.Selenium.DevTools.V125.Page;
using SeleniumPracticalExercise.PageObjects.Common;


namespace SeleniumPracticalExercise.PageObjects
{
    public class VerifyEmployee : BasePageLocal
    {
        private readonly By _employeeIdLocator = By.CssSelector("div.oxd-grid-2 input");     
        private readonly By _saveButtonLocator = By.CssSelector("button[type='submit']");   
        private readonly By _pIMButtonLocator = By.CssSelector("a[href='/web/index.php/pim/viewPimModule']");   
        private readonly By _txtBoxEmployeeIDLocator = By.CssSelector("div.oxd-input-group input.oxd-input");  
        private readonly By _submitBtnLocator = By.CssSelector("button[type='submit']");  
        private readonly By _expectedIDLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][2]/div");  
        private readonly By _expectedFirstNameLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][3]/div");  
        private readonly By _expectedLastNameLocator = By.XPath("//div[contains(@class,'oxd-table-row--clickable')]//div[text()=''][4]/div");   
        public VerifyEmployee(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Click save button
        /// </summary>
        public void ClickSave()
        {
            Click(_saveButtonLocator);
            WaitAfterAction();
        }

        /// <summary>
        /// thread sleep cause if I dont then the name does not save
        /// then we click PIM
        /// </summary>
        public void ClickPIM()
        {
            Click(_pIMButtonLocator);
        }

        /// <summary>
        /// get Emp ID value & returns the ID #
        /// </summary>
        public string IDNum() 
        {                 
            return GetValue(_employeeIdLocator); 
        } 

   /*     public string IDNum()
        {
            get 
            { 
                return EmployeeId; 
            }
            set 
            { 
                EmployeeId = Value; 
            }
            
        } */

        /// <summary>
        ///  txtbox Emp ID but need to insert ID
        /// </summary>
        public void TxtBoxEmpID(string storeEmployeeID) 
        {
            EditBoxSendKeysAndVerify(_txtBoxEmployeeIDLocator, storeEmployeeID);
        } 

        public void SubmitButton() 
        {
            Click(_submitBtnLocator);
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