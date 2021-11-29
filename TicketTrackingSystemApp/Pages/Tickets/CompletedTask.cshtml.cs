using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketTrackingSystemApp.Models;
using TicketTrackingSystemApp.Repositories;
using TicketTrackingSystemApp.Services;

namespace TicketTrackingSystemApp.Pages
{
    public class CompletedTaskModel : PageModel
    {
        private readonly TicketRepository _ticketRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly TicketCreateService _ticketCreateService;


        public CompletedTaskModel(TicketRepository ticketRepository, EmployeeRepository employeeRepository, TicketCreateService ticketCreateService)
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
        public List<string> EmployeeNames { get; set; } = new();

        public int count { get; set; } = 0;

        public Employee employee { get; set; }
        public void OnGet()

        {


            TicketInput = _ticketRepository.List().FindAll(x => x.TicketStatus == TicketStates.Completed.ToString());
            TicketInput = TicketInput.Where(x => x.TicketStatus == TicketStates.Completed.ToString()).ToList();

            var emps = TicketInput.Where(x => x.TicketStatus == TicketStates.Completed.ToString()).Select(y => y.EmployeeId);

            foreach (var item in emps)
            {
                employee = _employeeRepository.Find(item);
                EmployeeNames.Add(employee.Name);

            }


        }
        public void OnPostSave(string id)
        {
            Id = id;
            TicketIn = _ticketRepository.Find(Id);
            _ticketCreateService.SetTicketStatusClosed(TicketIn);
            OnGet();
        }

    }
}
