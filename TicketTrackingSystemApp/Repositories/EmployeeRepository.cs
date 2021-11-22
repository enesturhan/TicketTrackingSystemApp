using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketTrackingSystemApp.Models;

namespace TicketTrackingSystemApp.Repositories
{
    public class EmployeeRepository
    {

        private readonly ApplicationDbContext _db;

        public  EmployeeRepository()
        {
            _db = new ApplicationDbContext();
        }

        public Employee Find(string id)
        {
            return _db.Employees.Find(id);
        }
        public List<Employee> List()
        {
            return _db.Employees.ToList();
        }
    }
}
