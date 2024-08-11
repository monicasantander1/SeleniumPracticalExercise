using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class PimEmployee : BasePageLocal
    {
        private readonly By PIMLink = By.XPath("//span[text()='PIM']"); // locate PIM button\
        private readonly By AddBtn = By.CssSelector("div.orangehrm-header-container > button"); // locate Add button
        private readonly By FirstNameTxtBox = By.Name("firstName");  // locate firstname txtbox
        private readonly By LastNameTxtBox = By.Name("lastName");    // locate lastname txtbox


        public PimEmployee(IWebDriver driver) : base(driver)
        {
        }


        public void ClickPIM()
        {
            Click(PIMLink);
        }

        public void ClickADD()
        {
            Click(AddBtn);
        }

        public void EnterNames(string firstname, string lastname)
        {
           SendKeys(FirstNameTxtBox,firstname);
           SendKeys(LastNameTxtBox,lastname); 
        }
    }
}