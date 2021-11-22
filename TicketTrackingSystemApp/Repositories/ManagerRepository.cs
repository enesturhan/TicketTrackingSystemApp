using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketTrackingSystemApp.Models;

namespace TicketTrackingSystemApp.Repositories
{
    public class ManagerRepository
    {
        private readonly ApplicationDbContext _db;

        public ManagerRepository()
        {
            _db = new ApplicationDbContext();
        }

        public Manager Find(string id)
        {
            return _db.Managers.Find(id);
        }
        public List<Manager> List()
        {
            return _db.Managers.ToList();
        }
    }
}
