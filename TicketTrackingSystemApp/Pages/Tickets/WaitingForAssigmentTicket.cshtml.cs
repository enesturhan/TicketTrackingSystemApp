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

        public List<SelectListItem> options { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Lütfen employee alanýný boþ geçmeyiniz")]
        public string selectedEmployeeId { get; set; }

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

    }
}

