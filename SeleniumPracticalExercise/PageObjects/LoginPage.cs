using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class LoginPage : BasePageLocal
    {
        private readonly By TxtUserNameLocator = By.CssSelector("input[name='username']"); 
        private readonly By TxtPasswordLocator = By.CssSelector("input[name='password']"); 
        private readonly By BtnSubmitLocator = By.CssSelector("button");  
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }
        public void Login(string username, string password)
        {
            SendKeys(TxtUserNameLocator,username);  
            SendKeys(TxtPasswordLocator,password);
            Click(BtnSubmitLocator);
        }
    }
}