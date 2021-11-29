﻿using System;
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
        private readonly SmtpMailService _smtpMailService;
        public TicketCreateService( TicketRepository ticketRepository,SmtpMailService smtpMailService)
        {
            _ticketRepository = ticketRepository;
            _smtpMailService = smtpMailService;
        }
    
        public void CreateTicket(Ticket ticket,string id)
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
            ticket.Id = Guid.NewGuid().ToString();
            ticket.CustomerId= id.ToString();

            ticket.TicketStatus = TicketStates.Opened.ToString();
            
            ticket.CreateDate =DateTime.Now.Date;
            _ticketRepository.Add(ticket);

        }
        private void AddTicket(Ticket ticket, TicketStates ticketStatus)
        { 
            
            ticket.TicketStatus = ticketStatus.ToString();
            _ticketRepository.Update(ticket);
        }


        public void SetTicketStatusOpen(Ticket ticket)
        {
            ticket.CreateDate = DateTime.Now;
            AddTicket(ticket, TicketStates.Opened);
          
        }

        public void SetTicketStatusReadyForAssignment(Ticket ticket)

        {
           
            AddTicket(ticket, TicketStates.ReadyForAssignment);
        }

        public void SetTicketStatusAssigned(Ticket ticket)
        {
            ticket.AssignedDate = DateTime.Now;
            AddTicket(ticket, TicketStates.Assigned);
            

        }

        public void SetTicketStatusClosed(Ticket ticket)
        {
            ticket.ClosedDate = DateTime.Now;
            AddTicket(ticket, TicketStates.Closed);
          

        }

        public void SetTicketStatusReview(Ticket ticket)
        {
            ticket.ReviewDate = DateTime.Now;
            AddTicket(ticket, TicketStates.Review);
        

        }

        public void SetTicketStatusCompleted(Ticket ticket)
        {
            ticket.CompletedDate = DateTime.Now;
            AddTicket(ticket, TicketStates.Completed);
           

        }

        //public TicketDetail GetOpenTicketDetailByTicketId(string Id)
        //{
        //    return GetTicketDetailByTicketId(Id, TicketStates.Opened.ToString());
        //}

        //public TicketDetail GetAssignedTicketDetailByTicketId(string Id)
        //{
        //    return GetTicketDetailByTicketId(Id, TicketStates.Assigned.ToString());
        //}

        //public TicketDetail GetClosedTicketDetailByTicketId(string Id)
        //{
        //    return GetTicketDetailByTicketId(Id, TicketStates.Closed.ToString());

        //}

        //public TicketDetail GetCompletedTicketDetailByTicketId(string Id)
        //{
        //    return GetTicketDetailByTicketId(Id, TicketStates.Completed.ToString());

        //}

        //public TicketDetail GetReviewTicketDetailByTicketId(string Id)
        //{
        //    return GetTicketDetailByTicketId(Id, TicketStates.Review.ToString());

        //}

    
    }
}
