
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
    }
}
