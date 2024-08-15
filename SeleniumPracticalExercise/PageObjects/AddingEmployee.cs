using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class AddingEmployee : BasePageLocal
    {
        private readonly By _pimLinkLocator = By.XPath("//span[text()='PIM']"); 
        private readonly By _addBtnLocator = By.CssSelector("div.orangehrm-header-container > button"); 
        private readonly By _firstNameTxtBoxLocator = By.CssSelector("input[name='firstName']"); 
        private readonly By _lastNameTxtBoxLocator = By.CssSelector("input[name='lastName']");    
        public AddingEmployee(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Click PIM and Click Add to add the firstname and lastname
        /// </summary>
        public void ClickPIMAdd()
        {
            Click(_pimLinkLocator);
            Click(_addBtnLocator);
        }

        /// <summary>
        /// Enter (SendKeys) for First and Last names
        /// </summary>
        public void EnterNames(string firstname, string lastname)
        {
           SendKeys(_firstNameTxtBoxLocator,firstname);
           SendKeys(_lastNameTxtBoxLocator,lastname); 
        }
    }
}