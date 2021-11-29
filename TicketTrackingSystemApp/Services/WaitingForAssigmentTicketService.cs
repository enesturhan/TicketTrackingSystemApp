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
        private readonly EmployeeRepository _employeeRepository;

        public WaitingForAssigmentTicketService(TicketRepository ticketRepository,EmployeeRepository employeeRepository)
        {
            _ticketRepository = ticketRepository;

        }

        public List<Ticket> EmployeeWaitingList { get; set; } = new();
        public List<Ticket> EmployeeDateList { get; set; } = new();
        public void ControlEmployeeTicket(Ticket ticket , string id)
        {

          //  var yeni=_ticketRepository.Find(id);

           
        }

   
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
            var tickets = _ticketRepository.List().Where(x => x.EmployeeId == ticket.EmployeeId && x.TicketStatus == ticket.TicketStatus).ToList();

            if(tickets.Any(x=> Convert.ToInt32(x.TicketStatus) >  Convert.ToInt32(ticket.Priority)))
                {
                throw new Exception("lüften önem sırası öncelikli olan bir ticket giriniz"); 

            }

        }
        public void ValidateEmployee (string EmpId,string ticketId)
        {
            var ticket = _ticketRepository.Find(ticketId);
         
            var assignedTicket = _ticketRepository.List();
            assignedTicket = assignedTicket.Where(x => x.TicketStatus != TicketStates.Opened.ToString() && x.TicketStatus == TicketStates.ReadyForAssignment.ToString()).ToList();

            assignedTicket = assignedTicket.Where(x => x.EmployeeId ==  EmpId.ToString()).ToList();

            foreach (var Ticket in assignedTicket)
            {
                var assignDetail = _ticketRepository.Find(Ticket.Id);
                EmployeeWaitingList.Add(assignDetail);
            }
            var ay = DateTime.Now.AddMonths(-1);

            var DateDetail = EmployeeWaitingList.Where(x => x.AssignedDate >= ay && x.AssignedDate < DateTime.Now).ToList();

            foreach (var item in EmployeeWaitingList)
            {
                EmployeeDateList.Add(assignedTicket.Find(x => x.Id == item.Id));

            }

            var employeeWorkingHour = EmployeeDateList.Sum(x => (Convert.ToInt32(5) * 8));

            if (EmployeeDateList.Count(x=>Convert.ToInt32(x.Priority)==4 )>4)
            {
                throw new Exception(" DAHA FAZLA İS ATANAMAZ ");

            }

            
            ticket.TicketStatus = TicketStates.Assigned.ToString();
            ticket.EmployeeId = EmpId;
            _ticketRepository.Update(ticket);


        }
       
        
       
    }
}
