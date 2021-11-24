using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketTrackingSystemApp.Models;
using TicketTrackingSystemApp.Repositories;

namespace TicketTrackingSystemApp.Pages.Tickets
{
    public class SetTechDetailsModel : PageModel
    {
        [BindProperty]
        public string Id { get; set; }

        private readonly TicketRepository _ticketRepository;
        private readonly CustomerRepository _customerRepository;
        public SetTechDetailsModel(TicketRepository ticketRepository,CustomerRepository customerRepository)
        {
            _ticketRepository = ticketRepository;
            _customerRepository = customerRepository;
        }

        [BindProperty]
        public Ticket TicketInput { get; set; }
        public Customer Customer { get; set; }

        public void OnGet(string? id)
        {
         
            Id = id;
            TicketInput = _ticketRepository.Find(Id);
            Customer = _customerRepository.Find(TicketInput.CustomerId);
        }
        public void OnPostSave()
        {
           
            
             _ticketRepository.Update(TicketInput);
        }
    }
}