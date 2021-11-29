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
    public class ClosedPageModel : PageModel
    {

        private readonly TicketRepository _ticketRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly TicketCreateService _ticketCreateService;

        public ClosedPageModel(TicketRepository ticketRepository, EmployeeRepository employeeRepository, TicketCreateService ticketCreateService)
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
        public Employee employee { get; set; }
        public int count { get; set; } = 0;
       

        public void OnGet()

        {


            TicketInput = _ticketRepository.List().FindAll(x => x.TicketStatus == TicketStates.Closed.ToString());

            TicketInput = TicketInput.Where(x => x.TicketStatus == TicketStates.Closed.ToString()).ToList();

            var emps = TicketInput.Where(x => x.TicketStatus == TicketStates.Closed.ToString()).Select(y => y.EmployeeId);

            foreach (var item in emps)
            {
                employee = _employeeRepository.Find(item);
                EmployeeNames.Add(employee.Name);

            }


        }
        public void OnPostComplete(string id)
        {
           
            Id = id;
            TicketIn = _ticketRepository.Find(Id);
            _ticketCreateService.SetTicketStatusCompleted(TicketIn);
            OnGet();
        }
        public void OnPostReview(string id)
        {
         
            Id = id;
            TicketIn = _ticketRepository.Find(Id);
            _ticketCreateService.SetTicketStatusReview(TicketIn);
            OnGet();
        }

    }
}
