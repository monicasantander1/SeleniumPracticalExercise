using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class LoginPage : BasePageLocal
    { 
        private readonly By _passwordFieldLocator = By.CssSelector("input[name='password']"); 
        private readonly By _submitButtonLocator = By.CssSelector("button");
        private readonly By _userNameFieldLocator = By.CssSelector("input[name='username']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Enter username and password 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(string username, string password)
        {
            SendKeys(_userNameFieldLocator, username);  
            SendKeys(_passwordFieldLocator, password);
            Click(_submitButtonLocator);
        }
    }
}