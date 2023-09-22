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
       
        public IActionResult AddEmployee([FromBody] EmpViewModel employeeRequest)
        {
           
                if (employeeRequest == null)
                {
                    return BadRequest("Employee data is missing in the request.");
                }
                Employee newEmployee = new Employee
                {
                    FirstName = employeeRequest.FirstName,
                    LastName = employeeRequest.LastName,
                    BirthDate = employeeRequest.BirthDate,
                    HireDate = employeeRequest.HireDate,
                    Title = employeeRequest.Title,
                    City = employeeRequest.City,
                    ReportsTo = employeeRequest.ReportsTo > 0 ? employeeRequest.ReportsTo : null
                };

                Employee addedEmployee = _repositoryEmployee.AddEmployee(newEmployee);

                // Return a Created response with the newly created employee
                return CreatedAtAction(nameof(EmployeeDetails), new { id = addedEmployee.EmployeeId }, addedEmployee);
            }
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployee(id);
            return employees;
        }
        [HttpPut("/Update")]
        public Employee Put(int id, [FromBody] Employee updatedEmployeeData)
        {
            updatedEmployeeData.EmployeeId = id;
            Employee savedEmployee = _repositoryEmployee.UpdateEmployee(updatedEmployeeData);
            return savedEmployee;
        }
        
        [HttpDelete("/DeleteEmp/{id}")]
        public IActionResult DeleteEmp(int id)
        {
            try
            {
                Employee deletedEmployee = _repositoryEmployee.DeleteEmployee(id);

                if (deletedEmployee == null)
                {
                    return NotFound(); // Employee with the specified ID was not found
                }

                return Ok(deletedEmployee); // Return the deleted employee
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return a bad request response for any errors
            }
        }

    }
}

