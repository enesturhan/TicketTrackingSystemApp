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

namespace TicketTrackingSystemApp.Pages.Tickets
{
    public class WaitingForAssigmentTicketModel : PageModel
    {
        public TicketRepository _ticketRepository;
        public EmployeeRepository _employeeRepository;


        public WaitingForAssigmentTicketModel(TicketRepository ticketRepository,EmployeeRepository employeeRepository)
        {
            _ticketRepository = ticketRepository;
            _employeeRepository = employeeRepository;
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
        public void OnPostSave(string id)
        {

            Id = id;
            TicketIn = _ticketRepository.Find(id);
            var emp = _employeeRepository.Find(selectedEmployeeId);

            TicketIn.EmployeeId = emp.Id;

     
            TicketIn.TicketStatus = "Assigned";
            TicketIn.AssignedDate = DateTime.Now;
            _ticketRepository.Update(TicketIn);

            OnGet();
          //if (ModelState.IsValid)
        //   {


       //    }

        }

    }
}

