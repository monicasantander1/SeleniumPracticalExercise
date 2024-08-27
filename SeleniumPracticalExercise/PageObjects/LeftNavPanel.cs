using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class LeftNavPanel : BasePageLocal
    {
        private readonly By _pimButtonLocator = By.XPath("//span[text()='PIM']");

        public LeftNavPanel(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Click PIM on Left Navigation Panel
        /// </summary>
        public void ClickPim()
        {
            Click(_pimButtonLocator);
        }
    }
}