using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumPracticalExercise.TestCases.Common;
using SeleniumPracticalExercise.Common;
using static SeleniumPracticalExercise.Common.Utils;
using static SeleniumPracticalExercise.PageObjects.Common.BasePageLocal;
using SeleniumPracticalExercise.PageObjects.Common;
using System.Security.Cryptography.X509Certificates;
using SeleniumPracticalExercise.PageObjects;





class AddEmployee : BaseTestLocal

    {
    [Test]
    [Category("Add Employee")]
    public void AddEmployeeTest()
    {
        // Steps to automate:
        // 1. Navigate to https://opensource-demo.orangehrmlive.com/web/index.php/auth/login
        IWebDriver driver = Driver.Value;
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        // waiting on page to locate username, if I don't use this it wont enter the username
        new WebDriverWait(driver, TimeSpan.FromSeconds(10))
        .Until(ExpectedConditions.ElementToBeClickable(By.Name("username"))).Click();

        // 2. Log in using Username: Admin, Password: admin123 using LoginPage - Page Object Model
        LoginPage loginPage = new LoginPage(driver);
        loginPage.Login("Admin", "admin123"); // enter user & password


        // 3. Click "PIM" in the left nav using PimEmployee - Page Object Model
        new WebDriverWait(driver, TimeSpan.FromSeconds(10))
        .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='PIM']")));

        PimEmployee pimEmployee = new PimEmployee(driver);  // Page object model  PIMEmployee
        pimEmployee.ClickPIM();  //clicking PIM button

        // 4. Click "+Add" using PimEmployee - Page Object Model
        new WebDriverWait(driver, TimeSpan.FromSeconds(10))
        .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.orangehrm-header-container > button")));

        pimEmployee.ClickADD(); //clicking Add button

        // 5. Randomly generate a first name (6 characters) and last name (8 characters) and enter them into the form using PimEmployee - Page Object Mode
        new WebDriverWait(driver, TimeSpan.FromSeconds(10))
        .Until(ExpectedConditions.ElementToBeClickable(By.Name("firstName")));

        string firstName = Utils.GenerateRandomString(6);
        string lastName = Utils.GenerateRandomString(8);
        pimEmployee.EnterNames(firstName, lastName); // enter random names



        // 6. Get the Employee Id for use later - using VerifyEmployee POM
        VerifyEmployee verifyEmployee = new VerifyEmployee(driver); // Page Oobject Model - VerifyEmplpyee

        string storeEmployeeID = verifyEmployee.IDNum(); // storing ID to employeeID
       
        
        // 7. Click Save
        verifyEmployee.ClickSave(); // click save

        // allow page to redirect cuz sometimes it takes a while
        Thread.Sleep(7000);


        // 8. Click "PIM" in the left nav
        verifyEmployee.ClickPIM();  // click PIM


        // 8. Search for the employee you just created by Employee Id
        new WebDriverWait(driver, TimeSpan.FromSeconds(10))
        .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.oxd-input-group input.oxd-input")));

        verifyEmployee.TxtBoxEmpID(storeEmployeeID); //  click txtbox and enter ID


        verifyEmployee.SubmitBut();   // click submit



        // 9. In the employee search results, use NUnit asserts to validate that Id, First Name, and Last Name are correct
        verifyEmployee.verifyEmployeeId(storeEmployeeID);
        verifyEmployee.verifyName(firstName, lastName);

        // NOTE:
        // - Use the provided WebDriver methods in BasePageLocal.cs
        // - Create page objects as needed
        // - Document all methods using XML documentation, https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/
        // - You will need to create any necessary page objects and/or utility classes to complete all steps and validations.
    }
        
    }
