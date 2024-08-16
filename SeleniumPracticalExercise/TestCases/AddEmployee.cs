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
            string username = "Admin"; 
            string password = "admin123"; 
            string firstName = Utils.GenerateRandomString(6); 
            string lastName = Utils.GenerateRandomString(8); 

            // Steps to automate:
            // 1. Navigate to https://opensource-demo.orangehrmlive.com/web/index.php/auth/login
            Driver.Value.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            // 2. Log in using Username: Admin, Password: admin123 using LoginPage - Page Object Model
            LoginPage loginPage = new LoginPage(Driver.Value);
            loginPage.Login(username, password); 

            // 3. Click "PIM" in the left nav using PimEmployee - Page Object Model
            LeftNavPanel leftNavPanel = new LeftNavPanel(Driver.Value);
            leftNavPanel.ClickPIM();

            // 4. Click "+Add"
            EmployeeInformationPage employeeInformationPage = new EmployeeInformationPage(Driver.Value);
            employeeInformationPage.AddButton();

            // 5. Randomly generate a first name (6 characters) and last name (8 characters) and enter them into the form
            // 6. Get the Employee Id for use later - using VerifyEmployee POM
            // 7. Click Save
            AddEmployeePage addEmployeePage = new AddEmployeePage(Driver.Value);
            string storeEmployeeID = addEmployeePage.GetIDNum();
            addEmployeePage.EnterNames(firstName, lastName);      

            // 8. Click "PIM" in the left nav
            leftNavPanel.ClickPIM(); 

            // 8. Search for the employee you just created by Employee Id
            employeeInformationPage.SetTxtBoxEmpID(storeEmployeeID); 

            employeeInformationPage.SearchButton();  

            // 9. In the employee search results, use NUnit asserts to validate that Id, First Name, and Last Name are correct
            employeeInformationPage.verifyEmployeeId(storeEmployeeID);
            employeeInformationPage.verifyName(firstName, lastName);
        }
        
    }
