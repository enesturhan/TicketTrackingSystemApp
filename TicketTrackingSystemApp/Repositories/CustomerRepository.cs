using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketTrackingSystemApp.Models;

namespace TicketTrackingSystemApp.Repositories
{
    public class CustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository()
        {
            _db = new ApplicationDbContext();
        }
     
        public Customer Find(string id)
        {
            return _db.Customers.Find(id);
        }
        public List<Customer> List()
        {
            return _db.Customers.ToList();
        }

    }
}
