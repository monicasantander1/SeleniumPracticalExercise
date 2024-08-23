using NUnit.Framework;
using SeleniumPracticalExercise.Common;
using SeleniumPracticalExercise.PageObjects;
using SeleniumPracticalExercise.TestCases.Common;

class AddEmployee : BaseTestLocal
    {
        [Test]
        [Category("Add Employee")]
        public void AddEmployeeTest()
        {
            string userName = "Admin"; 
            string password = "admin123"; 
            string firstName = Utils.GenerateRandomString(6); 
            string lastName = Utils.GenerateRandomString(8);

            Driver.Value.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            new LoginPage(Driver.Value).Login(userName, password); 

            LeftNavPanel leftNavPanel = new LeftNavPanel(Driver.Value);
            leftNavPanel.ClickPim();

            EmployeeInformationPage employeeInformationPage = new EmployeeInformationPage(Driver.Value);
            employeeInformationPage.ClickAdd();

            AddEmployeePage addEmployeePage = new AddEmployeePage(Driver.Value);
            string storeEmployeeId = addEmployeePage.GetEmployeeId();
            addEmployeePage.SetNames(firstName, lastName);      

            leftNavPanel.ClickPim();

            employeeInformationPage.SetEmployeeId(storeEmployeeId);

            string actualIdResults = employeeInformationPage.GetEmployeeIdSearchResults();
            string actualFirstNameResults = employeeInformationPage.GetFirstNameSearchResults();
            string actualLastNameResults = employeeInformationPage.GetLastNameSearchResults();
            
            Assert.AreEqual(storeEmployeeId, actualIdResults, "Verify Employee ID.");
            Assert.AreEqual(firstName, actualFirstNameResults, "Verify First Name.");
            Assert.AreEqual(lastName, actualLastNameResults, "Verify Last Name.");
    }
}
