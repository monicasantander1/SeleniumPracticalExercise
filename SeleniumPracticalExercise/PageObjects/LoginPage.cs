using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class LoginPage : BasePageLocal
    {
        private readonly By TxtUserName = By.Name("username"); // locate username
        private readonly By TxtPassword = By.Name("password"); // locate password
        private readonly By BtnSubmit = By.TagName("button");  // locate Submit button

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

      

        public void Login(string username, string password)
        {
            SendKeys(TxtUserName,username);  
            SendKeys(TxtPassword,password);
            Click(BtnSubmit);
        }
    }
}