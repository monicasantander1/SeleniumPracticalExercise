using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class AddingEmployee : BasePageLocal
    {
        private readonly By PIMLink = By.XPath("//span[text()='PIM']"); 
        private readonly By AddBtn = By.CssSelector("div.orangehrm-header-container > button"); 
        private readonly By FirstNameTxtBox = By.CssSelector("input[name='firstName']"); 
        private readonly By LastNameTxtBox = By.CssSelector("input[name='lastName']");    
        public AddingEmployee(IWebDriver driver) : base(driver)
        {

        }
        public void ClickPIMAdd()
        {
            Click(PIMLink);
            Click(AddBtn);
        }
        public void EnterNames(string firstname, string lastname)
        {
           SendKeys(FirstNameTxtBox,firstname);
           SendKeys(LastNameTxtBox,lastname); 
        }
    }
}