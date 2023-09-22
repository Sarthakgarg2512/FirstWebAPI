using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
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
            EntityState es = _context.Entry(updatedEmployeeData).State;
            Console.WriteLine($"EntityState BeforeUpdate : {es.GetDisplayName()}");
            _context.Employees.Update(updatedEmployeeData);
            es = _context.Entry(updatedEmployeeData).State;
            Console.WriteLine($"EntityState AfterUpdate : {es.GetDisplayName()}");
            // Save changes to the database
            _context.SaveChanges();
            es = _context.Entry(updatedEmployeeData).State;
            Console.WriteLine($"EntityState After SSaveChanges : {es.GetDisplayName()}");
            return updatedEmployeeData;
        }
        public Employee DeleteEmployee(int employeeId)
        {
            Employee deleteEmployeeData = _context.Employees.Find(employeeId);

            if (deleteEmployeeData == null)
            {
                throw new ArgumentException("Employee not found.");
            }

            _context.Employees.Remove(deleteEmployeeData);
            // Save changes to the database
            _context.SaveChanges();

            return deleteEmployeeData;
        }

        public Employee AddEmployee(Employee newEmployeeData)
        {
            Employee? foundEmp = _context.Employees.Find(newEmployeeData.EmployeeId);
            if (foundEmp != null)
            {
                throw new Exception("Failed to add Employee.Duplicate Id");
            }
            EntityState es = _context.Entry(newEmployeeData).State;
            Console.WriteLine($"EntityState BeforeAdd : {es.GetDisplayName()}");
            _context.Employees.Add(newEmployeeData);
            es = _context.Entry(newEmployeeData).State;
            Console.WriteLine($"EntityState AfterAdd : {es.GetDisplayName()}");
             _context.SaveChanges();
            es=_context.Entry(newEmployeeData).State;
            Console.WriteLine($"EntityState After SaveChange : {es.GetDisplayName()}");
            return newEmployeeData;
            // Add the new employee to the context
            //_context.Employees.Add(newEmployeeData);
            //// Save changes to the database
            //_context.SaveChanges();
            //return newEmployeeData;
        }
    }
}

