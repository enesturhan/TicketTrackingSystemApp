using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketTrackingSystemApp.Models;
using TicketTrackingSystemApp.Repositories;

namespace TicketTrackingSystemApp.Services
{
    public class TicketCreateService
    {
        private readonly TicketRepository _ticketRepository;

        public TicketCreateService( TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
    
        public void CreateTicket(Ticket ticket,string id,string Status)
        {
            if (string.IsNullOrEmpty(ticket.Subject))
            {
                throw new Exception("Subject bos gecilemez");
            }
            if (ticket.Subject.Length >50)
            {
                throw new Exception("50 karakterden fazla girilemez");
            }
            if (string.IsNullOrEmpty(ticket.Description))
            {
                throw new Exception("Description bos gecilemez");
            }

            if (ticket.Description.Length >300)
            {
                throw new Exception("300 karakterden fazla girilemez");
            }
            
            ticket.CustomerId= id.ToString();

            ticket.TicketStatus = Status;
            
            ticket.CreateDate =(DateTime)(DateTime.Now.Date);
            _ticketRepository.Add(ticket);
        }
    }
}
