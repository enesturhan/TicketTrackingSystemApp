using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketTrackingSystemApp.Models;
using TicketTrackingSystemApp.Repositories;

namespace TicketTrackingSystemApp.Services
{
    public class WaitingForAssigmentTicketService
    {

        private readonly TicketRepository _ticketRepository;

        public WaitingForAssigmentTicketService(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;

        }

        public void ControlEmployeeTicket(Ticket ticket , string id)
        {

          //  var yeni=_ticketRepository.Find(id);

           
        }

        private void ControlDate() { }
        private void Difficulty(Ticket ticket) {

            var yeni = _ticketRepository.List();

            
            var idDeger= _ticketRepository.Find(ticket.Id);



            var levelofdiff = idDeger.LevelOfDifficulty.Count();


            if (levelofdiff > 3)
            {
                throw new Exception("3 den fazla deger alamaz");
            }
      
        }
        private void PrioControl(Ticket ticket)
        {
            var yeni = _ticketRepository.List();
            var idDeger = _ticketRepository.Find(ticket.Id);
            

        }
       
    }
}
