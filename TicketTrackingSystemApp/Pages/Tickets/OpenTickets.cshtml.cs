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
    public class OpenTicketsModel : PageModel
    {

        public TicketRepository _ticketRepository;


        public OpenTicketsModel(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public List<Ticket> TicketInput { get; set; }

        public void OnGet()
        {

            TicketInput = _ticketRepository.List();
        }

    }
}
