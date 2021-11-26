using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketTrackingSystemApp.Models;
using TicketTrackingSystemApp.Repositories;
using TicketTrackingSystemApp.Services;

namespace TicketTrackingSystemApp.Pages.Tickets
{
    public class WaitingForAssigmentTicketModel : PageModel
    {
        private readonly TicketRepository _ticketRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly WaitingForAssigmentTicketService _waitingforAssigmentTicketService;


        public WaitingForAssigmentTicketModel(TicketRepository ticketRepository,EmployeeRepository employeeRepository,WaitingForAssigmentTicketService waitingForAssigmentTicketService)
        {
            _ticketRepository = ticketRepository;
            _employeeRepository = employeeRepository;
            _waitingforAssigmentTicketService = waitingForAssigmentTicketService;
        }
        [BindProperty]
        public List<Ticket> TicketInput { get; set; }

        [BindProperty]
        public Ticket TicketIn { get; set; }

        [BindProperty]
        public string Id { get; set; }

    
        public List<SelectListItem> options { get; set; }

        [BindProperty]
        public string selectedEmployeeId { get; set; }
        [BindProperty]
        public string selected { get; set; }
        [BindProperty]
        public IEnumerable<Employee> newList { get; set; }
        public void OnGet()
        {
            TicketInput = _ticketRepository.List();

            newList = _employeeRepository.List();

            

            options = newList.Select(a =>
             new SelectListItem
             {
                 Value = a.Id.ToString(),
                 Text = a.Name
             }).ToList();
        }
        public void OnPostSave(string id,Employee employee)
        {

            Id = id;
            TicketIn = _ticketRepository.Find(id);
            var emp = _employeeRepository.Find(selectedEmployeeId);

            TicketIn.EmployeeId = emp.Id;


            _waitingforAssigmentTicketService.ValidateEmployee(TicketIn.EmployeeId, TicketIn.Id, employee);
            TicketIn.AssignedDate = DateTime.Now;
            _ticketRepository.Update(TicketIn);

            OnGet();
          //if (ModelState.IsValid)
        //   {


       //    }

        }

    }
}

