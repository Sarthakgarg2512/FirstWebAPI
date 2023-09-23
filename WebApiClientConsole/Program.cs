
using WebApiClientConsole;

Console.WriteLine("API Client");
//EmpViewModel updatedEmployee = new EmpViewModel()
//{
//    EmpId = 5,
//    FirstName = "XYZ",
//    LastName = "ABC",
//    City = "CT",
//    BirthDate = new DateTime(1990, 02, 02),
//    HireDate = new DateTime(2020, 02, 02),
//    Title = "Sales"
//};
//EmployeeClient.UpdateEmployee(5, updatedEmployee).Wait();

EmployeeClient.DeleteEmployee(13).Wait();

Console.ReadLine();