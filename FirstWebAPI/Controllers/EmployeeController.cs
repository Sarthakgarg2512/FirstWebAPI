using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace FirstWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private  RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repositoryEmployee)
        {
            _repositoryEmployee = repositoryEmployee;
        }
        
        [HttpGet]
        //GET: EmployeeController
        public IEnumerable<EmpViewModel> GetAllEmployees() 
        
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmployees();
                var empList = (
                    from emp in employees
                    select new EmpViewModel()
                    {
                        EmpId = emp.EmployeeId,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        BirthDate = emp.BirthDate,
                        HireDate = emp.HireDate,
                        Title = emp.Title,
                        City = emp.City,
                        ReportsTo = emp.ReportsTo
                    }
                    ).ToList();
            return empList;
        }
        [HttpPost("/AddEmp")]
        public IActionResult AddEmployee([FromBody] Employee newEmployeeData)
        {
            
            
                Employee addedEmployee = _repositoryEmployee.AddEmployee(newEmployeeData);
                return CreatedAtAction(nameof(EmployeeDetails), new { id = addedEmployee.EmployeeId }, addedEmployee);
            

        }

        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployee(id);
            return employees;
        }
        [HttpPut]
        public Employee Put(int id, [FromBody] Employee updatedEmployeeData)
        {
            updatedEmployeeData.EmployeeId = id;
            Employee savedEmployee = _repositoryEmployee.UpdateEmployee(updatedEmployeeData);
            return savedEmployee;
        }
        [HttpDelete]
        public Employee DeleteEmp(int id, [FromBody] Employee deleteEmployeeData)
        {
            deleteEmployeeData.EmployeeId = id;
            Employee savedEmployee = _repositoryEmployee.DeleteEmployee(deleteEmployeeData);
            return savedEmployee;
        }

    }
}

