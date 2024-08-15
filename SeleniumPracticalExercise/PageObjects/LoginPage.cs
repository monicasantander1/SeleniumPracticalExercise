using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class LoginPage : BasePageLocal
    {
        private readonly By _txtUserNameLocator = By.CssSelector("input[name='username']"); 
        private readonly By _txtPasswordLocator = By.CssSelector("input[name='password']"); 
        private readonly By _btnSubmitLocator = By.CssSelector("button");  

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Enter (SendKeys) for username and password then Click Submit button
        /// </summary>
        public void Login(string username, string password)
        {
            SendKeys(_txtUserNameLocator,username);  
            SendKeys(_txtPasswordLocator,password);
            Click(_btnSubmitLocator);
        }
    }
}