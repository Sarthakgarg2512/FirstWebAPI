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
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmployees();
            return employees;
        }
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployee(id);
            return employees;
        }
    }
}

