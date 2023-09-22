
using System.Collections.Generic;
using System.Linq;

namespace FirstWebAPI.Models
{
    public class RepositoryEmployee
    {
        private  NorthwindContext _context;
        public RepositoryEmployee(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee GetEmployee(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }
        public Employee UpdateEmployee(Employee updatedEmployeeData)
        {
            _context.Employees.Update(updatedEmployeeData);
            // Save changes to the database
            _context.SaveChanges();
            return updatedEmployeeData;
        }
        public Employee DeleteEmployee(Employee deleteEmployeeData) 
        {
            _context.Employees.Remove(deleteEmployeeData);
            // Save changes to the database
            _context.SaveChanges();
            return deleteEmployeeData;
        }

        public Employee AddEmployee(Employee newEmployeeData)
        {
            // Add the new employee to the context
            _context.Employees.Add(newEmployeeData);

            // Save changes to the database
            _context.SaveChanges();

            return newEmployeeData;
        }


    }
}

