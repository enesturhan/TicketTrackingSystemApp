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
    public class SetTechDetailsModel : PageModel
    {
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string LevelOfDiff { get; set; }

        [BindProperty]
        public string Prio { get; set; }


        private readonly TicketRepository _ticketRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly TicketCreateService _ticketCreateService;
        public SetTechDetailsModel(TicketRepository ticketRepository,CustomerRepository customerRepository,TicketCreateService ticketCreateService)
        {
            _ticketRepository = ticketRepository;
            _customerRepository = customerRepository;
            _ticketCreateService = ticketCreateService;
        }

        [BindProperty]
        public Ticket TicketInput { get; set; }
        public Customer Customer { get; set; }

        public string customerName { get; set; }
        
        public void OnGet(string? id)
        {

         
            Id = id;

            TicketInput = _ticketRepository.Find(Id);
       
            Customer = _customerRepository.Find(TicketInput.CustomerId);

            customerName = Customer.Name;
              
            _ticketRepository.Update(TicketInput);
        }
        public void OnPostSave(string? id, string customRadioInline, string customRadio)
        {
            Id = id;
            TicketInput = _ticketRepository.Find(id);
            Customer = _customerRepository.Find(TicketInput.CustomerId);


            _ticketCreateService.SetTicketStatusReadyForAssignment(TicketInput);
            LevelOfDiff = customRadio;
            Prio = customRadioInline;
            TicketInput.LevelOfDifficulty = LevelOfDiff;
            TicketInput.Priority = Prio;
            _ticketRepository.Update(TicketInput);
        }
    }
}
