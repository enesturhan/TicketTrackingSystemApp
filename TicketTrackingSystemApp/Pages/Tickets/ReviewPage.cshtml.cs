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
   
    public class ReviewPageModel : PageModel
    {
        private readonly TicketRepository _ticketRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly TicketCreateService _ticketCreateService;
        private readonly SmtpMailService _smtpMailService;
        private readonly ManagerRepository _managerRepository;


        public ReviewPageModel(TicketRepository ticketRepository, EmployeeRepository employeeRepository, TicketCreateService ticketCreateService,SmtpMailService smtpMailService,ManagerRepository managerRepository)
        {
            _ticketRepository = ticketRepository;
            _employeeRepository = employeeRepository;
            _ticketCreateService = ticketCreateService;
            _smtpMailService = smtpMailService;
            _managerRepository = managerRepository;
        }

        [BindProperty]
        public Ticket TicketIn { get; set; }
        [BindProperty]
        public Manager Managers { get; set; }
        public List<Ticket> TicketInput { get; set; }
        public List<Employee> EmployeeInput { get; set; }


        public List<string> EmployeeNames { get; set; } = new();
        public string employeeName { get; set; }
        public string Id { get; set; }

        public int count { get; set; } = 0;
        public Employee employee { get; set; }
       
        public void OnGet()
        {

            TicketInput = _ticketRepository.List().FindAll(x => x.TicketStatus == TicketStates.Review.ToString());

            TicketInput = TicketInput.Where(x => x.TicketStatus == TicketStates.Review.ToString()).ToList();

            var emps = TicketInput.Where(x => x.TicketStatus == TicketStates.Review.ToString()).Select(y => y.EmployeeId);

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
            Managers = _managerRepository.Find(TicketIn.ManagerId);

            employeeName = employee.Name;
            var mail = Managers.Mail;

            _ticketCreateService.SetTicketStatusClosed(TicketIn);
            _smtpMailService.SendEmail("bitirmeprojesi55@gmail.com",mail, $"Ticketin takip numaras� : {TicketIn.Id} Ba�ar�l� bir �ekilde close duruma getirildi", "Ticket kapal� duruma getirildi");
            ViewData["Message"] = "Ba�ar�l� bir �ekilde kapat�ld� ve mail at�ld�.";
            OnGet();
        }

    }
}
