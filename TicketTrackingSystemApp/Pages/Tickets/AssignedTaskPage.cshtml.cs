using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketTrackingSystemApp.Models;
using TicketTrackingSystemApp.Repositories;
using TicketTrackingSystemApp.Services;

namespace TicketTrackingSystemApp.Pages.Tickets
{
    public class AssignedTaskPageModel : PageModel
    {

        private readonly TicketRepository _ticketRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly TicketCreateService _ticketCreateService;

        public AssignedTaskPageModel(TicketRepository ticketRepository, EmployeeRepository employeeRepository,TicketCreateService ticketCreateService)
        {
            _ticketRepository = ticketRepository;
            _employeeRepository = employeeRepository;
            _ticketCreateService = ticketCreateService;
        }

        [BindProperty]
        public Ticket TicketIn { get; set; }
        public List<Ticket> TicketInput { get; set; }
        public string employeeName { get; set; }
        public string Id { get; set; }

        public Employee employee { get; set; }
        public void OnGet(string id)

        {
          

            TicketInput = _ticketRepository.List().FindAll(x => x.TicketStatus == TicketStates.Assigned.ToString());

     

        }
        public void OnPostSave(string id)
        {
            Id = id;
            TicketIn = _ticketRepository.Find(Id);
            _ticketCreateService.SetTicketStatusClosed(TicketIn);
        }

    }
}
