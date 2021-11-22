﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketTrackingSystemApp.Models
{
    public class Employee
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Manager Manager { get; set; }


    }
}
