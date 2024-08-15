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
        string username = "Admin"; // declaring username for login
        string password = "admin123"; // declaring passowrd for login
        string firstName = Utils.GenerateRandomString(6); // storing firstname so I can use in search result/ assert
        string lastName = Utils.GenerateRandomString(8); // storing lastname so I can use in search result/ assert

        // Steps to automate:
        // 1. Navigate to https://opensource-demo.orangehrmlive.com/web/index.php/auth/login
        Driver.Value.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

        // 2. Log in using Username: Admin, Password: admin123 using LoginPage - Page Object Model
        LoginPage loginPage = new LoginPage(Driver.Value);
        loginPage.Login(username, password); // enter user & password

        // 3. Click "PIM" in the left nav using PimEmployee - Page Object Model
        AddingEmployee addEmployee = new AddingEmployee(Driver.Value);  // Page object model  PIMEmployee
        addEmployee.ClickPIMAdd();  //clicking PIM button

        // 5. Randomly generate a first name (6 characters) and last name (8 characters) and enter them into the form using PimEmployee - Page Object Mode       
        addEmployee.EnterNames(firstName, lastName); // enter random names

        // 6. Get the Employee Id for use later - using VerifyEmployee POM
        VerifyEmployee verifyEmployee = new VerifyEmployee(Driver.Value); // Page Oobject Model - VerifyEmplpyee
        string storeEmployeeID = verifyEmployee.IDNum(); // storing ID to employeeID
        
        // 7. Click Save
        verifyEmployee.ClickSave(); 

        // 8. Click "PIM" in the left nav
        verifyEmployee.ClickPIM();  

        // 8. Search for the employee you just created by Employee Id
        verifyEmployee.TxtBoxEmpID(storeEmployeeID); //  click txtbox and enter ID

        verifyEmployee.SubmitButton();  

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
